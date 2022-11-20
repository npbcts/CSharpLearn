using System;

namespace MyNewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "Microsoft Learn";

            // 下面是不同的namespace调用方法
            string reversedValue = MyNewApp.Utilities.Utility.Reverse(value);
            Console.WriteLine($"Secret message: {reversedValue}");

            // 下面是同类class中调用方法
            string addValue = AddStr(value);
            Console.WriteLine($"AddStr :{addValue}");

            // 下面是不同类调用
            string judgeResult = JudgeWord.JudgeWordInSentence(value, "Learn");
            Console.WriteLine($"JudgeWorld Class: {judgeResult}");
        }

        static string AddStr(string message)
        {
            message = message + ": change with method AddStr";
            return message;
        }
    }

    class JudgeWord
    {
        public static string JudgeWordInSentence(string message, string theword)
        {
            string containResult = "";
            if (message.Contains(theword))
                containResult = "is";
            else
                containResult = "is not";
            return $"sentence {containResult} contains word {theword}";
        }
    }
}

namespace MyNewApp.Utilities
{
    class Utility
    {
        public static string Reverse(string message)
        {
            char[] letters = message.ToCharArray();
            Array.Reverse(letters);
            return new string(letters);
        }
    }
}