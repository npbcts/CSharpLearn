using Models;

namespace Services;
public class CookMession
{
    //================= 倒果汁 ==============================
    /// <summary>
    /// 倒果汁,没有时间需求；
    /// </summary>
    /// <returns>返回一杯果汁</returns>
    public static Juice PourOJ()
    {
        Console.WriteLine("Pouring orange juice");
        return new Juice();
    }


    //================= 煎培根 ==============================
    /// <summary>
    /// 煎培根，一面3s,煎好两面6s
    /// </summary>
    /// <param name="slices">培根片数</param>
    /// <returns>返回煎好的培根</returns>
    public static Bacon FryBacon(int slices)
    {
        Console.WriteLine($"putting {slices} slices of bacon in the pan");
        Console.WriteLine("cooking first side of bacon...");
        Task.Delay(3000).Wait();
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("flipping a slice of bacon");
        }
        Console.WriteLine("cooking the second side of bacon...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Put bacon on plate");

        return new Bacon();
    }


    /// <summary>
    /// 制作培根的异步方法，一面3s,煎好两面6s
    /// </summary>
    /// <param name="slices"></param>
    /// <returns></returns>
    public static async Task<Bacon> FryBaconAsync(int slices)
    {
        Console.WriteLine($"putting {slices} slices of bacon in the pan");
        Console.WriteLine("cooking first side of bacon...");
        await Task.Delay(3000);
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("flipping a slice of bacon");
        }
        Console.WriteLine("cooking the second side of bacon...");
        await Task.Delay(3000);
        Console.WriteLine("Put bacon on plate");

        return new Bacon();
    }

    //================= 制作吐司面包 ==============================
    public static void ApplyJam(Toast toast) =>
        Console.WriteLine("Putting jam on the toast");

    public static void ApplyButter(Toast toast) =>
        Console.WriteLine("Putting butter on the toast");

    /// <summary>
    /// 制作吐司面包,需要时间3S
    /// </summary>
    /// <param name="slices">制作吐司面包需要的面包片数</param>
    /// <returns>制作好的吐司面包</returns>
    public static Toast ToastBread(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }
        Console.WriteLine("Start toasting...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }


    /// <summary>
    /// 制作面包土司的异步方法,需要时间3S
    /// </summary>
    /// <param name="slices"></param>
    /// <returns></returns>
    public static async Task<Toast> ToastBreadAsync(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }
        Console.WriteLine("Start toasting...");
        await Task.Delay(3000);
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }




    //================= 煎蛋 ==============================

    /// <summary>
    /// 煎蛋方法，一面3S，煎好一个6s
    /// </summary>
    /// <param name="howMany">鸡蛋个数</param>
    /// <returns>返回煎好的鸡蛋</returns>
    public static Egg FryEggs(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        Task.Delay(3000).Wait();
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }


    /// <summary>
    /// 制作煎蛋的异步方法，一面3S，煎好一个6s
    /// </summary>
    /// <param name="howMany"></param>
    /// <returns></returns>
    public static async Task<Egg> FryEggsAsync(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        await Task.Delay(3000);
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        await Task.Delay(3000);
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }

    //================= 冲咖啡 ==============================

    /// <summary>
    /// 冲咖啡方法，无时间需求
    /// </summary>
    /// <returns>返回一杯冲好的咖啡</returns>
    public static Coffee PourCoffee()
    {
        Console.WriteLine("Pouring coffee");
        return new Coffee();
    }

}