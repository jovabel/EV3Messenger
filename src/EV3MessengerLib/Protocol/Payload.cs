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
    /// <summary>
    /// The parsed payload from the EV3 Bluetooth (raw) message.
    /// See the FieldInfo class for the format of the message.
    /// </summary>
    internal class Payload
    {
        /// <summary>
        /// The title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The value. 
        /// The value can be parsed to EV3 formats like text, number and logic 
        /// using the ValueConverter class.
        /// </summary>
        public byte[] Value { get; private set; }

        /// <summary>
        /// Creates a new  instance of the Payload class.
        /// Used for storing the title and value from EV3 bleutooth messages.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public Payload(string title, byte[] value)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Title = title;
            Value = value;
        }
    }
}
