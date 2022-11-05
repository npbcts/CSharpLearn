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

// TODO: 添加武器, 铠甲等道具

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
            Dictionary<string, int> 怪物名称及等级表 = new Dictionary<string, int>
                {
                    {"普通山怪", 1}, {"蝎子精", 2}, {"虾兵", 2}, {"蟹将", 2}, {"小钻风", 1}, {"蚂蚱精", 3},
                    {"蜘蛛精", 4}, {"黑熊精", 5}, {"铁扇公主", 5},{"牛魔王", 6}, {"金角大王", 5}, {"银角大王", 4},
                    {"啸天犬", 4}, {"二郎神", 7}, {"奔波儿灞", 3}, {"灞波儿奔", 3}

                };

            do
            {
                do
                {
                    Console.Write($"\n输入-> f(战斗), v(观察英雄状态), r(休息), b(查看背包), q(退出游戏): ");
                    var result = Console.ReadLine();
                    游戏动作 = result != null? result: "";
                } while(!("fvrbq".Contains(游戏动作)));

                if (游戏动作 == "f")
                {
                    int 随机数 = rnd.Next(0, (怪物名称及等级表.Count));  // 数组超界限?
                    string 怪物名称 = 怪物名称及等级表.Keys.ToList()[随机数];  // 使用 Dictionary.Keys.ToList()方法，将KeysCollection类型转换为数组，以便使用数索引
                    战斗类.随机战斗(悟空, 怪物名称, 怪物名称及等级表[怪物名称]);
                    if (悟空.角色生命值 <= 0)
                    {
                        Console.WriteLine($"{悟空.角色名称} 在战斗中遭受了重创,永远地离开了我们....");
                        break;
                    }
                }
                else if (游戏动作 == "v")
                    悟空.状态();
                else if (游戏动作 == "r")
                    悟空.休息(5, 0);
                else if (游戏动作 == "b")
                    悟空.查看背包();
            } while(游戏动作!="q");
         
        }

    }

    // 创建基本角色，之后衍生出人物角色和装备角色，两个都具有名称，等级各种攻击和防御能力
    // 装备角色没有动作，只有属性
  
    class 人物角色: 太极
    {
        public 人物角色(string 角色名称, int 角色等级, 角色等级*20)
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
        public int 角色物理攻击力;
        public int 角色魔法攻击力;
        public int 角色物理防御;
        public int 角色魔法防御;
        public int 角色生命值;
        

        private int 角色生命力_私有;
        public int 角色生命力
        {
            get
            {
                return this.角色生命力_私有;
            }
            set
            {
                this.角色生命力_私有 = value;
                int 新等级 = (int)(this.角色生命力_私有/20);
                if ( 新等级 > this.角色等级)
                    {
                        this.角色等级 = 新等级;
                        Console.WriteLine($"恭喜 {this.角色名称} 升级");
                    }
            }
        }

        public void 状态()
        {
            Console.WriteLine($"~~~~~~~~~~~~~~~~~{this.角色名称} 的状态情况:");
            Console.Write($"生命值 : {this.角色生命值}/{this.角色生命力}");
            Console.Write($"\t等级 : {this.角色等级}");
            Console.Write($"\t物理攻击力 : {this.角色物理攻击力}");
            Console.Write($"\t魔法攻击力 : {this.角色魔法攻击力}");
            Console.Write($"\t物理防御  : {this.角色物理防御}");
            Console.Write($"\t魔法防御 : {this.角色魔法防御}\n");
        }

        public void 休息(int 生命值恢复, int 魔法值恢复)
        {
            this.角色生命值 += 生命值恢复*this.角色等级;
            if (this.角色生命值 > this.角色生命力)
                this.角色生命值 = this.角色生命力;
            Console.WriteLine($"{this.角色名称} 生命值恢复 {生命值恢复*this.角色等级}");
        }
        private static Dictionary<string, int> 布衣属性 = new Dictionary<string, int>{{"角色物理防御", 1},};
        static 装备 布衣 = new 装备("布衣", 布衣属性);
        public Dictionary<装备, int> 背包 = new Dictionary<装备, int>{{布衣, 1}};

        private static Dictionary<string, int> 木棍属性 = new Dictionary<string, int>{{"角色物理攻击", 1},};
        static 装备 木棍 = new 装备("木棍", 木棍属性);
        public Dictionary<装备, int> 穿戴装备 = new Dictionary<装备, int>{{木棍, 1}};

        public void 获得或减少装备(装备 获得的装备, int 装备数量)
        {
            int 装备数量_临时 = 0;
            if (this.背包.Keys.Contains(获得的装备))  // value -> 装备
                装备数量_临时 = this.背包[获得的装备] + 装备数量;
            else
                装备数量_临时 = 1;
            this.背包.Add(获得的装备, 装备数量_临时);
        }

        public void 查看背包()
        {
            查看装备集合(this.背包, "背包");
        }
        private void 查看装备集合(Dictionary<装备, int> 装备集合, string 集合名称)
        {
            Console.WriteLine($"~~~~~~~~~~~~~~~~~ {this.角色名称} {集合名称} 装备列表:");

            int index = 0;
            foreach (KeyValuePair<装备, int> 背包装备临时 in 装备集合)
            {
                Console.Write($"{index}. {背包装备临时.Key.装备名称.PadRight(10)}, 拥有数量 {背包装备临时.Value}:");
                foreach (KeyValuePair<string, int> 装备属性 in 背包装备临时.Key.属性)
                {
                    Console.Write($"装备: {装备属性.Key} +{装备属性.Value};");
                }
                index ++;
                Console.Write("\n");
            }

        }
        public void 添加装备(int 序号)
        {
            装备 添加装备;
            this.背包.Remove(this.背包.Keys[序号])

        }
    }
    class 装备
    {
        public 装备(string 装备名称, Dictionary<string, int> 属性组)
        {
            this.装备名称 = 装备名称;
            this.属性 = new Dictionary<string, int>(属性组);
        }
        public string 装备名称;
        public Dictionary<string, int> 属性;
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
                    
                    Dictionary<string, int> 怪物掉落的装备属性 = new Dictionary<string, int>{{"物理攻击力", 50}, {"角色生命力", 50}};
                    装备 怪物掉落的装备 = new 装备("定海神针", 怪物掉落的装备属性);
                    英雄.获得或减少装备(怪物掉落的装备, 1);
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
            怪物.状态();
            string 是否继续战斗 = "INITSTRING";
            string result = "";
            do
            {
                while(!"ye".Contains(是否继续战斗))
                {
                    Console.Write("\n是否继续战斗y(战斗),v(查看英雄状态),e(逃跑):");
                    是否继续战斗 = Console.ReadLine().ToString();
                    // 是否继续战斗 = consoleResult != null? consoleResult: "";
                    if (是否继续战斗 == "v")
                    {
                        英雄.状态();
                    }
                } 
                if (是否继续战斗 == "y")
                {
                    result = 战斗类.一回合战斗(英雄, 怪物, 怪物等级);
                }
                if (result == "End")
                {
                    break;
                }
            } while(是否继续战斗 == "y");

            if (是否继续战斗 == "e")  // ascii e->101
            {
                Console.WriteLine("我一个筋斗云十万八千里,避开了妖怪的追杀...好险!");
            }

        }

    }
    


      class 太极
    {
        // 太极是一切事物演变的基础，其他事物可以从太极继承
         public 太极(
            string 类别, string 名称, int 等级=0, int 生命值=0, 
            int 生命力=0, int 物理攻击力=0, int 物理防御=0, int 魔法攻击力=0, int 魔法防御=0)
        {
            this.类别 = 类别;
            this.名称 = 名称;
            this.等级 = 等级;
            this.生命值 = 生命值;  // 生命值会随着使用或被攻击而下降
            this.生命力 = 生命力;  //生命总长度，随着修炼增加;
            this.物理攻击力 = 物理攻击力;  //物理攻击力, 可以修炼等级提升或武器加持增加;
            this.物理防御 = 物理防御;  //物理攻防御, 可以修炼等级提升或武器加持增加;
            this.魔法攻击力 = 魔法攻击力;  //魔法攻击力, 可以修炼等级提升或武器加持增加;
            this.魔法防御 = 魔法防御;  //魔法攻防御, 可以修炼等级提升或武器加持增加;

        }
        private string 类别私有;
        protected string 类别  // protected保护的属性,类继承时才能修改, 外部实例化时无法修改
        {
            get{return this.类别私有;}
            set{this.类别私有 = value;}
        }

        private string 名称私有;
        public string 名称
        {
            get{return this.名称私有;}
            set{
                this.名称私有 = value;
                }
        }

        private int 等级私有;
        public int 等级
        {
            get{return this.等级私有;}
            set{this.等级私有 = value;}
        }

        private int 物理攻击力私有;
        public int 物理攻击力
        {
            get{return this.物理攻击力私有;}
            set{this.物理攻击力私有 = value;}
        }

        private int 魔法攻击力私有;
        public int 魔法攻击力
        {
            get{return this.魔法攻击力;}
            set{this.魔法攻击力 = value;}
        }

        private int 物理防御私有;
        public int 物理防御
        {
            get{return this.物理防御;}
            set{this.物理防御 = value;}
        }
        private int 魔法防御私有;
        public int  魔法防御
        {
            get{return this.魔法防御;}
            set{this.魔法防御 = value;}
        }
        private int 生命值私有;
        public int 生命值
        {
            get{return this.生命值;}
            set
            {
                if (value <0)  // 生命值不能低于0
                {
                    value = 0;
                }
                this.生命值 = value;
            }
        }
        private int 生命力私有;
        public veriul int 生命力  // 可被继承类重写的属性
        {
            get{return this.生命力;}
            set{this.生命力 = value;}
        }

        public void 状态()
        {
            Console.WriteLine($"~~~~~~~~~~~~~~~~~{this.名称} 的状态情况:");
            Console.Write($"生命值 : {this.生命值}/{this.生命力}");
            Console.Write($"\t等级 : {this.等级}");
            Console.Write($"\t物理攻击力: {this.物理攻击力}");
            Console.Write($"\t魔法攻击力: {this.魔法攻击力}");
            Console.Write($"\t物理防御: {this.物理防御}");
            Console.Write($"\t魔法防御: {this.魔法防御}\n");
        }

        public void 恢复(int 生命值恢复)
        {
            this.生命值 += 生命值恢复;
            if (this.生命值 > this.生命力)
            {
                this.生命值 = this.生命力;
                Console.WriteLine($"{this.名称} 生命值恢复至最高!");
                }
            Console.WriteLine($"{this.名称} 生命值恢复 {生命值恢复}");
        }

    }
}
