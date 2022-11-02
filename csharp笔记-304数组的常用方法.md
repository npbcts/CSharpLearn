## C# 自我初学笔记 第N章  数组的常用方法

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-arrays-operations/2-exercise-sort-reverse#code-try-0),微软推出的初学者教程整理。


通过 C# 数组，可以将值的序列存储在单个数据结构中。 数组中有数据时，你可以操纵数组中的顺序和内容。

- 排列和反向排列数组元素。
- 清除数组元素及调整其大小。
- 将字符串拆分为字符串或字符 (char) 的数组。
- 将数组元素加入字符串。


### `Array.Sort`排序和`Array.Reverse()`反转

Array 类包含一些方法，可用于操纵数组的内容、排列方式和大小。

例子：
假设你就职于一家物流公司。 公司要求你编写代码，用于跟踪装有建筑用品的托盘。 还要对该托盘列表进行重新排序。 如何维护此类列表？

创建托盘数组，并对其进行排序：
```c#
string[] pallets = { "B14", "A11", "B12", "A13" };

Console.WriteLine("Sorted...");
Array.Sort(pallets);
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
```
`Array.Sort(pallets);`是按照按字母顺序对数组中的项进行排序的关键，输出结果如下：
```
Sorted...
-- A11
-- A13
-- B12
-- B14
```
通过调用 `Array.Reverse()` 方法来反转托盘顺序。 

```c#
//...
Array.Reverse(pallets);
//...
```
反转后的输出结果:
```
Reversed...
-- B14
-- B12
-- A13
-- A11
```
### `Array.Clear`方法,清除数组中的项

清除数组项的一个例子：
```c#
string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
```
输出：
```
Clearing 2 ... count: 4
-- 
-- 
-- B12
-- A13
```
关注 `Array.Clear(pallets, 0, 2);` 所在的代码行。 此处，使用 `Array.Clear()` 方法来清除存储在 `pallets` 数组元素中的值（从索引 `0` 开始，清除 `2` 个元素）。

可以看到，在`foreach`循环中，仍然能够迭代到被清除位置，实际上数组原来的值被清除后的值相当于被赋予了`null`。使用 Array.Clear() 时，被清除的元素不再引用内存中的字符串。 事实上，该元素不指向任何内容。


```c#
string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Clear(pallets, 0, 3);

foreach (var pallet in pallets)
{
    string pallet_show = "";
    if (pallet == null)
        pallet_show = "blank";
    else
        pallet_show = pallet;
    Console.WriteLine($"-- {pallet_show}");
}

Console.WriteLine($"pallets position 0 is : {pallets[0]}");
```
输出结果:
```
-- blank
-- blank
-- blank
-- A13
pallets position 0 is : 
```
你可能会认为 pallets[0] 中存储的值是空字符串。 但是，C# 编译器会将 null 值隐式转换为可供显示的空字符串。

### `Array.Resize()`调整数组大小

我们要将 `pallets` 数组从 `4` 个元素调整为 `6` 个。 将新元素添加到当前元素的末尾。 在向这两个新元素赋值之前，其值为 `null`。

```c#
string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Resize(ref pallets,6);

foreach (var pallet in pallets)
{
    string pallet_show = "";
    if (pallet == null)
        pallet_show = "blank";
    else
        pallet_show = pallet;
    Console.WriteLine($"-- {pallet_show}");
}

```
输出结果:
```
-- B14
-- A11
-- B12
-- A13
-- blank
-- blank
```
关注 `Array.Resize(ref pallets, 6);` 所在的行。 在此，我们将调用通过引用（使用 `ref` 关键字）传入 `pallets` 数组的 `Resize()` 方法。 在某些情况下，方法会要求按值（默认）或按引用（使用 `ref` 关键字）来传递参数。

上面的例子在数组末尾添加了两个元素，下面例子展示调整后元素数量缩小的情况：
```c#
string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Resize(ref pallets, 3);

foreach (var pallet in pallets)
{
    string pallet_show = "";
    if (pallet == null)
        pallet_show = "blank";
    else
        pallet_show = pallet;
    Console.WriteLine($"-- {pallet_show}");
}

```
输出结果:
```
-- B14
-- A11
-- B12
```
调用 `Array.Resize()` 会删除后两个元素，尽管它们含有字符串值。

`Array.Resize()`只能在数组的末尾进行操作，不能改变数组中间项。


(End)