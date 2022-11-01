/*

这是一个英雄和怪兽战斗的游戏，一款文字版极简RPG(角色扮演游戏)

回合制游戏规则

- 英雄和怪物在开始时的生命值为 10
- 所有攻击都是介于 1 到 10 之间的值
- 英雄首先攻击
- 输出怪物损失的生命值，以及剩余的生命值
- 如果怪物的生命值大于 0，则它会攻击英雄
- 输出英雄损失的生命值，以及剩余的生命值
- 继续此攻击顺序，直到怪物或英雄任意一方的生命值为零或更低
- 输出胜利者

*/
using System;

namespace MyNewApp
{
    class Program
    {

        static void Main(string[] args)
        {
            int 英雄生命值 = 10;
            int 怪兽生命值 = 10;
            Random rnd = new Random();
             do
            {
                //英雄开始攻击怪兽
                int 怪兽失血量 = rnd.Next(1, 5);
                怪兽生命值 = 怪兽生命值 - 怪兽失血量;
                Console.WriteLine($"怪兽被攻击，失血:{怪兽失血量}, 怪兽剩余血量: {怪兽生命值}");
                if (怪兽生命值<=0)
                {
                    Console.WriteLine("威武的英雄获得了最终胜利!");
                    break;
                }
                
                //怪兽开始攻击英雄
                int 英雄失血量 = rnd.Next(1, 5);
                英雄生命值 = 英雄生命值 - 英雄失血量;
                Console.WriteLine($"英雄被怪兽咬了一口, 失血: {英雄失血量}, 英雄剩余血量 :{英雄生命值}");
                if (英雄生命值<=0)
                {
                    Console.WriteLine("残忍的怪兽打死了英雄!");
                    break;
                }
                
                
            } while(true);
        }

    }
}
