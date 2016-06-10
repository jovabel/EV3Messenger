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
using System.Diagnostics;

namespace EV3MessengerLib.Protocol
{
    /// <summary>
    /// Parser that looks for EV3 Bluetooth (raw) messages in a byte buffer
    /// and parses the found messages to payload objects.
    /// 
    /// The format of raw EV3 bt message can be found in the description of the FieldInfo class.
    /// 
    /// ... And yes, this class throws exceptions from non public members that are called with 
    ///     invalid parameters :-)
    /// </summary>
    internal class PayloadParser
    {
        /// <summary>
        /// Buffer used to store data which is searched for a payload.
        /// TODO: Rewrite using MemoryStream or List with bytes for better performance?
        /// </summary>
        private byte[] dataToParse;

        /// <summary>
        /// Creates a new  instance of the PayloadParser class.
        /// </summary>
        public PayloadParser()
        {
            dataToParse = new byte[0];
        }

        /// <summary>
        /// Append data to the internal buffer wich is used to search for payloads.
        /// </summary>
        /// <param name="data"></param>
        public void AppendData(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (data.Length != 0)
            {
                dataToParse = ArrayHelper.Concatenate(dataToParse, data);
            }
        }

        /// <summary>
        /// Find a payload in the buffered data.
        /// The payload is removed from the buffer when returned.
        /// </summary>
        /// <returns>A payload if found, null otherwise.</returns>
        public Payload FindAndRemoveNextPayload()
        {
            int startIndexOfPayload = FindStartIndexOfPayload(dataToParse);
            if (startIndexOfPayload != -1
                && dataToParse.Length >= startIndexOfPayload + 2)
            {
                int payloadSize = BitConverter.ToUInt16(dataToParse, startIndexOfPayload);
                int endIndexOfPayload = startIndexOfPayload + 2 + payloadSize;

                if (dataToParse.Length >= endIndexOfPayload)
                {
                    // All bytes of the payload seem to be present in the buffer, parse it.
                    int titleSize = GetTitleSize(dataToParse, startIndexOfPayload);
                    int valueSize = GetValueSize(dataToParse, startIndexOfPayload, titleSize);

                    if (titleSize != -1 
                        && valueSize != -1
                        && SizesMatch(payloadSize, titleSize, valueSize)) // sanity check of sizes
                    {
                        string title = ParseTitle(dataToParse, startIndexOfPayload);
                        byte[] value = ParseValue(dataToParse, startIndexOfPayload);

                        if (title != null && value != null)
                        {
                            dataToParse = ArrayHelper.Remove(dataToParse, endIndexOfPayload);
                            return new Payload(title, value);
                        }
                    }

                    // All bytes of the payload seem to be present, but the sizes of the title and value fields 
                    // do not match the payload size.
                    // The payload that follows the found header is invalid, drop it from the buffer until the header
                    dataToParse = ArrayHelper.Remove(dataToParse, startIndexOfPayload + FieldInfo.TitleSizeIndex);
                }
            }
            else
            {
                // Empty the buffer. It did not contain the start of a payload yet.
                ClearData();
            }
            return null;
        }

        /// <summary>
        /// Get the title from the payload that starts at a given index in a bytebuffer.
        /// </summary>
        /// <param name="data">The buffer to read the title from.</param>
        /// <param name="startIndexOfPayload">The start index of the payload.</param>
        /// <returns>Returns null if TitleSize or Title fields could not be parsed. </returns>
        private static string ParseTitle(byte[] data, int startIndexOfPayload)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (startIndexOfPayload < 0)
            {
                throw new ArgumentOutOfRangeException("startIndexOfPayload");
            }

