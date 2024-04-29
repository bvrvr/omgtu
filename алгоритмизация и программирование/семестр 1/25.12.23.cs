using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._12._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double maxd = 0;
            for (int i = 106732567; i <= 152673836; i++)
            {
                double sqri = Math.Sqrt(i);
                double numdel = 0;
                if (Math.Round(sqri) == sqri)
                {
                    maxd = 1;
                    for (int j = 2; j < Math.Round(sqri); j++)
                    {
                        if (i % j == 0)
                        {
                            if (maxd == 1)
                            {
                                maxd = i / j;
                                maxd = Math.Round(maxd);
                            }

                            numdel += 2;

                        }
                        if (numdel == 2) { Console.WriteLine($"{i} \t {maxd} "); }
                    }
                }
            }
        }
    }
}
