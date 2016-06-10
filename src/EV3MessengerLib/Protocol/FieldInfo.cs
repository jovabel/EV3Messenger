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
    /// Information on the fields that are contained within the payload of 
    /// an EV3 bluetooth message.
    /// 
    /// Each EV3 message contains a Title (mailbox title) and a Value.
    /// 
    /// Example payload (actually captured from an EV3)
    /// -----------------------------------------------          
    ///            
    ///                 Field names:
    ///                 -------------
    /// Byte:  0  0x12  PayloadSize : Byte 0 and 1 contain the size (bytes) of the payload.
    ///        1  0x00                The size counting starts at byte 2. Here: 00 12 (hex) = 18 (dec)
    ///        -------
    ///        2  0x01  SecretHeader: Byte 2..5 contain a header (just a guess)
    ///        3  0x00                The contents are unknown, but every message has these values here.
    ///        4  0x81                 
    ///        5  0x9E
    ///        -------
    ///        6  0x05  TitleSize   : Byte 6 contains the size (bytes) of the Title field, which follows.
    ///        -------
    ///        7  0x70  Title       : The title text string (ascii). Here: "ping"
    ///        8  0x69                The last character is always 0x00.
    ///        9  0x6E               
    ///       10  0x67
    ///       11  0x00
    ///       --------
    ///       12  0x06  ValueSize   : Byte (6 + TitleSize + 1) contains the size (bytes) of the Value field which follows.
    ///       13  0x00                Here: 00 06 (hex) = 6 (dec)
    ///       --------
    ///       14  0x68  Value       : The value. Here the text: "hello"
    ///       15  0x65                The value field can contain:
    ///       16  0x6C                - Text (length: variable, ends with 0x00) ---> string                 
    ///       17  0x6C                - Number (length: 4 bytes)                ---> float (Single)
    ///       18  0x6F                - Logic (length: 1 byte)                  ---> bool
    ///       19  0x00
    ///       
    /// </summary>
    internal static class FieldInfo
    {
        /// <summary>
        /// The contents of the secret header (secret as in 'I dont know whats in it,
        /// but all payloads have it)
        /// The header is the only thing I can recognize the start of a payload with.
        /// 
        /// TODO: What are the values in this sequence? Are they the same on every EV3?
        /// </summary>
        public static readonly byte[] SecretHeader = { 0x01, 0x00, 0x81, 0x9E };

        /// <summary>
        /// The index of the PayloadSize field.
        /// This field contains 2 bytes stating the size (bytes)
        /// of the payload. The size count starts AFTER these 2 bytes.
        /// </summary>
        public static int PayloadSizeIndex { get { return 0; } }

        /// <summary>
        /// The index of the secret header.
        /// </summary>
        public static int SecretHeaderIndex { get { return 2; } }

        /// <summary>
        /// The index of the TitleSize field.
        /// This field contains 2 bytes stating the size (bytes) of the Title field.
        /// </summary>
        public static int TitleSizeIndex { get { return 6; } }

        /// <summary>
        /// The index of the Title field.
        /// The Title field contains the title of a message.
        /// It always ends with 0x00.
        /// </summary>
        public static int TitleIndex { get { return 7; } }

        /// <summary>
        /// The index of the ValueSize field. Depends on the size of the title.
        /// </summary>
        /// <param name="titleSize"></param>
        /// <returns></returns>
        public static int ValueSizeIndex(int titleSize)
        {
            return 1 + TitleSizeIndex + titleSize;
        }

        /// <summary>
        /// The index of the Value field. Depends on the size of the title.
        /// </summary>
        /// <param name="titleSize"></param>
        /// <returns></returns>
        public static int ValueIndex(int titleSize)
        {
            return ValueSizeIndex(titleSize) + 2;
        }
    }
}
