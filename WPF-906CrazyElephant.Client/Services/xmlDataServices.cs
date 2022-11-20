using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CrazyElephant.Client.Models;

namespace CrazyElephant.Client.Services;
//xml数据来源于文件的一种实现IDataServices接口的方式。
internal class XmlDataServices : IDataServices
{
    public List<Dish> GetAllDishs()
    {
        var dishList = new List<Dish>();

        string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
        XDocument xDoc = XDocument.Load(xmlFileName);
        var dishes = xDoc.Descendants("Dish");

        foreach (var dish in dishes)
        {
            Dish dish_tmp = new Dish();
            dish_tmp.Name = dish.Element("Name").Value;
            dish_tmp.Category = dish.Element("Category").Value;
            dish_tmp.Comment = dish.Element("Comment").Value;
            dish_tmp.Score = double.Parse(dish.Element("Score").Value);
            dishList.Add(dish_tmp);
        }
        return dishList;
    }
}
