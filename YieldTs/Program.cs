using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YieldTs
{
    class Program
    {

        static void Main(string[] args)
        {
           /* foreach (var va in Power(2, 8, ""))
            {
                Console.WriteLine(va);
            }*/

            foreach (var va in Print(10)) ;
                
        }

        public static IEnumerable<int> Power(int number, int exponent, string s)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
            yield return 3;
            yield return 4;
            yield return 5;
        }

        public static IEnumerable<int> Print(int min)
        {
                yield return min;
                min += 1;
                Console.WriteLine(string.Format("开始第2次迭代，min={0}",min));

                yield return min;
                min += 1;
                Console.WriteLine(string.Format("开始第3次迭代，min={0}", min));

                yield return min;
                min += 1;
                Console.WriteLine(string.Format("开始第4次迭代，min={0}", min));

                yield return min;
                min += 1;
                Console.WriteLine(string.Format("开始第5次迭代，min={0}", min));
           
        }
    }
}
