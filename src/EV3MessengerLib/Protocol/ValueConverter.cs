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
    /// Contains methods to parse the value field of the payload
    /// to the desired EV3 format (text, number, logic),
    /// </summary>
    internal static class ValueConverter
    {
        public static bool TryParse(byte[] value, out string text)
        {
            if (value != null && value.Length > 0)
            {
                text = ASCIIEncoding.ASCII.GetString(value, 0, value.Length - 1);
                return true;
            }
            else
            {
                text = null;
                return false;
            }

        }

        public static bool TryParse(byte[] value, out float number)
        {
            if (value != null && value.Length == 4)
            {
                number = BitConverter.ToSingle(value, 0);
                return true;
            }
            else
            {
                number = 0.0F;
                return false;
            }
        }

        public static bool TryParse(byte[] value, out bool logic)
        {
            if (value != null && value.Length == 1)
            {
                logic = BitConverter.ToBoolean(value, 0);
                return true;
            }
            else
            {
                logic = false;
                return false;
            }
        }
    }
}
