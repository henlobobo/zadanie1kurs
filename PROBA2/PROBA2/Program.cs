using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace PROBA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplikacja konsolowa w C# - kalkulator");
            Console.WriteLine("Dzialanie jakie chcesz wykonac:");

            List<org.mariuszgromada.math.mxparser.Argument> ugabuga = new List<org.mariuszgromada.math.mxparser.Argument>();

            var running = true;
            while (running)
            {
                var input = Console.ReadLine();
                //string string1 = "arg";
                //string string2 = "calc";

                if (input.Contains("arg"))
                {
                    string[] inputuzyt = input.Split(" ");
                    var arg = new Argument(inputuzyt[1], inputuzyt[2]);
                    ugabuga.Add(arg);
                }

                if (input.Contains("calc"))
                {
                    string[] inputuzyt = input.Split(" ");

                    string[] tymczasowa = new string[inputuzyt.Length];

                    for (int i = inputuzyt.Length - 1; i >= 1; i--) tymczasowa[i - 1] = inputuzyt[i];

                    var liczenie = new Expression(string.Join(" ", tymczasowa));

                    for (int i = 0; ugabuga.ToArray().Length != 0; i++)
                    {
                        liczenie.addArguments(ugabuga[0]);
                        ugabuga.RemoveAt(0);
                    }

                    Console.WriteLine(liczenie.calculate());
                }
                if (input.Contains("help"))
                {
                    Console.WriteLine("Get some help :<");
                }
                if (input.Contains("exit"))
                {
                    running = false;
                }
            }
        }
    }
}