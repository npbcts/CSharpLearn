﻿/*

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

# TODO: 添加武器, 铠甲等道具

namespace MyNewApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("开始游戏， <悟空之黑神话> .....");
            // 创建英雄
            角色 悟空 = new 角色("悟空", 3);
            

            Console.WriteLine("今天奉如来菩萨之托护送师傅西天求取真经...");
            string 游戏动作 = "";
            Random rnd = new Random();
            string[] 怪物名称 = {"普通山怪", "蝎子精", "虾兵", "蟹将","小钻风", "蚂蚱精", "蜘蛛精", "黑熊精", "铁扇公主", 
                "牛魔王", "金角大王", "银角大王", "啸天犬", "二郎神", "奔波儿灞", "灞波儿奔"};
            int[] 怪物等级 = {1, 2, 2, 2, 1, 3, 4, 5, 5,
                6, 5, 4, 4, 7, 3, 3}; //对应怪物名称
            do
            {
                do
                {
                Console.Write($"\n请输入游戏动作f(进入战斗), v(观察英雄状态), r(休息), q(退出游戏): ");
                游戏动作 = Console.ReadLine();
                } while(!("fvrq".Contains(游戏动作)));

                if (游戏动作 == "f")
                {
                    int 随机数 = rnd.Next(1, (怪物名称.Length+1));
                    战斗类.随机战斗(悟空, 怪物名称[随机数], 怪物等级[随机数]);
                    if (悟空.角色生命值 <= 0)
                    {
                        Console.WriteLine($"{悟空.角色名称} 在战斗中遭受了重创,永远地离开了我们....");
                        break;
                    }
                }
                else if (游戏动作 == "v")
                    查看.查看角色状态(悟空);
                else if (游戏动作 == "r")
                    休息.回生命值(悟空, 5, 0);
            } while(游戏动作!="q");
         
        }

    }

    class 角色
    {
        public 角色(string 角色名称, int 角色等级)
        {
            this.角色名称 = 角色名称;
            this.角色等级 = 角色等级;
            this.角色生命值 = 角色等级*20;  //角色生命值;
            this.角色生命力 = 角色等级*20;  //角色生命力;
            this.角色物理攻击力 = 角色等级*6;  //角色物理攻击力;
            this.角色物理防御 = 角色等级*3;  //角色物理攻防御;
            this.角色魔法攻击力 = 角色等级*5;  //角色魔法攻击力;
            this.角色魔法防御 = 角色等级*1;  //角色魔法攻防御;
        }
        public string 角色名称;
        public int 角色等级;
        public int 角色生命值;
        public int 角色生命力;
        public int 角色物理攻击力;
        public int 角色魔法攻击力;
        public int 角色物理防御;
        public int 角色魔法防御;
    }
    
    class 查看
    {
        public static void 查看角色状态(角色 一个角色)
        {
            int 新等级 = (int)(一个角色.角色生命力/20);
            if ( 新等级 > 一个角色.角色等级)
            {
                一个角色.角色等级 = 新等级;
                Console.WriteLine("恭喜 {一个角色.角色名称} 升级");
            }
            Console.WriteLine($"~~~~~~~~~~~~~~~~~{一个角色.角色名称} 的状态情况:");
            Console.Write($"生命值 : {一个角色.角色生命值}/{一个角色.角色生命力};");
            Console.Write($"\t等级 : {一个角色.角色等级};");
            Console.Write($"\t物理攻击力 : {一个角色.角色物理攻击力};");
            Console.Write($"\t魔法攻击力 : {一个角色.角色魔法攻击力};");
            Console.Write($"\t物理防御  : {一个角色.角色物理防御};");
            Console.Write($"\t魔法防御 : {一个角色.角色魔法防御};");
            Console.WriteLine($"~~~~~~~~~~~~~~~~~{一个角色.角色名称} 的状态情况:");
        }
    }
    class 休息
    {
        public static void 回生命值(角色 角色一, int 生命值恢复, int 魔法值恢复)
        {
            角色一.角色生命值 += 生命值恢复;
            if (角色一.角色生命值 > 角色一.角色生命力)
                角色一.角色生命值 = 角色一.角色生命力;
            Console.WriteLine($"{角色一.角色名称} 生命值恢复 {生命值恢复}");
        }
    }
    class 战斗类
    {
        public static int 角色一攻击角色二的失血量(角色 角色一, 角色 角色二)
        {
            Random rnd = new Random();
            int 角色一物理攻击力 = rnd.Next(0, 角色一.角色物理攻击力);
            int 角色一魔法攻击力 = rnd.Next(0, 角色一.角色魔法攻击力);
            int 角色二物理防御 = rnd.Next(0, 角色二.角色物理防御);
            int 角色二魔法防御 = rnd.Next(0, 角色二.角色魔法防御);
            int 角色二失血量 = 角色一物理攻击力 + 角色一魔法攻击力 - 角色二物理防御 - 角色二魔法防御;
            if (角色二失血量 < 0)
                角色二失血量 = 0;
            return 角色二失血量;
        }
        public static string 一回合战斗(角色 英雄, 角色 怪兽, int 怪物等级)
        {

                //英雄开始攻击怪兽
                int 怪兽失血量 = 角色一攻击角色二的失血量(英雄, 怪兽);
                怪兽.角色生命值 = 怪兽.角色生命值 - 怪兽失血量;
                Console.WriteLine($"\n{怪兽.角色名称}被攻击, 失血:{怪兽失血量}, {怪兽.角色名称}剩余血量: {怪兽.角色生命值}");
                
                if (怪兽.角色生命值<=0)
                {
                    Console.WriteLine($"威武的 {英雄.角色名称} 获得了最终胜利!");
                    int 生命力增加值 = 5*怪物等级;
                    英雄.角色生命力 += 生命力增加值;

                    int 物理攻击力增加值 = 3*怪物等级;
                    英雄.角色物理攻击力 += 物理攻击力增加值;

                    int 物理防御增加值 = 1*怪物等级;
                    英雄.角色物理防御 +=物理防御增加值;
                    Console.WriteLine($"获胜奖励: 角色生命力 +{生命力增加值}, 物理攻击力 +{物理攻击力增加值}, 物理防御 +{物理防御增加值}");
                    return "End";
                }
                
                //怪兽开始攻击英雄
                int 英雄失血量 = 角色一攻击角色二的失血量(怪兽, 英雄);
                英雄.角色生命值 = 英雄.角色生命值 - 英雄失血量;
                Console.WriteLine($"{英雄.角色名称} 被 {怪兽.角色名称}咬了一口, 失血: {英雄失血量}, {英雄.角色名称} 剩余血量 :{英雄.角色生命值}");

                if (英雄.角色生命值<=0)
                {
                    Console.WriteLine($"残忍的 {怪兽.角色名称} 打死了英雄!");
                    return "End";
                }
                else
                {
                    return "Half";
                }

        }

        public static void 随机战斗(角色 英雄, string 怪物名称, int 怪物等级)
        {
            // 触发随即战斗事件
            角色 怪物 = new 角色(怪物名称, 怪物等级);
            
            Console.WriteLine($"在山脚,遇到一个怪物 {怪物名称} 举刀向我...");
            查看.查看角色状态(怪物);
            Console.Write("\n是否战斗,y(战斗),e(逃跑):");
            string 是否继续战斗 = Console.ReadLine();
            // Console.WriteLine(是否继续战斗);
            while(是否继续战斗 == "y")  // ascii y->121
            {
                是否继续战斗 = "";
                string result = 战斗类.一回合战斗(英雄, 怪物, 怪物等级);

                while((是否继续战斗!="y" && 是否继续战斗!="e" && result!="End"))
                {
                    Console.Write("\n是否继续战斗y(战斗),e(逃跑):");
                    是否继续战斗 = Console.ReadLine();
                } 
            } 

            if (是否继续战斗 == "e")  // ascii e->101
            {
                Console.WriteLine("我一个筋斗云十万八千里,避开了妖怪的追杀...好险!");
            }
        }

    }
    
}
