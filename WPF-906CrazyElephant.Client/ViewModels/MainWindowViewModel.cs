using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace CrazyElephant.Client.ViewModel;
internal class MainWindowViewModel: NotificationObject
{
    public DelegateCommand PlaceOrderCommand
    {
        get; set;
    }
    public DelegateCommand SelectMenuItemCommand
    {
        get; set;
    }
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            this.RaisePropertyChanged("Count");
        }
    }

    public Restaurant Restaurant
    {
        get => _restaurant;
        set
        {
            _restaurant = value;
            this.RaisePropertyChanged("Restaurant");
        }
    }

    public List<DishMenuItemViewModel> DishMenu
    {
        get => dishMenu;
        set
        {
            dishMenu = value;
            this.RaisePropertyChanged("DishMenu");
        }
    }

    private int _count;

    private Restaurant _restaurant;

    private List<DishMenuItemViewModel> dishMenu;



    private void LoadRestaurant()
    {
        this.Restaurant = new Restaurant();
        this.Restaurant.Name = "哈尔滨烧烤";
        this.Restaurant.Address = "沈阳市铁东区校园街道汇畅园8号";
        this.Restaurant.PhoneNumber = "13829389874";
    }

    private void LoadDishMenu()
    {
        XmlDataServices ds = new XmlDataServices();
        var dishes = ds.GetAllDishs();
        this.DishMenu = new List<DishMenuItemViewModel>();
        foreach (var dish in dishes)
        {
            DishMenuItemViewModel item = new();
            item.Dish = dish;
            this.DishMenu.Add(item);
        }
    }

    private void PlaceOrderCommandExcute()
    {
        // 此处，之索引能够从DishMenu中检索到已选择的菜品，是由于前端和后端数据具有双向通信机制；前端选中后，后端的属性也随之更改了。
        var selectedDishes = this.DishMenu.Where(i => i.IsSelected == true).Select(i=>i.Dish.Name).ToList();
        IOrderServices orderServices = new MockOrderServices();
        orderServices.PlaceOrder(selectedDishes);
        MessageBox.Show("订餐成功!");

    }

    private void SelectMenuItemExecute()
    {
        this.Count = this.DishMenu.Count(i=>i.IsSelected==true);
    }

    public MainWindowViewModel()
    {
        this.LoadRestaurant();
        this.LoadDishMenu();
        PlaceOrderCommand = new DelegateCommand(new Action(PlaceOrderCommandExcute));
        SelectMenuItemCommand = new DelegateCommand(new Action(SelectMenuItemExecute));

    }

}
