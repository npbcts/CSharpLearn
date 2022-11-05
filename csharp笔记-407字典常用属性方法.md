## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0)整理。

### 字典的属性

- `Comparer`	
获取用于确定字典中的键是否相等的 IEqualityComparer<T>。

- `Count`	
获取包含在 `Dictionary<TKey,TValue>` 中的键/值对的数目。

- `Item[TKey]`	
获取或设置与指定的键关联的值。

- `Keys`	
获得一个包含 `Dictionary<TKey,TValue>` 中的键的集合。

- `Values`	
获得一个包含 `Dictionary<TKey,TValue>` 中的值的集合。


### 字典的常用方法

- `Add(TKey, TValue)`：	
将指定的键和值添加到字典中。

- `Clear()`：	
将所有键和值从 Dictionary<TKey,TValue> 中移除。

- `ContainsKey(TKey)`：	
确定是否 Dictionary<TKey,TValue> 包含指定键。

- `ContainsValue(TValue)`：	
确定 Dictionary<TKey,TValue> 是否包含特定值。

- `GetHashCode()`：	
作为默认哈希函数。

- `GetType()`：	
获取当前实例的 Type。

- `Remove(TKey)`：	
从 Dictionary<TKey,TValue> 中移除所指定的键的值。

- `Remove(TKey, TValue)`：	
从 Dictionary<TKey,TValue> 中删除具有指定键的值，并将元素复制到 value 参数。

- `ToString()`：	
返回表示当前对象的字符串。

- `TryAdd(TKey, TValue)`：	
尝试将指定的键和值添加到字典中。

- `TryGetValue(TKey, TValue)`：	
获取与指定键关联的值。


### 向字典中添加键值对

向字典中添加键值对常用方法有三种:`Item[TKey]`, `Add(TKey, TValue)`, `TryAdd(TKey, TValue)`。三者的主要差别在于面对键唯一字典的特性，如何处理。  

- `Item[TKey]`: 属于赋值操作，当键`TKey`存在时,原来键的值会被合法的值替换掉。  
- `Add(TKey, TValue)`: 添加新值，当键`TKey`存在时, 会抛出异常。  
- `TryAdd(TKey, TValue)`：如果成功将键/值对添加到字典中，则为 `true`；否则为 `false`。


使用`Add(TKey, TValue)`添加新值的例子:
```c#
public class SetDictValue
{
     public static void Main()
    {
        var students = new Dictionary<int, string>()
        {
            {11, "小明"},
            {12, "小刚"}
        };
        students.Add(13, "小力");
        foreach(KeyValuePair<int, string> stu in students)
        {
            Console.WriteLine($"{stu.Key}, {stu.Value}");
        }

    }

}

```
输出:
```
11, 小明
12, 小刚
13, 小力
```
添加成功。

使用`Add(TKey, TValue)`添加新值返回异常的例子
```c#
public class SetDictValue
{
     public static void Main()
    {
        var students = new Dictionary<int, string>()
        {
            {11, "小明"},
            {12, "小刚"}
        };
        students.Add(11, "小力");
        foreach(KeyValuePair<int, string> stu in students)
        {
            Console.WriteLine($"{stu.Key}, {stu.Value}");
        }

    }

}
```
返回的异常:
```
Unhandled exception. System.ArgumentException: An item with the same key has already been added. Key: 11
   at System.Collections.Generic.Dictionary`2.TryInsert(TKey key, TValue value, InsertionBehavior behavior)
   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
   at SetDictValue.Main() in /home/clark/tmp/csharp/Program.cs:line 11
```

`TryAdd(TKey, TValue)`添加值的例子:
```c#
public class SetDictValue
{
     public static void Main()
    {
        var students = new Dictionary<int, string>()
        {
            {11, "小明"},
            {12, "小刚"}
        };
        bool addResult = students.TryAdd(11, "小力");
        Console.WriteLine($"添加结果: {addResult}");
        foreach(KeyValuePair<int, string> stu in students)
        {
            Console.WriteLine($"{stu.Key}, {stu.Value}");
        }

    }

}
```
输出结果:
```
添加结果: False
11, 小明
12, 小刚
```


### 获取某个键的值

获取某个键的值有两种方法, `Item[TKey]`, `TryGetValue(TKey, TValue)`。

- `Item[TKey]`, 当已检索该属性且集合中不存在 `key` 时, 抛出 `KeyNotFoundException`。

- `TryGetValue(TKey, TValue)`: 返回布尔值。当已检索该属性且集合中不存在 `key` 时, 返回`false`，否则返回 `true`。

`TryGetValue(TKey, TValue)`方法获取字典值的例子:
```c#
public class GetDictValue
{
    public static void Main()
    {
        var students = new Dictionary<int, string>()
        {
            {11, "小明"},
            {12, "小刚"}
        };
        string? name = "";
        bool getResult = false;
        getResult = students.TryGetValue(11, out name);
        Console.WriteLine($"{getResult}, {name}");

    }
}
```
返回结果:
```
True, 小明
```
`TryGetValue(TKey, TValue)`方法获取字典值需要向方法传递`out`参数。

`Item[TKey]`获取字典值的例子:
```c#
public class GetDictValue
{
     public static void Main()
    {
        var students = new Dictionary<int, string>()
        {
            {11, "小明"},
            {12, "小刚"}
        };
        string name = students[15];
        Console.WriteLine($"{name}");
    }
}
```
由于想要获取字典中没有键的值返回结果，抛出异常:
```
Unhandled exception. System.Collections.Generic.KeyNotFoundException: The given key '15' was not present in the dictionary.
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at GetDictValue.Main() in /home/clark/tmp/csharp/Program.cs:line 12
```


关于字典类型的借口和扩展方法，可以查看文档。


(End)
