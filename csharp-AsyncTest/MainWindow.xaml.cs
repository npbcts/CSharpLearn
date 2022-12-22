// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AsyncTest;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
    }


    //===================== 界面方法 ================================

    private void ClearText_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
    }

    //===================== 同步下载方法 ================================

    /// <summary>
    /// 同步下载方法，按钮命令。执行时阻塞UI界面，不能移动缩放页面，类似假死；应该避免此类使用方法。
    /// </summary>
    private void SyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        DownloadWebsitesSync();
        Result.Text += $"共耗费时间 : {stopwatch.Elapsed}{Environment.NewLine}";
    }


    private readonly HttpClient httpClient = new();
    private void DownloadWebsitesSync()
    {
        foreach (var item in Contents.WebSites)
        {
            var result = DownloadWebsiteSync(item);
            ReportResult(result);
        }
    }

    private void ReportResult(string result)
    {
        Result.Text += result;
    }

    private string DownloadWebsiteSync(string item)
    {
        var response = httpClient.GetAsync(item).GetAwaiter().GetResult();
        var responsePayLoadBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

        return $"从 {item} 完成下载数据。共返回 Bytes {responsePayLoadBytes.Length}.{Environment.NewLine}";
    }


    //===================== 单循环多线程下载方法 ================================
    /// <summary>
    /// 单循环多线程下载方法for loop中使用异步方法；虽然将线程分出主线程，但由于循环的存在，下载时间同非异步方法相近
    /// 顺序开启多线程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SingleMulitThreadDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesSingleMulitThreadAsync();
        Result.Text += $"共耗费时间 : {stopwatch.Elapsed}{Environment.NewLine}";
    }

    /// <summary>
    /// 单循环的异步下载，底层使用同步方法
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesSingleMulitThreadAsync()
    {
        foreach (var item in Contents.WebSites)
        {
            //Task.Run开线程，类似于异步操作；但开一个线程耗费资源。
            var result = await Task.Run(() => DownloadWebsiteSync(item));
            ReportResult(result);
        }
    }


    //===================== 异步下载方法，底层使用同步方法。 ================================
    /// <summary>
    /// 异步下载方法，按钮命令
    /// </summary>
    private async void ASyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesAsync();
        Result.Text += $"共耗费时间 : {stopwatch.Elapsed}{Environment.NewLine}";
    }


    /// <summary>
    /// 多线程异步，底层使用同步方法。多线程异步方法，极大缩短时间；但底部的同步方法，导致存在冷启动时间(对于网页下载IO bound来说)。
    /// 同时开启多线程
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesAsync()
    {
        List<Task<string>> downloadWebsitesTasks = new();

        foreach (var item in Contents.WebSites)
        {
            //此处单独开启一Thread,适合CPU bound；由于调用的DownloadWebsiteSync是单线程，因此使用Task.Run开启线程。
            downloadWebsitesTasks.Add( Task.Run(()=> DownloadWebsiteSync(item)));  
        }

        var results = await Task.WhenAll(downloadWebsitesTasks); //同时开启多个线程

        foreach (var result in results)
        {
            ReportResult(result);
        }

    }


    //===================== 异步下载方法-底层开始异步方法 ================================
    /// <summary>
    /// 这种方式属于从开始使用异步+多线程的方法，速度最快。
    /// 多线程+异步
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesAllAsync()
    {
        List<Task<string>> downloadWebsitesTasks = new();

        foreach (var item in Contents.WebSites)
        {
            //没有单独开启Thread,使用了上级程序开启的线程；此处适合IO bound；调用的DownloadWebsiteAsync是多线程，可以实现多线程下载
            downloadWebsitesTasks.Add( DownloadWebsiteAsync(item));  
        }

        var results = await Task.WhenAll(downloadWebsitesTasks);  //全部任务完成后，的返回结果是每个任务返回结果的列表

        foreach (var result in results)
        {
            ReportResult(result);
        }

    }

    /// <summary>
    /// 下载单个网页使用Async方法。注意单个网页请求也开始使用await关键字。
    /// </summary>
    /// <param name="url">下载网页地址</param>
    /// <returns></returns>
    private async Task<string> DownloadWebsiteAsync(string url)
    {
        var response =await httpClient.GetAsync(url);
        var responsePayLoadBytes = await response.Content.ReadAsByteArrayAsync();

        return $"从 {url} 完成下载数据。共返回 Bytes {responsePayLoadBytes.Length}.{Environment.NewLine}";
    }

    private async void AllAsyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesAllAsync();
        Result.Text += $"共耗费时间 : {stopwatch.Elapsed}{Environment.NewLine}";
    }



    //===================== 单循环多线程下载方法 ================================
    /// <summary>
    /// 单循环多线程下载方法for loop中使用异步方法；虽然将线程分出主线程，但由于循环的存在，下载时间同非异步方法相近
    /// 顺序开启多线程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SingleASyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesSingleAsync();
        Result.Text += $"共耗费时间 : {stopwatch.Elapsed}{Environment.NewLine}";
    }

    /// <summary>
    /// 单循环的异步下载，底层使用同步方法
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesSingleAsync()
    {
        foreach (var item in Contents.WebSites)
        {
            //Task.Run开线程，类似于异步操作；但开一个线程耗费资源。
            var result = await  DownloadWebsiteAsync(item);
            ReportResult(result);
        }
    }



}
