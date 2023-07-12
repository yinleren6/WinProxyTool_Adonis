using System;
using WinProxyTool_Adonis.Framework;
using WinProxyTool_Adonis.Models;
using WinProxyTool_WPF.Utils;

namespace WinProxyTool_Adonis.ViewModels
{
    class MainWindow_ViewModel : ViewModel
    {
        private MainWindow_Model main_window = new MainWindow_Model();

        public WinRegTool winRegTool = new WinRegTool();
        public MainWindow_ViewModel()
        {
            init();
        }

        private void init()
        {    //获取当前的系统设置,填入
            main_window.Proxy_Enable = winRegTool.Get_ProxyEnable();
            main_window.Ip_Address = winRegTool.Get_ProxyIP();
            main_window.Ip_Port = winRegTool.Get_ProxyPort();
        }
        public bool Proxy_Enable
        {
            get { return main_window.Proxy_Enable; }
            set
            {
                main_window.Proxy_Enable = value;
                this.RaisePropertyChanged("Proxy_Enable");
            }
        }
        public string Ip_Address
        {
            get { return main_window.Ip_Address; }
            set
            {
                main_window.Ip_Address = value;
                this.RaisePropertyChanged("Ip_Address");
            }
        }
        public int Ip_Port
        {
            get { return main_window.Ip_Port; }
            set
            {
                main_window.Ip_Port = value;
                this.RaisePropertyChanged("Ip_Port");
            }
        }

        public void reload() { init(); }
        
    }
}
