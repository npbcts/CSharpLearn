using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MVVMSimple.Commands;

namespace MVVMSimple.ViewModels;
class MainWindowViewModel: NotificationObject
{
    private double input1=2;

    //这是前端数据绑定的属性
    public double Input1
    {
    get
        {
            return input1; 
        } 

    set
        {
            input1 = value;
            //此处"Input1"一定与属性的名称一致即Input1
            //赋值同时，通知绑定的控件值已经变化
            this.RaiseProptyChanged("Input1");
        }
    }

    private double input2=3;

    public double Input2
    {
        get
        {
            return input2;
        }

        set
        {
            input2 = value;
            this.RaiseProptyChanged("Input2");
        }
    }


    private double result=5;

    public double Result
    {
        get
        {
            return result;
        }

        set
        {
            result = value;
            this.RaiseProptyChanged("Result");
        }
    }

    public DelegateCommand AddCommand
    {
        get; set;
    }

    private void Add(object parameter)
    {
        this.Result = this.Input1 + this.Input2;
    }


    public DelegateCommand SaveCommand
    {
        get; set;
    }
    private void Save(object parameter)
    {
        SaveFileDialog dig = new SaveFileDialog();
        dig.ShowDialog();
    }

    public MainWindowViewModel()
    {
        //在这里委托绑定方法，前端界面上命令按钮命令绑定的是一种委托
        this.AddCommand = new DelegateCommand();
        this.AddCommand.ExcuteAction = new Action<object>(this.Add);

        this.SaveCommand= new DelegateCommand();    
        this.SaveCommand.ExcuteAction= new Action<object>(this.Save);
    }


}
