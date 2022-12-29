using System.Collections.ObjectModel;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//=========================== 泛型 ===========================

// List<int> myList1 = new(){1,2,3};
// Console.WriteLine($"myList1:   {String.Join(",", myList1)}, myList1Id:  {myList1.GetHashCode()}");
// List<int> myList2 = new(myList1);
// Console.WriteLine($"myList2:   {String.Join(",", myList2)}, myList2Id:  {myList2.GetHashCode()}");


// ObservableCollection<int> obs1 = new(){10,20,30};
// Console.WriteLine($"obs1:   {String.Join(",", obs1)}, obs1Id:  {obs1.GetHashCode()}");

// ObservableCollection<int> obs2 = new(obs1);
// Console.WriteLine($"obs2:   {String.Join(",", obs2)}, obs2Id:  {obs2.GetHashCode()}");

// List<int> obsList = new(obs1);
// Console.WriteLine($"obsList:  {String.Join(",", obsList)}, obsListId:  {obsList.GetHashCode()}");
// var res = obsList.Find(e=>e>20);
// Console.WriteLine(res);



//=========================== 委托 ===========================

// Func<int, int, int> mydele = new(M1);

// int M1(int x, int y)
// {
//     return x + y;
// }


// int Plus(int x, int y)
// {
//     return x*y;
// }

// void calculate(Func<int, int, int>  cal)
// {
//     int x =1;
//     int y = 2;
//     var res = cal(x, y);
//     Console.WriteLine(res);
// }

// calculate(M1);

// delegate int Mydele(int a, int b);


// ======================= lambda表达式 ===========================
Dosomething((a,b)=>a+b, 10, 20);


static void Dosomething<T>(Func<T, T, T> func, T x, T y)
{
    T res = func(x, y);
    Console.WriteLine(res);
}