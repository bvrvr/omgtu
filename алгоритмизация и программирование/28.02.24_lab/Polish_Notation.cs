using System;
using System.Collections.Generic;

namespace Polish_Notation
{
    internal class Polish_Notation
    {
        static void Main(string[] args)
        {
            string expression = "5 6 * 9 +";
            Console.WriteLine("Результат: " + Calculate(expression));
        }

        static int Calculate(string expression)
        {
            Stack<int> stack = new Stack<int>();
            string[] tokens = expression.Split(' ');

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            if (operand2 == 0)
                            {
                                throw new ArgumentException("Попытка деления на ноль");
                            }
                            stack.Push(operand1 / operand2);
                            break;
                        default:
                            throw new ArgumentException($"Недопустимый оператор: {token}");
                    }
                }
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Неверное выражение");
            }

            return stack.Pop();
        }
    }
}