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
using EV3MessengerLib.Communication;
using EV3MessengerLib.Protocol;
using System.Diagnostics;

namespace EV3MessengerLib
{
    /// <summary>
    /// Makes it possible to send and receive bluetooth messages 
    /// from the Lego Mindstorms EV3 robot.
    /// </summary>
    public class EV3Messenger
    {
        /// <summary>
        /// Handles communication with the EV3 (serial over bluetooth)
        /// </summary>
        private Communicator communicator;

        /// <summary>
        /// If connected returns true, else false
        /// </summary>
        public bool IsConnected { get { return communicator.IsConnected; } }

        /// <summary>
        /// The serial port used for the connection or null if not connected.
        /// </summary>
        public string Port { get { return communicator.Port; } }

        /// <summary>
        /// Creates a new  instance of the EV3Messenger class.
        /// Used for communicating with the Lego Mindstorms EV3 robot 
        /// using serial over bluetooth.
        /// </summary>
        public EV3Messenger()
        {
            communicator = new Communicator();
        }

        /// <summary>
        /// Connects to the EV3 using the given serial port.
        /// </summary>
        /// <param name="port">The serial port to use for communicating with
        ///                    the EV3.</param>
        /// <returns>True if connected, false if not connected.</returns>
        public bool Connect(string port)
        {
            return communicator.Connect(port);
        }

        /// <summary>
        /// Disconnects from the EV3.
        /// </summary>
        public bool Disconnect()
        {
            return communicator.Disconnect();
        }

        /// <summary>
        /// Sends a text value to the connected EV3.
        /// </summary>
        /// <param name="title">The title of the message. 
        ///                     The length of the title may be atmost 254 characters.</param>
        /// <param name="value">The value of the message.
        ///                     The length of the value may be atmost 254 characters.
        ///                     Note: The EV3 protocol allows a text value to be of size 65534, but thats way too long for the slow transmission speed)
        ///                     </param>
        /// <returns>True if the message was send, false otherwise.</returns>
        public bool SendMessage(string title, string value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (title.Length > 254)
            {
                throw new ArgumentException("title", "The title may be at most 254 characters long.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length > 254)
            {
                throw new ArgumentException("value", "The value may be at most 254 characters long.");
            }

            byte[] rawMessage = RawMessage.Create(title, value);
            Debug.WriteLine("Going to send message <" + title + ": " + value + ">.");
            return communicator.Send(rawMessage);
        }

        /// <summary>
        /// Sends a number value to the connected EV3.
        /// </summary>
        /// <param name="title">The title of the message. 
        ///                     The length of the title may be atmost 254 characters.</param>
        /// <param name="value">The value of the message.</param>
        /// <returns>True if the message was send, false otherwise.</returns>
        public bool SendMessage(string title, float value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (title.Length > 254)
            {
                throw new ArgumentException("title", "The title may be at most 254 characters long.");
            }

            byte[] rawMessage = RawMessage.Create(title, value);
            Debug.WriteLine("Going to send message <" + title + ": " + value + ">.");
            return communicator.Send(rawMessage);
        }

        /// <summary>
        /// Sends a logic value to the connected EV3.
        /// </summary>
        /// <param name="title">The title of the message.
        ///                     The length of the title may be atmost 254 characters.</param>
        /// <param name="value">The value of the message.</param>
        /// <returns>True if the message was send, false otherwise.</returns>
        public bool SendMessage(string title, bool value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (title.Length > 254)
            {
                throw new ArgumentException("title", "The title may be at most 254 characters long.");
            }

            byte[] rawMessage = RawMessage.Create(title, value);
            Debug.WriteLine("Going to send message <" + title + ": " + value + ">.");
            return communicator.Send(rawMessage);
        }

        /// <summary>
        /// Reads a message from the connected EV3. 
        /// </summary>
        /// <returns>The read message or null if no message is available.
        /// </returns>
        public EV3Message ReadMessage()
        {
            Payload payload = communicator.GetNextReadPayload();
            if (payload != null)
            {
                return new EV3Message(payload);
            }
            return null;
        }
    }
}
