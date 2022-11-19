using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSimple.ViewModels;
//这是实现界面和后台双向通信的基类，ViewModel其他类继承自此基类即可实现双向通知的功能
//即后台数据变化后通知界面并变化，界面数据变化后反馈给后台数据。
//最终在控件中使用bingding绑定后台字段名称即可实现解耦。
//双向通知功能通过继承  INotifyPropertyChanged 接口实现。继承后事项接口约定的PropertyChanged事件即可。
internal class NotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void RaiseProptyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
