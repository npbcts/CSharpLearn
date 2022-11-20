using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyElephant.Client.Models;
using Microsoft.Practices.Prism.ViewModel; //NuGet下载PrismMVVMLibrary

namespace CrazyElephant.Client.ViewModel;
//每单菜单项目包含菜品的信息和选项有否的信息，因此存在动作与单纯的保存信息的Dish不同
//将Dish的信息引入到DishMenuItem中有三种方法:
//1. 继承自类Dish，即DishMenuItemViewModes类是一个Dish
//2. 在DishMenuItemViewModes类中声明一个Dish类实例，即DishMenuItemViewModes类有一个Dish
//3. 直接在DishMenuItemViewModes中声明Dish的四个属性，即不再使用单独的Dish类
internal class DishMenuItemViewModel: NotificationObject
{
    public Dish Dish
    {
    get; set; }
    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            this.RaisePropertyChanged("isSelected");
        }
    }

    private bool isSelected;
}
