using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;

namespace ToaruLyricDownloader
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await Browser.EnsureCoreWebView2Async(null);
            Browser.CoreWebView2.Navigate("https://toaru-web.net/2021/06/10/%e3%82%b5%e3%82%a4%e3%83%88%e4%b8%80%e8%a6%a7/"); //開きたいURL
            Browser.CoreWebView2.NewWindowRequested += NewWindowRequested; //以下同文
        }

        private void NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            //新しいウィンドウを開かなくする
            e.Handled = true;

            //元々のWebView2でリンク先を開く
            Browser.CoreWebView2.Navigate(e.Uri);
        }

        //使用予定のサイト
        //https://kashinavi.com/song_view.html?148732

    }
}
