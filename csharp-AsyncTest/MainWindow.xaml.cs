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


    //===================== ���淽�� ================================

    private void ClearText_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
    }

    //===================== ͬ�����ط��� ================================

    /// <summary>
    /// ͬ�����ط�������ť���ִ��ʱ����UI���棬�����ƶ�����ҳ�棬���Ƽ�����Ӧ�ñ������ʹ�÷�����
    /// </summary>
    private void SyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        DownloadWebsitesSync();
        Result.Text += $"���ķ�ʱ�� : {stopwatch.Elapsed}{Environment.NewLine}";
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

        return $"�� {item} ����������ݡ������� Bytes {responsePayLoadBytes.Length}.{Environment.NewLine}";
    }


    //===================== ��ѭ�����߳����ط��� ================================
    /// <summary>
    /// ��ѭ�����߳����ط���for loop��ʹ���첽��������Ȼ���̷ֳ߳����̣߳�������ѭ���Ĵ��ڣ�����ʱ��ͬ���첽�������
    /// ˳�������߳�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SingleMulitThreadDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesSingleMulitThreadAsync();
        Result.Text += $"���ķ�ʱ�� : {stopwatch.Elapsed}{Environment.NewLine}";
    }

    /// <summary>
    /// ��ѭ�����첽���أ��ײ�ʹ��ͬ������
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesSingleMulitThreadAsync()
    {
        foreach (var item in Contents.WebSites)
        {
            //Task.Run���̣߳��������첽����������һ���̺߳ķ���Դ��
            var result = await Task.Run(() => DownloadWebsiteSync(item));
            ReportResult(result);
        }
    }


    //===================== �첽���ط������ײ�ʹ��ͬ�������� ================================
    /// <summary>
    /// �첽���ط�������ť����
    /// </summary>
    private async void ASyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesAsync();
        Result.Text += $"���ķ�ʱ�� : {stopwatch.Elapsed}{Environment.NewLine}";
    }


    /// <summary>
    /// ���߳��첽���ײ�ʹ��ͬ�����������߳��첽��������������ʱ�䣻���ײ���ͬ�����������´���������ʱ��(������ҳ����IO bound��˵)��
    /// ͬʱ�������߳�
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesAsync()
    {
        List<Task<string>> downloadWebsitesTasks = new();

        foreach (var item in Contents.WebSites)
        {
            //�˴���������һThread,�ʺ�CPU bound�����ڵ��õ�DownloadWebsiteSync�ǵ��̣߳����ʹ��Task.Run�����̡߳�
            downloadWebsitesTasks.Add( Task.Run(()=> DownloadWebsiteSync(item)));  
        }

        var results = await Task.WhenAll(downloadWebsitesTasks); //ͬʱ��������߳�

        foreach (var result in results)
        {
            ReportResult(result);
        }

    }


    //===================== �첽���ط���-�ײ㿪ʼ�첽���� ================================
    /// <summary>
    /// ���ַ�ʽ���ڴӿ�ʼʹ���첽+���̵߳ķ������ٶ���졣
    /// ���߳�+�첽
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesAllAsync()
    {
        List<Task<string>> downloadWebsitesTasks = new();

        foreach (var item in Contents.WebSites)
        {
            //û�е�������Thread,ʹ�����ϼ����������̣߳��˴��ʺ�IO bound�����õ�DownloadWebsiteAsync�Ƕ��̣߳�����ʵ�ֶ��߳�����
            downloadWebsitesTasks.Add( DownloadWebsiteAsync(item));  
        }

        var results = await Task.WhenAll(downloadWebsitesTasks);  //ȫ��������ɺ󣬵ķ��ؽ����ÿ�����񷵻ؽ�����б�

        foreach (var result in results)
        {
            ReportResult(result);
        }

    }

    /// <summary>
    /// ���ص�����ҳʹ��Async������ע�ⵥ����ҳ����Ҳ��ʼʹ��await�ؼ��֡�
    /// </summary>
    /// <param name="url">������ҳ��ַ</param>
    /// <returns></returns>
    private async Task<string> DownloadWebsiteAsync(string url)
    {
        var response =await httpClient.GetAsync(url);
        var responsePayLoadBytes = await response.Content.ReadAsByteArrayAsync();

        return $"�� {url} ����������ݡ������� Bytes {responsePayLoadBytes.Length}.{Environment.NewLine}";
    }

    private async void AllAsyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesAllAsync();
        Result.Text += $"���ķ�ʱ�� : {stopwatch.Elapsed}{Environment.NewLine}";
    }



    //===================== ��ѭ�����߳����ط��� ================================
    /// <summary>
    /// ��ѭ�����߳����ط���for loop��ʹ���첽��������Ȼ���̷ֳ߳����̣߳�������ѭ���Ĵ��ڣ�����ʱ��ͬ���첽�������
    /// ˳�������߳�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SingleASyncDownload_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = "";
        var stopwatch = Stopwatch.StartNew();
        await DownloadWebsitesSingleAsync();
        Result.Text += $"���ķ�ʱ�� : {stopwatch.Elapsed}{Environment.NewLine}";
    }

    /// <summary>
    /// ��ѭ�����첽���أ��ײ�ʹ��ͬ������
    /// </summary>
    /// <returns></returns>
    private async Task DownloadWebsitesSingleAsync()
    {
        foreach (var item in Contents.WebSites)
        {
            //Task.Run���̣߳��������첽����������һ���̺߳ķ���Դ��
            var result = await  DownloadWebsiteAsync(item);
            ReportResult(result);
        }
    }



}
