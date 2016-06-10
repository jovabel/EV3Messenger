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
    public class ArrayHelperTest
    {
        [TestMethod]
        public void TestConcatenationOfArrayWith1ElmAndArrayWith2Elms()
        {
            byte[] array1 = { 1 };
            byte[] array2 = { 2, 3 };
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
            byte[] expectedResult = { 1, 2, 3 };
            Assert.IsTrue(concat.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestConcatenationOfArrayWith2ElmsAndArrayWith1Elm()
        {
            byte[] array1 = { 1, 2 };
            byte[] array2 = { 3 };
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
            byte[] expectedResult = { 1, 2, 3 };
            Assert.IsTrue(concat.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestConcatenationOfArrayWith1ElmAndEmptyArray()
        {
            byte[] array1 = { 1 };
            byte[] array2 = { };
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
            byte[] expectedResult = { 1 };
            Assert.IsTrue(concat.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestConcatenationOfEmptyArrayAndArrayWith1Elm()
        {
            byte[] array1 = { };
            byte[] array2 = { 1 };
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
            byte[] expectedResult = { 1 };
            Assert.IsTrue(concat.SequenceEqual(expectedResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConcatenationOfNullArrayAndArrayWith1Elm()
        {
            byte[] array1 = null;
            byte[] array2 = { 1 };
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConcatenationOfArrayWith1ElmAndNullArray()
        {
            byte[] array1 = { 1 };
            byte[] array2 = null;
            byte[] concat = ArrayHelper.Concatenate(array1, array2);
        }

        [TestMethod]
        public void TestIndexOfWithMatchAtBeginningAndSizes1()
        {
            byte[] sequence = { 1 };
            byte[] arrayToSearch = { 1 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void TestIndexOfWithoutMatchAndSizes1()
        {
            byte[] sequence = { 1 };
            byte[] arrayToSearch = { 2 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void TestIndexOfWithMatchAtBeginningAndSizes2()
        {
            byte[] sequence = { 1, 2 };
            byte[] arrayToSearch = { 1, 2 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void TestIndexOfWithoutMatchAndSizes2()
        {
            byte[] sequence = { 1, 2 };
            byte[] arrayToSearch = { 1, 3 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(-1, index);
        }


        [TestMethod]
        public void TestIndexOfWithMatchAtBeginning()
        {
            byte[] sequence = { 1, 2 };
            byte[] arrayToSearch = { 1, 2, 3 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void TestIndexOfWithMatchAtTheEnd()
        {
            byte[] sequence = { 2, 3 };
            byte[] arrayToSearch = { 1, 2, 3 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void TestIndexOfDoesNotFindSequenceWhenSearchArrayIsEmpty()
        {
            byte[] sequence = { 1 };
            byte[] arrayToSearch = { };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void TestIndexOfDoesNotFindSequenceWhenSearchArrayIsTooShort()
        {
            byte[] sequence = { 1, 2 };
            byte[] arrayToSearch = { 1 };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void TestIndexOfMatchesEmptySequenceAtIndexZero()
        {
            byte[] sequence = { };
            byte[] arrayToSearch = { };
            int index = ArrayHelper.IndexOf(sequence, arrayToSearch);
            Assert.AreEqual(0, index);
        }


        [TestMethod]
        public void TestRemoveZeroElmsFormArrayOfSize4()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, 0);
            byte[] expectedResult = { 1, 2, 3, 4 };
            Assert.IsTrue(remove.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestRemoveFirst2ElmsFormArrayOfSize4()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, 2);
            byte[] expectedResult = { 3, 4 };
            Assert.IsTrue(remove.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestRemoveFirst3ElmsFormArrayOfSize4()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, 3);
            byte[] expectedResult = { 4 };
            Assert.IsTrue(remove.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestRemoveFirst4ElmsFormArrayOfSize4()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, 4);
            byte[] expectedResult = { };
            Assert.IsTrue(remove.SequenceEqual(expectedResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveFirst5ElmsFormArrayOfSize4ThrowsException()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveUntilNegativeIndexThrowsException()
        {
            byte[] array = { 1, 2, 3, 4 };
            byte[] remove = ArrayHelper.Remove(array, -1);
        }
    }
}
