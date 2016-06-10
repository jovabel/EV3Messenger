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

namespace EV3MessengerLib.Protocol
{
    internal class RawMessage
    {
        public static byte[] Create(string title, string value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            byte[] titleField = Encoding.ASCII.GetBytes(title + '\0');
            byte[] valueField = Encoding.ASCII.GetBytes(value + '\0');
            return Create(titleField, valueField);
        }

        public static byte[] Create(string title, float value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            byte[] titleField = Encoding.ASCII.GetBytes(title + '\0');
            byte[] valueField = BitConverter.GetBytes(value);
            return Create(titleField, valueField);
        }

        public static byte[] Create(string title, bool value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            byte[] titleField = Encoding.ASCII.GetBytes(title + '\0');
            byte[] valueField = BitConverter.GetBytes(value);
            return Create(titleField, valueField);
        }

        private static byte[] Create(byte[] titleField, byte[] valueField)
        {
            if (titleField == null)
            {
                throw new ArgumentNullException("titleField");
            }

            if (valueField == null)
            {
                throw new ArgumentNullException("valueField");
            }

            if (titleField.Length > Byte.MaxValue)
            {
                throw new ArgumentException("titleField", "Size is too large (length > Byte.MaxValue)");
            }

            if (valueField.Length > UInt16.MaxValue)
            {
                throw new ArgumentException("valueField", "Size is too large (length > UInt16.MaxValue)");
            }

            // Compute contents of the size fields
            byte titleSizeField = (byte)(titleField.Length);
            byte[] valueSizeField = BitConverter.GetBytes((UInt16)(valueField.Length));
            UInt16 payloadSize = (UInt16)(FieldInfo.SecretHeader.Length
                                  + 1 + titleField.Length
                                  + valueSizeField.Length + valueField.Length);
            byte[] payloadSizeField = BitConverter.GetBytes(payloadSize);

            // Create raw message
            int rawMessageSize = 2 + payloadSize;
            List<byte> rawMessage = new List<byte>(rawMessageSize);
            rawMessage.AddRange(payloadSizeField);
            rawMessage.AddRange(FieldInfo.SecretHeader);
            rawMessage.Add(titleSizeField);
            rawMessage.AddRange(titleField);
            rawMessage.AddRange(valueSizeField);
            rawMessage.AddRange(valueField);

            return rawMessage.ToArray();
        }
    }
}
