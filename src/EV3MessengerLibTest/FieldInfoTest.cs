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
    public class FieldInfoTest
    {
        [TestMethod]
        public void TestPayloadSizeIndex()
        {
            Assert.AreEqual(0, FieldInfo.PayloadSizeIndex);
        }

        [TestMethod]
        public void TestSecretHeaderIndex()
        {
            Assert.AreEqual(2, FieldInfo.SecretHeaderIndex);
        }

        [TestMethod]
        public void TestTitleSizeIndex()
        {
            Assert.AreEqual(6, FieldInfo.TitleSizeIndex);
        }

        [TestMethod]
        public void TestTitleIndex()
        {
            Assert.AreEqual(7, FieldInfo.TitleIndex);
        }

        [TestMethod]
        public void TestValueSizeIndex()
        {
            Assert.AreEqual(12, FieldInfo.ValueSizeIndex(5));
        }

        [TestMethod]
        public void TestValueIndex()
        {
            Assert.AreEqual(14, FieldInfo.ValueIndex(5));
        }
    }
}
