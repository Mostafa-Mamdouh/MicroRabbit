using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{


    public static class Program
    {
        public delegate void PrintMessage(string text);

        public static void WriteText(string text) => Console.WriteLine($"Text: {text}");

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static void ReverseWriteText(string text) => Console.WriteLine($"Text in reverse: {Reverse(text)}");
        public static string ReverseText(string text) => Reverse(text);


        delegate T Print<T>(T param1);

        public static void Main(string[] args)
        {
            // Delegate is a function pointer or more coscisly is a refrence to a function

            var delegate1 = new PrintMessage(WriteText);
            PrintMessage delegate2 = WriteText;
            PrintMessage delegate3 = delegate (string text)
            { Console.WriteLine($"Text: {text}"); };

            PrintMessage delegate4 = text =>
            { Console.WriteLine($"Text: {text}"); };

            delegate1.Invoke("Go ahead , Make my day");

            // Multicasting Delegates
            var delegate5 = new PrintMessage(ReverseWriteText);

            // var multicastDelegate = delegate1 + delegate5;
            var multicastDelegate = delegate1;
            multicastDelegate += delegate5;

            multicastDelegate("Go ahead , Make my day");

            // Generic Delegates
            Print<string> delegate6 = new Print<string>(ReverseText);
            Console.WriteLine(delegate6("I'll be back."));

            // Action<T> and Func<T> Delegates
            Action<string> executeReverseWrite = ReverseWriteText;
            executeReverseWrite("Are you not entertained?");

            Func<string, string> executeReverse = ReverseText;
            Console.WriteLine(executeReverse("Are you not entertained?"));


            var stringList = new List<string>();
            stringList.Where(x => x.Contains("some text"));

            Console.ReadLine();

        }

    }
}
