#region licence
/*
The MIT License (MIT)

Copyright (c) 2013 Joeri van Belle

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using EV3MessengerLib.Protocol;
using System.Collections.Concurrent;

namespace EV3MessengerLib.Communication
{
    internal class Communicator
    {
        private PayloadParser payloadParser;
        private ConcurrentQueue<Payload> readPayloadsQueue;
        private SerialPort serialPort;
        private Object connectLock;

        /// <summary>
        /// The connection state. True if connected, false otherwise.
        /// </summary>
        public bool IsConnected
        {
            get { return serialPort.IsOpen; }
        }

        /// <summary>
        /// Gets the serial port name if connected. Returns the port name or null of not connected.
        /// </summary>
        public string Port
        {
            get
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        return serialPort.PortName;
                    }
                }
                catch (Exception e) // Very dirty :)
                {
                    Debug.WriteLine("Catched an exception while asking for the port name: " + e.Message);
                    Debug.WriteLine(e.StackTrace);
                }
                return null;
            }
        }

        /// <summary>
        /// Creates an object for communicating (serial over Bluetooth) with the EV3.
        /// </summary>
        public Communicator()
        {
            payloadParser = new PayloadParser();
            readPayloadsQueue = new ConcurrentQueue<Payload>();

            serialPort = new SerialPort();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            connectLock = new Object();
        }

        /// <summary>
        /// Connects to the given serial port.
        /// If the conncection succeeded, then reading of messages will start.
        /// </summary>
        /// <param name="port">The port to connect to. E.g. "COM1", "COM8", etc.</param>
        /// <returns>True if the connection was made, false otherwise.</returns>
        public bool Connect(string port)
        {
            if (port == null)
            {
                throw new ArgumentNullException("port");
            }

            lock (connectLock)
            {
                if (!serialPort.IsOpen
                    && IsValidPort(port))
                {
                    payloadParser.ClearData();
                    ClearReadPayloadsQueue();
                    try
                    {
                        serialPort.PortName = port;
                        serialPort.Open();
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                        return true;
                    }
                    catch (Exception e) // Very dirty :)
                    {
                        Debug.WriteLine("Catched an exception while connecting: " + e.Message);
                        Debug.WriteLine(e.StackTrace);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Send a raw message.
        /// </summary>
        /// <param name="rawMessage">The message to send (for valid format, see FieldInfo class)</param>
        /// <returns>True if send, false otherwise.</returns>
        public bool Send(byte[] rawMessage)
        {
            if (rawMessage == null)
            {
                throw new ArgumentNullException("rawMessage");
            }

            if (serialPort.IsOpen)
            {
                if (rawMessage.Length != 0)
                {
                    try
                    {
                        serialPort.Write(rawMessage, 0, rawMessage.Length);
                        Debug.WriteLine("Message was send to the serial port.");
                        return true;
                    }
                    catch (Exception e) // Very dirty :)
                    {
                        Debug.WriteLine("Catched an exception while sending a raw message: " + e.Message);
                        Debug.WriteLine(e.StackTrace);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Close the current connection and stop the reading of messages.
        /// </summary>
        public bool Disconnect()
        {
            lock (connectLock)
            {
                if (serialPort.IsOpen)
                {
                    try
                    {
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                        serialPort.Close();

                        payloadParser.ClearData();
                        ClearReadPayloadsQueue();
                        return true;
                    }
                    catch (Exception e) // Very dirty :)
                    {
                        Debug.WriteLine("Catched an exception while disconnecting: " + e.Message);
                        Debug.WriteLine(e.StackTrace);
                    }
                }
                return false;
            }
        }

        private bool IsValidPort(string port)
        {
            if (port != null)
            {
                string[] portNames = SerialPort.GetPortNames();
                foreach (string portName in portNames)
                {
                    if (portName.ToUpper() == port.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Get the next payload from the queue of read payloads.
        /// </summary>
        /// <returns>the next payload or null if no payload was read yet.</returns>
        public Payload GetNextReadPayload()
        {
            Payload payload;
            if (readPayloadsQueue.TryDequeue(out payload))
            {
                return payload;
            }
            return null;
        }

        private void ClearReadPayloadsQueue()
        {
            while (readPayloadsQueue.Count > 0)
            {
                Payload payload;
                readPayloadsQueue.TryDequeue(out payload);
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            if (serialPort.IsOpen)
            {
                try
                {
                    int nrOfBytesToRead = serialPort.BytesToRead;

                    if (nrOfBytesToRead > 0)
                    {
                        byte[] readBytes = new byte[nrOfBytesToRead];
                        int nrOfBytesRead = serialPort.Read(readBytes, 0, readBytes.Length);
                        Debug.Assert(nrOfBytesToRead == nrOfBytesRead);

                        payloadParser.AppendData(readBytes);
                        Payload payload = payloadParser.FindAndRemoveNextPayload();
                        while (payload != null)
                        {
                            readPayloadsQueue.Enqueue(payload);
                            payload = payloadParser.FindAndRemoveNextPayload();
                        }
                    }
                }
                catch (Exception exception) // Very dirty :)
                {
                    Debug.WriteLine("Catched an exception while reading bytes from the serial port: " + exception.Message);
                    Debug.WriteLine(exception.StackTrace);
                }
            }
        }
    }
}
