using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Services;
//IOrderServices的一种实现方式，存储在硬盘的txt文件中
internal class MockOrderServices : IOrderServices
{
    public void PlaceOrder(List<string> dishes)
    {
        System.IO.File.WriteAllLines(@"C:\order.txt", dishes.ToArray());
    }
}
