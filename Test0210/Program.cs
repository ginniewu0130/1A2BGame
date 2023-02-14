using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test0210
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] answer = new int[4];//取數字的陣列
            int[] inputNum= new int[4];//猜數字的陣列
            int a; 
            int b;
            bool finish=false;
            Console.WriteLine("歡迎來到1A2B猜數字的遊戲~");
            Random roll = new Random();
            do 
            {
                //取四個數字
                answer[0] = roll.Next(1, 10);
                for (int i = 1; i < answer.Length; i++)
                {
                    answer[i] = roll.Next(1, 10);
                    for (int j = 0; j < i; j++)
                    {
                        while (answer[i] == answer[j])
                        {
                            answer[i] = roll.Next(1, 10);
                            j = 0;
                        }
                    }
                }
                foreach(int i in answer) {Console.Write(i);}
              
                //判斷1A2B
                do
                {
                    Console.Write("請輸入4個數字:");
                    string guess = Convert.ToString(Console.ReadLine());
                    for (int i = 0; i < 4; i++) { inputNum[i] = Convert.ToInt32(guess.Substring(i, 1)); }
                    a = 0; b = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (answer[i] == inputNum[i])
                        {
                            a++;
                        }
                        
                        for (int j = 0; j < 4; j++)
                        {
                            if (answer[i] == inputNum[j] && i!=j)
                            {
                                b++;   
                            }
                        }
                    }
                    Console.WriteLine($"判定結果是 {a}A{b}B");
                } while (a != 4);
                Console.WriteLine("恭喜你!答對了!!");
                Console.WriteLine("你要繼續玩嗎?y/n");
                string yesorno=Console.ReadLine();
                if (yesorno == "n")
                {
                    finish= true;
                }
            } while (finish==false);
           
            
            


            Console.ReadLine();
           


        }
    }
}
