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
    internal static class ArrayHelper
    {
        /// <summary>
        /// Concatenates 2 byte arrays.
        /// </summary>
        /// <param name="array1">Array to concatenate.</param>
        /// <param name="array2">Array to concatenate.</param>
        /// <returns>array1 + array2, if both array1 and array2 2 are not null.</returns>
        public static byte[] Concatenate(byte[] array1, byte[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException("array1");
            }

            if (array2 == null)
            {
                throw new ArgumentNullException("array2");
            }

            int newSize = array1.Length + array2.Length;
            byte[] newArray = new byte[newSize];
            Array.Copy(array1, newArray, array1.Length);
            Array.Copy(array2, 0, newArray, array1.Length, array2.Length);
            return newArray;
        }

        /// <summary>
        /// Removes all elements until (excluding) the given index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte[] Remove(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index == 0)
            {
                return array;
            }
            else
            {

                byte[] newArray = new byte[array.Length - index];
                Array.Copy(array, index, newArray, 0, array.Length - index);
                return newArray;
            }
        }

        /// <summary>
        /// Find a sequence of bytes in the given array.
        /// </summary>
        /// <param name="sequence">The sequence to find.</param>
        /// <param name="array">The array to search.</param>
        /// <returns>The index of the sequence or -1 if the sequence is not found.</returns>
        public static int IndexOf(byte[] sequence, byte[] array)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            // TODO: Naive approach, get better algoritm from literature?
            for (int i = 0; i < array.Length - sequence.Length + 1; i++)
            {
                bool match = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (array[i + j] != sequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
