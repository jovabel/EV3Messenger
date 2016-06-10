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
    public class PayloadParserTest
    {
        [TestMethod]
        public void TestParsePayload()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndTextValueHello);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParseBufferContainginTwoPayloads()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndTextValueHello);
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndEmptyTextValue);

            Payload payload = parser.FindAndRemoveNextPayload();
            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 }, payload.Value);

            payload = parser.FindAndRemoveNextPayload();
            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x00 }, payload.Value);

            payload = parser.FindAndRemoveNextPayload();
            Assert.AreEqual(null, payload);
        }

        [TestMethod]
        public void TestParsePayloadThatIsNotAtheStartOfTheBuffer()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(new byte[] { 0x00 });
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndTextValueHello);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParsePayloadWithEmptyTitle()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(ValidPayloads.payloadWithEmptyTitleAndTextValueHello);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParsePayloadWithEmptyTitleThatIsNotAtheStartOfTheBuffer()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(new byte[] { 0x00 });
            parser.AppendData(ValidPayloads.payloadWithEmptyTitleAndTextValueHello);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParsePayloadWithEmptyTextValue()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndEmptyTextValue);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParsePayloadWithEmptyTextValueThatIsNotAtheStartOfTheBuffer()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(new byte[] { 0x00 });
            parser.AppendData(ValidPayloads.payloadWithTitlePingAndEmptyTextValue);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual("ping", payload.Title);
            CollectionAssert.AreEqual(new byte[] { 0x00 }, payload.Value);
        }

        [TestMethod]
        public void TestParsePayloadWithMissingFirstByte()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(InvalidPayloads.payloadWithMissingFirstByte);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual(null, payload);
        }

        [TestMethod]
        public void TestParsePayloadWithMissingFirstByteAndAddedOtherByte()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(new byte[] { 0x00 });
            parser.AppendData(InvalidPayloads.payloadWithMissingFirstByte);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual(null, payload);
        }

        [TestMethod]
        public void TestParsePayloadWithMissingFirstTwoBytes()
        {
            PayloadParser parser = new PayloadParser();
            parser.AppendData(InvalidPayloads.payloadWithMissingFirstByte);
            Payload payload = parser.FindAndRemoveNextPayload();

            Assert.AreEqual(null, payload);
        }
    }
}
