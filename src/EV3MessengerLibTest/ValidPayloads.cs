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

namespace EV3MessengerLibTest
{
    public class ValidPayloads
    {
        /// <summary>
        /// Test payload containing title "ping" and text value "hello"
        /// </summary>
        public static readonly byte[] payloadWithTitlePingAndTextValueHello = { 0x12, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x05, 0x70, 0x69, 0x6E, 0x67, 0x00, 0x06, 0x00, 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 };

        /// <summary>
        /// Test payload containing title "ping" and number value '19'
        /// </summary>
        public static readonly byte[] payloadWithTitlePingAndNumberValue19 = { 0x10, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x05, 0x70, 0x69, 0x6E, 0x67, 0x00, 0x04, 0x00, 0x00, 0x00, 0x98, 0x41 };

        /// <summary>
        /// Test payload containing title "ping" and logic value 'true'
        /// </summary>
        public static readonly byte[] payloadWithTitlePingAndLogicValueTrue = { 0x0D, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x05, 0x70, 0x69, 0x6E, 0x67, 0x00, 0x01, 0x00, 0x01 };

        /// <summary>
        /// Test payload containing title "ping" and logic value 'false'
        /// </summary>
        public static readonly byte[] payloadWithTitlePingAndLogicValueFalse = { 0x0D, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x05, 0x70, 0x69, 0x6E, 0x67, 0x00, 0x01, 0x00, 0x00 };

        /// <summary>
        /// Test payload containing title "" and text value "Hello"
        /// </summary>
        public static readonly byte[] payloadWithEmptyTitleAndTextValueHello = { 0x0E, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x01, 0x00, 0x06, 0x00, 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 };

        /// <summary>
        /// Test payload containing title "ping" and text value ""
        /// </summary>
        public static readonly byte[] payloadWithTitlePingAndEmptyTextValue = { 0x0D, 0x00, 0x01, 0x00, 0x81, 0x9E, 0x05, 0x70, 0x69, 0x6E, 0x67, 0x00, 0x01, 0x00, 0x00 };
    }
}
