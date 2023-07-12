using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WinProxyTool_WPF.Utils
{
    public class WinRegTool
    {   //读取注册表
        readonly RegistryKey proxy = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);

        //代理开关 返回int
        public bool Get_ProxyEnable() { return (int)proxy.GetValue("ProxyEnable") == 1 ? true : false; }

        //代理IP地址 返回string (127.0.0.1:8080)
        private List<string> Get_ProxyServer()
        {
            string _ip = proxy.GetValue("ProxyServer") != null ? proxy.GetValue("ProxyServer") as string : "";
            List<string> _fallback = new List<string>();

            if (_ip != "")
            {
                try
                {
                    //分开ip 和 port

                    int index = _ip.IndexOf("://");
                    if (index == _ip.IndexOf(":"))
                    {
                        _ip = (string)_ip.Substring(index + 3);
                    }

                    if (_ip.IndexOf("://") == -1)
                    {
                        _fallback.Add((string)_ip.Split(':')[0]);
                        _fallback.Add((string)_ip.Split(':')[1]);
                    }

                }
                catch (Exception e) { }
                return _fallback;
            }
            else
            {
                _fallback.Add("");
                _fallback.Add("");
                return _fallback;
            }

        }
        public string Get_ProxyIP()
        {
            return Get_ProxyServer()[0];
        }
        public int Get_ProxyPort()
        {
            return int.Parse(Get_ProxyServer()[1]);
        }

        //代理绕过的地址 返回string
        public string Get_ProxyOverride() { return proxy.GetValue("ProxyOverride") != null ? proxy.GetValue("ProxyOverride") as string : ""; }


        public void Set_ProxyOverride(string proxyOverride) { proxy.SetValue("ProxyOverride", proxyOverride); }
        public void Set_ProxyEnable(int isEnabled) { proxy.SetValue("ProxyEnable", isEnabled); }
        public void Set_ProxyServer(string proxyServer) { proxy.SetValue("ProxyServer", proxyServer); }
    }
}
