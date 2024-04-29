using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._11._23_practice
{
    internal class Program
    {
        class substringPalindrome
        {
            public static bool isPalindrome(string text)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != text[text.Length - i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
            static void Main(string[] args)
            {
                string text = Console.ReadLine();
                int max_length = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (isPalindrome(text.Substring(i, j - i - 1)))
                        {
                            if (max_length < j - i)
                            {
                                max_length = j - i;
                            }
                        }
                    }
                }

                Console.WriteLine($"Длина наибольшей подстроки-палиндрома: {max_length}");
            }
        }
    }
}