            int titleSize = GetTitleSize(data, startIndexOfPayload);
            if (titleSize != -1)
            {
                int titleIndex = startIndexOfPayload + FieldInfo.TitleIndex;
                if (data.Length > titleIndex + titleSize - 1)
                {
                    string title = ASCIIEncoding.ASCII.GetString(data, titleIndex, titleSize - 1);
                    // Note: The last char in the title of the payload is always '\0'
                    // the -1 removes this char.
                    return title;
                }
            }
            Debug.WriteLine("ParseTitle: Unexpected length");
            return null;
        }

        private static int GetTitleSize(byte[] data, int startIndexOfPayload)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (startIndexOfPayload < 0)
            {
                throw new ArgumentOutOfRangeException("startIndexOfPayload");
            }

            int titleSizeIndex = startIndexOfPayload + FieldInfo.TitleSizeIndex;
            if (data.Length > titleSizeIndex)
            {
                int titleSize = data[titleSizeIndex];
                return titleSize;
            }
            return -1;
        }

        /// <summary>
        /// Get the value from the payload that starts at a given index in a bytebuffer.
        /// </summary>
        /// <param name="data">The buffer to read the value from.</param>
        /// <param name="startIndexOfPayload">The start index of the payload.</param>
        /// <returns>Returns null if ValueSize or Value fields could not be parsed. </returns>
        private static byte[] ParseValue(byte[] data, int startIndexOfPayload)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (startIndexOfPayload < 0)
            {
                throw new ArgumentOutOfRangeException("startIndexOfPayload");
            }

            int titleSize = GetTitleSize(data, startIndexOfPayload);
            if (titleSize != -1)
            {
                int valueSize = GetValueSize(data, startIndexOfPayload, titleSize);
                if (valueSize != -1)
                {
                    int valueIndex = startIndexOfPayload + FieldInfo.ValueIndex(titleSize);
                    if (data.Length > valueIndex + valueSize - 1)
                    {
                        byte[] value = new byte[valueSize];
                        Array.Copy(data, valueIndex, value, 0, valueSize);
                        return value;
                    }
                }
            }
            Debug.WriteLine("ParseTitle: Unexpected length");
            return null;
        }

        private static int GetValueSize(byte[] data, int startIndexOfPayload, int titleSize)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (startIndexOfPayload < 0)
            {
                throw new ArgumentOutOfRangeException("startIndexOfPayload");
            }

            if (titleSize < 0)
            {
                throw new ArgumentOutOfRangeException("titleSize");
            }

            int valueSizeIndex = startIndexOfPayload + FieldInfo.ValueSizeIndex(titleSize);
            if (data.Length > valueSizeIndex + 1)
            {
                int valueSize = BitConverter.ToUInt16(data, valueSizeIndex);
                return valueSize;
            }
            return -1;
        }

        private static bool SizesMatch(int payloadSize, int titleSize, int valueSize)
        {
            if (payloadSize < 0)
            {
                throw new ArgumentOutOfRangeException("payloadSize");
            }

            if (titleSize < 0)
            {
                throw new ArgumentOutOfRangeException("titleSize");
            }

            if (valueSize < 0)
            {
                throw new ArgumentOutOfRangeException("valueSize");
            }

            return payloadSize == (1 + titleSize + 2 + valueSize + FieldInfo.SecretHeader.Length);
        }

        /// <summary>
        /// Find the start index of a payload.
        /// See FieldInfo for info about the fields in the payload.
        /// </summary>
        /// <param name="data">The buffer to seek in.</param>
        /// <returns>The index where the payload starts, or -1 if not found.</returns>
        private static int FindStartIndexOfPayload(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            int secretHeaderIndex = ArrayHelper.IndexOf(FieldInfo.SecretHeader, data);
            if (secretHeaderIndex != -1 && secretHeaderIndex >= FieldInfo.SecretHeaderIndex)
            {
                int startIndexOfPayload = secretHeaderIndex - 2;
                return startIndexOfPayload;
            }
            return -1;
        }

        /// <summary>
        /// Removes all data from the buffer.
        /// </summary>
        public void ClearData()
        {
            dataToParse = new byte[0];
        }
    }
}
