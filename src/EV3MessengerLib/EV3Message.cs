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
using EV3MessengerLib.Protocol;

namespace EV3MessengerLib
{
    /// <summary>
    /// A message received from the Lego Mindstorms EV3 robot.
    /// 
    /// Each message has a mailbox title and a value property. 
    /// The value can be of the type Text, Number or Logic.
    /// 
    /// Please keep in mind that you cannot determine the type of the received value.
    /// The rule is: what you send is what you get. 
    /// (actually, this is not different from using the message blocks in the EV3 
    /// programming environment from Lego)
    /// 
    /// If you send a Number, then at the receiving side, 
    /// get the value as a number using the ValueAsNumber property of the message.
    /// </summary>
    public class EV3Message
    {
        private Payload payload;

        /// <summary>
        /// The mailbox title of this message.
        /// </summary>
        public string MailboxTitle
        {
            get
            {
                return payload.Title;
            }
        }

        /// <summary>
        /// The value interpreted as text.
        /// </summary>
        public string ValueAsText
        {
            get
            {
                string value;
                ValueConverter.TryParse(payload.Value, out value);
                return value;
            }
        }

        /// <summary>
        /// The value interpreted as a number.
        /// The EV3 uses single precision floating point numbers internally.
        /// </summary>
        public float ValueAsNumber
        {
            get
            {
                float value;
                ValueConverter.TryParse(payload.Value, out value);
                return value;
            }
        }

        /// <summary>
        /// The value interpreted as logic value.
        /// </summary>
        public bool ValueAsLogic
        {
            get
            {
                bool value;
                ValueConverter.TryParse(payload.Value, out value);
                return value;
            }
        }

        /// <summary>
        /// Creates a message from a payload.
        /// (facade: hides complexity of the underlying protocol)
        /// </summary>
        /// <param name="payload"></param>
        internal EV3Message(Payload payload)
        {
            this.payload = payload;
        }

        /// <summary>
        /// Returns a debug string.
        /// </summary>
        /// <returns>Returns a debug string.</returns>
        public override string ToString()
        {
            string textValue = ValueAsText;
            if (ContainsControlCharacters(textValue))
            {
                textValue = "";
            }

            return "Title: " + MailboxTitle + ", Text: " + textValue + ", Number: " + ValueAsNumber + ", Logic: " + ValueAsLogic;
        }

        private static bool ContainsControlCharacters(string text)
        {
            if (text != null)
            {
                foreach (char c in text)
                {
                    if (Char.IsControl(c))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
