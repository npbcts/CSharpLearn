using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyElephant.Client.Models;

namespace CrazyElephant.Client.Services;
//声明数据获取的接口。之所以声明接口，实际上为了应对数据来源的变化。
//不同数据来源，保证实现此接口，那么对于数据的使用方，不会产生影响。也是解耦合的一种体现。
internal interface IDataServices
{
    List<Dish> GetAllDishs();
}
