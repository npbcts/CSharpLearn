

//myenum.小刚 是 myenum类型
Console.WriteLine("\n类型使用 ===============================");
myenum exg = myenum.小刚;
Console.WriteLine(exg);
Console.WriteLine(myenum.小刚.GetType());  


Console.WriteLine("\n转化为字符串===============================");

//ToString后为 string类型
var xg = myenum.小刚.ToString();  
Console.WriteLine(xg);
Console.WriteLine(xg.GetType());


Console.WriteLine("\n转化为int===============================");

// enum基础类型为int，因此可以强制转换成int
int ixg = (int)myenum.小刚;
Console.WriteLine(ixg);


Console.WriteLine("\n字符串转化为枚举值===============================");
// var myList = myenum.ToArray();
// Console.WriteLine(myList.GetType());


//将字符串 小明  转换为枚举值

myenum xm;
var name = "小明"; 
bool ifxm = Enum.TryParse<myenum>(name, out xm);
if(ifxm) Console.WriteLine(xm);


Console.WriteLine("\n获取枚举值字符串数组===============================");

//迭代成员
string[] names = Enum.GetNames(typeof(myenum));

foreach(var item in names)
{ Console.WriteLine(item); }


Console.WriteLine("===============================");

enum myenum
{
    小明,
    小刚
}
