## C# 自我初学笔记 第N章  字典初始化

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer),微软推出的初学者教程整理。


### 字典特性

- 属于System.Collection.Generic命名空间
- Dictionary<TKey, TValue> 存储键值对，键值对元素存储为 KeyValuePair <TKey，TValue> 对象，Dictionary里面每一个元素都是以键值对的形式存在的
- 键必须是唯一的，不能为null
- 值可以为null或重复
- 键和值都可以以任何数据类型存在（比如：值类型、引用类型、自定义类型等等）
- 可以通过在索引器中传递相关键来访问值，例如 myDictionary[key]
- 通过一个键读取一个值得时间接近O(1)

字典数据类型由于查找速度快，数据之间对应关系明确，被广泛使用在各种编程语言中。

下面的例子是，在学生信息数据中查找三年二班`小花`的信息的例子。

使用数组查找学生三年二班学生`小花`的例子：
```c#
public class GetStudent
{
    public static void Main()
    {
        string[,] 三年二班学生 = new string[3,4]
        {
            {"小花", "女", "90", "95"},
            {"小刚", "男", "80", "90"},
            {"小星", "男", "100", "50"},
        };
        foreach (int row in Enumerable.Range(0, 3))
        {
            if (三年二班学生[row, 0] == "小花")
            {
                int column = 0;
                Console.Write($"学生姓名：{三年二班学生[row, column]},");
                Console.Write($"性别: {三年二班学生[row, column+1]},");
                Console.Write($"语文成绩: {三年二班学生[row, column+2]},");
                Console.WriteLine($"数学成绩: {三年二班学生[row, column+3]}");
            }
        }
    }
}
```
输出:
```
学生姓名：小花,性别: 女,语文成绩: 90,数学成绩: 95
```
上面例子中，使用数组存储学生信息，存在着明显的缺陷。
- 无法存储多样的数据类型，比如学生姓名应为字符串，而学生成绩应为数值类型。此例中只能都保存为字符串，以达到统一。
- 检索某条符合条件的数据时，针对创建的二维数组使用循环并判断。
- 存储在数组中的数据语意并不显而易见，在不添加注释的情况下我们不知道数据代表什么。

当然我们也可以将数组内的数据类型设置为`Object`以使得姓名和分数能够使用合适的数据类型。
```c#
Object[,] 三年二班学生 = new Object[3,4]
{
    {"小花", "女", 90, 95},
    {"小刚", "男", 80, 90},
    {"小星", "男", 100, 50},
};
```


使用字典查找学生三年二班学生`小花`的例子：
```c#
public class GetStudent
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, Object>> 三年二班学生 = new Dictionary<string, Dictionary<string, Object>>
        {
            {"小花", new Dictionary<string, Object>{{"性别", "女"}, {"语文分数", 90}, {"数学分数", 95}}},
            {"小刚", new Dictionary<string, Object>{{"性别", "男"}, {"语文分数", 80}, {"数学分数", 90}}},
            {"小星", new Dictionary<string, Object>{{"性别", "男"}, {"语文分数", 100}, {"数学分数", 50}}},

        };
        string studentName = "小花";
        Console.Write($"学生姓名：{studentName},");
        string dictKey = "性别";
        Console.Write($"{dictKey}: {三年二班学生[studentName][dictKey]},");
        dictKey = "语文分数";
        Console.Write($"{dictKey}: {三年二班学生[studentName][dictKey]},");
        dictKey = "数学分数";
        Console.WriteLine($"{dictKey}: {三年二班学生[studentName][dictKey]}");

    }
}
```
输出:
```
学生姓名：小花,性别: 女,语文分数: 90,数学分数: 95
```
可以看到，使用字典存储数据并进行检索，速度快且数据语意明确。


### 例子中的技术说明

[字典的初始化方法](csharp笔记-406字典的初始化.md)

字典值的获取采用了`字典数据[字典键]`(`Item[TKey]`):	获取或设置与指定的键关联的值。这是一种获取和设置字典值的普遍方法。这种方法获取字典值存在缺陷，即当不存在`键`(`TKey`)时程序会抛出异常。当然，字典类型还有更安全的方法获取值。

(End)
