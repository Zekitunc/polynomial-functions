using System;
using System.Collections.Generic;
namespace Polynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input points in x y representation.");
            Console.WriteLine("Type END to finish.");
            int count = 1;
            string[] xinput = new string[4];
            string[] yinput = new string[4];
            while (true) //we will split the x and y
            {
                Console.Write("P#" + count + ": ");
                string input = Console.ReadLine();
                bool space = false;
                if (input == "END")
                {
                    count--;
                    break;
                }
                else
                    foreach(char x in input)
                    {
                        if (x == ' ')
                            space = true;
                        else if (x != ' ')
                        {
                            if (space)
                                yinput[count - 1] += x;
                            else
                                xinput[count - 1] += x;
                        }
                    }
                count++;   
            }
            Console.WriteLine("Resulting polynomial will be of the order "+(count-1));

            float[] result =Matrixsolverclass.Vandermonde(xinput, yinput, count);
            Console.WriteLine("calculated polynomial:");
            if(count==1)
            {
                Console.WriteLine("f(x) = {0} ",result[0]);
            }
            else if (count == 2)
            {
                Console.WriteLine("f(x) = {0}x^1 + {1} ", result[0], result[1]);
            }
            else if (count == 3)
            {
                Console.WriteLine("f(x) = {0}x^2 + {1}x^1 + {2} ", result[0], result[1], result[2]);
            }
            Console.WriteLine("f(-1) = "+ Function.getvalueof(-1, result));
            Console.WriteLine("f(0) = " + Function.getvalueof(0, result));
            Console.WriteLine("f(1) = " + Function.getvalueof(1, result));
        }
    }
}
