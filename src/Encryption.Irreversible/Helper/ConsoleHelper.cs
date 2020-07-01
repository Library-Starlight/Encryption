using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Helper
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// 持续从控制台读取字符串，并执行操作。
        /// 知道遇到结束字符串时，结束操作。
        /// </summary>
        /// <param name="loopAction"></param>
        /// <param name="end"></param>
        public static void LoopProcessInputUntil(Action<string> loopAction, string end)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"请输入参数(输入{end}结束)：");
                Console.ForegroundColor = ConsoleColor.White;

                var input = Console.ReadLine();

                if (input == end)
                    break;

                loopAction?.Invoke(input);

                Console.WriteLine();

                Console.WriteLine($"按Enter键结束本次操作。");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
