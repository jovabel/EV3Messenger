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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EV3MessengerLib.Protocol;

namespace EV3MessengerLibTest
{
    [TestClass]
    public class RawMessageTest
    {
        [TestMethod]
        public void TestCreationOfMessageWithTitlePingAndTextValueHello()
        {
            byte[] rawMessage = RawMessage.Create("ping", "hello");
            CollectionAssert.AreEqual(ValidPayloads.payloadWithTitlePingAndTextValueHello, rawMessage);
        }

        [TestMethod]
        public void TestCreationOfMessageWithEmptyTitleAndTextValueHello()
        {
            byte[] rawMessage = RawMessage.Create("", "hello");
            CollectionAssert.AreEqual(ValidPayloads.payloadWithEmptyTitleAndTextValueHello, rawMessage);
        }

        [TestMethod]
        public void TestCreationOfMessageWithTitlePingAndEmptyTextValue()
        {
            byte[] rawMessage = RawMessage.Create("ping", "");
            CollectionAssert.AreEqual(ValidPayloads.payloadWithTitlePingAndEmptyTextValue, rawMessage);
        }

        [TestMethod]
        public void TestCreationOfMessageWithTitlePingAndLogicValueFalse()
        {
            byte[] rawMessage = RawMessage.Create("ping", false);
            CollectionAssert.AreEqual(ValidPayloads.payloadWithTitlePingAndLogicValueFalse, rawMessage);
        }

        [TestMethod]
        public void TestCreationOfMessageWithTitlePingAndLogicValueTrue()
        {
            byte[] rawMessage = RawMessage.Create("ping", true);
            CollectionAssert.AreEqual(ValidPayloads.payloadWithTitlePingAndLogicValueTrue, rawMessage);
        }

        [TestMethod]
        public void TestCreationOfMessageWithTitlePingAndNumberValue19()
        {
            byte[] rawMessage = RawMessage.Create("ping", 19.0F);
            CollectionAssert.AreEqual(ValidPayloads.payloadWithTitlePingAndNumberValue19, rawMessage);
        } 
    }
}
