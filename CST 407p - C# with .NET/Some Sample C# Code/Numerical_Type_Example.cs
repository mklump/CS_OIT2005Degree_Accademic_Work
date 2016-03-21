/*
The float data type

float data type is the first of 3 data types that can store floating point numbers and actually this is the smallest of the 3 types. float variables store floating point numbers from 1.5 times 10 to the 45 th (±1.5 × 10-45 ) to 3.4 times 10 to the 38 th (±3.4 × 1038 ) in 32 bit. And this type has a precision to 7 numbers.


The double data type

double data type variables can store floating point numbers from 5 times 10 to the 324 th (±5.0 × 10-324 ) to 1.7 times 10 the 308 th (±1.7 × 10308 ) in 64-bit. And this type has a precision to 15-16 numbers.


The decimal data type

decimal data type variables can store 1 times 10 to the 28th 1.0 × 10-28 and 7.9 times 10 to the 28 th 7.9 × 1028 in 128 bit. If you think about this type you will note that it has a greater precision and a smaller range and that’s we exactly needs for financial calculations also note that decimal data type has a Precision of 28-29 significant digits.


Why we have 3 floating point data types?

To answer this question I will write the simple next C# application:
*/
 

using System;

namespace ConsoleApplication2

{

    class Class1

    {

        static void Main(string[] args)

        {

            float x = 1232.34217F * 1232.34217F;

            double y = 1232.34217D * 1232.34217D;

            decimal z = 1232.34217M * 1232.34217M;

            Console.WriteLine("The float variable x = {0}", x);

            Console.WriteLine("The float variable y = {0}", y);

            Console.WriteLine("The float variable z = {0}", z);

            Console.ReadLine();

        }

    }

}
