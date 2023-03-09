using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    class Program
    {
        private static bool CheckBrackets(string input)
        {
            Stack<char> bracktes = new Stack<char>();
            Dictionary<char, char> bracketsPair = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' }
            };

            foreach (var mark in input)
            {
                if (bracketsPair.Keys.Contains(mark))
                    bracktes.Push(mark);
                else if (bracketsPair.Values.Contains(mark))
                {
                    if (bracktes.Any() && mark == bracketsPair[bracktes.First()])
                        bracktes.Pop();
                    else
                        return false;
                }
            }
 
            return !bracktes.Any();
        }
        
        private static void Fib(int n)
        {
            int a = 0, b = 1, c = 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(c);
                c = a + b;
                a = b; b = c;
            }
        }

        private static void RenderDiamonsSides(int row, int n)
        {
            //left side
            for (int column = n; column >= 1; column--)
                if (column > row)
                    Console.Write("-");
                else
                    Console.Write(column);

            //right side
            for (int j = 2; j <= n; j++)
                if (j > row)
                    Console.Write("-");
                else
                    Console.Write(j);

            Console.WriteLine("\n");
        }
        
        private static void Diamond(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                RenderDiamonsSides(i, n);
            }
            
            for (int i = n - 1; i >= 1; i--)
            {
                RenderDiamonsSides(i, n);
            }
        }
        
        private static bool CheckIfPalindrome(string input)
        {
            var exprs = input.Trim().ToLowerInvariant().Replace(" ", "");
            return exprs.SequenceEqual(exprs.Reverse());
        }

        static void Main(string[] args)
        {
            //Brackets
            Console.WriteLine("Podaj ciąg: ");
            string expression1 = Console.ReadLine();
            Console.WriteLine(CheckBrackets(expression1));


            //Fibonacci
            Console.WriteLine("Provide number to count Fibonacci string: ");
            if (Int32.TryParse(Console.ReadLine(), out var n1))
                Fib(n1);

            //Diamond
            Console.WriteLine("Provide number to count Diamond shape: ");
            if (Int32.TryParse(Console.ReadLine(), out var n2))
                Diamond(n2);

            //Palindrome
            Console.WriteLine("Provide input to check if it is a palindrome: ");
            string expression2 = Console.ReadLine();
            Console.WriteLine(CheckIfPalindrome(expression2));
        }
    }
}
