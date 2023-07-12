using System.Windows;
using WinProxyTool_Adonis.ViewModels;
namespace WinProxyTool_Adonis.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindow_ViewModel();
        }

        
    }
}
