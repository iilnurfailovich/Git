﻿﻿using System;
using System.Collections.Generic;

namespace PalindromeCheck
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            switch (args[0])
            {
                case("PalindromeCheckWithoutSymbol"):
                    PalindromeCheckWithoutSymbol();
                    break;
                case("PalindromeCheckWithSymbol"):
                    PalindromeCheckWithSymbol();
                    break;
                default:
                    throw new Exception("");
            }
        }

        private static void PalindromeCheckWithoutSymbol()
        {
            Console.WriteLine("Введите фразу");

            var arr = Console.ReadLine()?.ToLower().ToCharArray();
            if (arr != null)
            {
                var arr1 = new char[arr.Length];
                var count = 0;
                for (var i = arr.Length - 1; i >= 0; i--)
                { 
                    arr1[count]  = arr[i];
                    count++;
                }
            
            
                var txt1 = new string(arr);
                var txt2 = new string(arr1);

                Console.WriteLine(Equals(txt1, txt2) ? 
                    "Дання фраза является палиндтомом" : 
                    "Дання фраза не является палиндтомом");
            }

            else PalindromeCheckWithoutSymbol();
        }

        private static void PalindromeCheckWithSymbol()
        {
            Console.WriteLine("Введите фразу");

            var ar = Console.ReadLine()?.ToLower().ToCharArray();
            var ar1 = new List<char>();

            if (ar != null)
            {
                foreach (var t in ar)
                {
                    if (char.IsLetter(t) || char.IsDigit(t))
                    {
                        ar1.Add(t);
                    }
                }

                var ar2 = new List<char>();
            
                for (var i = ar1.Count - 1; i >= 0; i--)
                    ar2.Add(ar1[i]);
            
                var tx1 = new string(ar1.ToArray());
                var tx2 = new string(ar2.ToArray());
            
                Console.WriteLine(Equals(tx1, tx2) ? 
                    "Данная фраза является палиндромом" : 
                    "Данная фраза не является палинромом");
            }

            else PalindromeCheckWithSymbol();
        }
    }
}

