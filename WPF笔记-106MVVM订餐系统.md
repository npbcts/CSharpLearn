## WPF桌面程序 学习笔记 第N章  使用MVVM编写餐馆订餐系统

来源于: 根据[刘铁猛 《深入浅出WPF》系列高清视频教程](https://www.bilibili.com/video/BV1ht411e7Fe/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=db5f224185fdd2c28b4cc762ebce92fe)整理。

这是一个稍微复杂的MVVM结构实现WPF界面程序的例子。例子中包含了业务抽象成Model过程,业务操作/显示界面View和两者的中间处理过程ViewModel，也有业务数据Data与ViewModel中通信的Service过程。
通过例子，我们能够进一步深入了解MVVM的运行机制，和业务抽象成对象的面向对象编程思想。


### 需求和分析需求

确定实现目标是编写软件的开始，而分析需求并抽象化是面向对象编程的十分重要的部分。

我们要编写一个餐馆订餐系统。顾客查看菜单，选在其中的菜品中的项目后，确定点餐，系统将选择的菜品条目保存。

界面如下:

![订餐系统界面](WPF笔记-106-1订餐系统界面.png)

我们可以看到，界面中有餐馆信息`Restaurant`、菜品列表信息`Dish`、显示订餐信息的文本框和订餐按钮。

因此我们可以将数据部分抽象成两大类，餐馆信息类和菜单信息类。由于菜单信息包含条目较多，我们创建一个单独的数据文件保存，这样也方便修改菜品。因此我们按照`MVVM`的管理创建`Models`文件夹保存抽象的类文件和`Data`保存具体的数据文件。

当然实际程序开发中，餐厅的信息也应该有单独的数据文件保存，这样做参观信息能够方便修改使系统更为通用，避免了信息硬编码至代码的弊端。此练习实例不单独创建文件保存。

前端界面的设计，可以结合业务需求进行规划和创建，选择使用的界面元素满足业务需求。界面设计实际上是个复杂的过程，但本实例主要讲述`MVVM`框架的实现。因此前端界面直接使用图片中的界面实现，即上部采取文字块`TextBlock`描述餐馆信息，下半部菜单使用`DataGrid`列表结合`CheckButton`列示选择菜品,界面最后使用`Button`确认点餐和`TextBox`空间统计菜品总数。

但对于MVVM来说，无论采取何种形式的界面，都不影响后端数据处理逻辑的构建，这也是使用这种设计模式需要达到的目的。

之后是围绕`MVVM`的核心 `ViewModel`构建类。我们需要将`Model`在此处实例化并填充数据，赋值给能够对外暴露的属性供前端`View`使用。对于填充数据的部分，我们采取两种方式：

- 直接创建类餐馆信息类`Restaurant`实例，并在此处填充实例信息。实例作为属性以供`View`使用。  
- 对于列表信息`Dish`，我们需要读取`Data.xm`保存的菜品信息数据实现。为了保持可扩展，我们创建`Service`部分，具体为能够实现`List<Dish> GetAllDishs();`的 `IDataServices`接口，即一种能够返回`List<Dish>`的方法。如果未来菜单信息保存在数据库中，可以使用实现此接口的数据库读取类。本例中创建了实现`IDataServices`接口的读取`Data.xml`文件的类。  
- 进一步思考`Dish`的功能：


### 创建Model数据模型

创建菜单类`Models.Dish.cs`:
```c#
namespace CrazyElephant.Client.Models;

//对应data文件夹中单条数据模型
internal class Dish
{
    public string Name{get; set;}  // 菜品名称
    public string Category{get; set;}  //  种类
    public string Comment{get; set;}  //  点评
    public double Score{get; set;}  //  推荐分数
}
```
我们看到，这里创建了`Dish`菜单类四个属性，而界面中显示还有`选中`项目。这里的考虑是，选中项目是界面交互的要素，而不是纯的数据抽象，因此将此项目放在`ViewModel`中，而不是放在此处。

餐馆信息类`Models.Restaurant.cs`:
```c#
namespace CrazyElephant.Client.Models;
internal class Restaurant
{
    public string Name{get; set;}  // 餐馆名
    public string Address{get; set;}  // 餐馆地址
    public string PhoneNumber{get; set;} //订餐电话 
}
```

`Data`文件夹中单独保存菜单信息的`Data.xml`文件:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Dishes>
  <Dish>
    <Name>土豆泥底披萨</Name>
    <Category>披萨</Category>
    <Comment>本店特色</Comment>
    <Score>4.5</Score>
  </Dish>
  <Dish>
    <Name>烤囊底披萨</Name>
    <Category>披萨</Category>
    <Comment>本店特色</Comment>
    <Score>5</Score>
  </Dish>
  <Dish>
    <Name>水果披萨</Name>
    <Category>披萨</Category>
    <Comment>本店特色</Comment>
    <Score>4</Score>
  </Dish>
  ......
</Dishes>
```





```c#

```

(End)