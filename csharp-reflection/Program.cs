// See https://aka.ms/new-console-template for more information

using System.Reflection;


class  BaseClass
{
    public int BaseFiled = 2;
    public int BaseFiledTwo = 300;
}

class DerivedClass: BaseClass
{
    public int DerivedFiled = 0;
}

class Program
{
    static void Main()
    {
        var ab = new BaseClass();
        var dc = new DerivedClass();

        BaseClass[] bca = new BaseClass[]{ab, dc};

        // foreach(var v in bca)
        // {
        //     Type t = v.GetType();
        //     Console.WriteLine($"Object Type is: {t.Name}");

        //     FieldInfo[] fi = t.GetFields();  // 获取类字段信息
        //     foreach(var i in fi)
        //     {
        //         Console.WriteLine($"        FileInfo is : {i.Name}");
        //     }
        // }

        // AttrTest();

        // 根据属性名获取属性值
        Type t = ab.GetType();
        var x = t.GetField("BaseFiledTwo").GetValue(ab);
        Console.WriteLine($" value: {x} type: {x.GetType()}");



    }

    [Obsolete("功能即将被移除!")]  // 显示旧功能的提示
    public static void AttrTest()
    {
        Console.WriteLine("Hello World!");
    }
    
}
