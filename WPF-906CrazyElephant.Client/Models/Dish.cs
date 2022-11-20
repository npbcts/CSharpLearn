using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Models;

//对应data文件夹中单条数据模型
internal class Dish
{
    public string Name
    {
        get; set;
    }

    public string Category
    {
        get; set; 
    }

    public string Comment
    {
        get; set; 
    }

    public double Score
    {
        get; set; 
    }
}
