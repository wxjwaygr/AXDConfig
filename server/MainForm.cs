/*
 * 由SharpDevelop创建。
 * 用户： AXD-VST-3360
 * 日期: 2016/4/8
 * 时间: 14:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text;
using System.Timers;
namespace server
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        enum AdapaterState
        {
            All,
            EthernetWirelessUseing
        }
        #region 字段
        /// <summary>
        /// 控件cbxNetworkAdapter选中的Index,用于修改IP地址重新加载再选中
        /// </summary>
        private int selectIndex = 0;

        /// <summary>
        /// 查询到指定状态网络适配器
        /// </summary>
        private AdapaterState state;

        HttpHelper http =new HttpHelper ();
		HttpItem item;
		//Ping p1=new	Ping();
		private void showping()
		{
			
			System.Timers.Timer t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒 就是1秒；
			t.Elapsed += new System.Timers.ElapsedEventHandler(trick);//到达时间的时候执行事件；
			t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
			t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
			
			System.Timers.Timer t2 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒 就是1秒；
			t2.Elapsed += new System.Timers.ElapsedEventHandler(trick2);//到达时间的时候执行事件；
			t2.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
			t2.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
			
			System.Timers.Timer t3 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒 就是1秒；
			t3.Elapsed += new System.Timers.ElapsedEventHandler(trick3);//到达时间的时候执行事件；
			t3.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
			t3.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
			
			System.Timers.Timer t4 = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒 就是1秒；
			t4.Elapsed += new System.Timers.ElapsedEventHandler(trick4);//到达时间的时候执行事件；
			t4.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
			t4.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
		}
		private void trick4(object sender, EventArgs e)
		{
			this.Invoke(new TextOption4(tping4));//invok 委托实现跨线程的调用
		}
		private void trick3(object sender, EventArgs e)
		{
			this.Invoke(new TextOption3(tping3));//invok 委托实现跨线程的调用
		}
		private void trick2(object sender, EventArgs e)
		{
			this.Invoke(new TextOption2(tping2));//invok 委托实现跨线程的调用
		}
		private void trick(object sender, EventArgs e)
		{
			this.Invoke(new TextOption(tping));//invok 委托实现跨线程的调用
		}
		private void tping4()
		{
            try
            {
                Ping p4 = new Ping();
                p4.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack4);//设置PingCompleted事件处理程序
                p4.SendAsync("www.163.com", null);
            }
            catch
            { }
		}
		private void tping3()
		{
            try
            {
                Ping p3 = new Ping();
                p3.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack3);//设置PingCompleted事件处理程序
                p3.SendAsync("192.168.3.100", null);
            }
            catch
            {

            }
		}
		private void tping2()
		{
            try
            {
                Ping p2 = new Ping();
                p2.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack2);//设置PingCompleted事件处理程序
                p2.SendAsync("10.254.0.1", null);
            }
            catch
            { }
		}
		private void tping()
		{
            try
            {
                Ping p1 = new Ping();
                p1.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack);//设置PingCompleted事件处理程序
                p1.SendAsync("192.168.253.200", null);
            }
            catch
            { }
		}
		delegate void TextOption();//定义一个委托
		delegate void TextOption2();//定义一个委托
		delegate void TextOption3();//定义一个委托
		delegate void TextOption4();//定义一个委托
		private void PingCompletedCallBack(object sender, PingCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				listBox1.Items.Add("Ping Canncel");
				return;
			}
			if (e.Error != null)
			{
				listBox1.Items.Add(e.Error.Message);
				return;
			}
			StringBuilder sbuilder;
			PingReply reply = e.Reply;
			if (reply.Status == IPStatus.Success)
			{
				sbuilder = new StringBuilder();
				sbuilder.Append(string.Format("地址: {0} ", reply.Address.ToString()));
				sbuilder.Append(string.Format("往返时间: {0} ", reply.RoundtripTime));
				sbuilder.Append(string.Format("存在时间: {0} ", reply.Options.Ttl));
				sbuilder.Append(string.Format("分割包: {0} ", reply.Options.DontFragment));
				sbuilder.Append(string.Format("字节: {0} ", reply.Buffer.Length));
				listBox1.Items.Add(sbuilder.ToString());
				toolStripStatusLabel1.Text="AP连接成功，延迟时间："+reply.RoundtripTime.ToString();
				toolStripStatusLabel1.ForeColor=Color.Green;
			}
			else
			{
				listBox1.Items.Add(reply.Status);
				toolStripStatusLabel1.Text="AP连接超时！";
				toolStripStatusLabel1.ForeColor=Color.Red;
			}
		}
		private void PingCompletedCallBack2(object sender, PingCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				listBox3.Items.Add("Ping Canncel");
				return;
			}
			if (e.Error != null)
			{
				listBox3.Items.Add(e.Error.Message);
				return;
			}
			StringBuilder sbuilder;
			PingReply reply = e.Reply;
			if (reply.Status == IPStatus.Success)
			{
				sbuilder = new StringBuilder();
				sbuilder.Append(string.Format("地址: {0} ", reply.Address.ToString()));
				sbuilder.Append(string.Format("往返时间: {0} ", reply.RoundtripTime));
				sbuilder.Append(string.Format("存在时间: {0} ", reply.Options.Ttl));
				sbuilder.Append(string.Format("分割包: {0} ", reply.Options.DontFragment));
				sbuilder.Append(string.Format("字节: {0} ", reply.Buffer.Length));
				listBox3.Items.Add(sbuilder.ToString());
				toolStripStatusLabel3.Text="MINI连接成功，延迟时间："+reply.RoundtripTime.ToString();
				toolStripStatusLabel3.ForeColor=Color.Green;
			}
			else
			{
				listBox3.Items.Add(reply.Status);
				toolStripStatusLabel3.Text="MINI连接超时！";
				toolStripStatusLabel3.ForeColor=Color.Red;
			}
		}
		
		private void PingCompletedCallBack3(object sender, PingCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				listBox4.Items.Add("Ping Canncel");
				return;
			}
			if (e.Error != null)
			{
				listBox4.Items.Add(e.Error.Message);
				return;
			}
			StringBuilder sbuilder;
			PingReply reply = e.Reply;
			if (reply.Status == IPStatus.Success)
			{
				sbuilder = new StringBuilder();
				sbuilder.Append(string.Format("地址: {0} ", reply.Address.ToString()));
				sbuilder.Append(string.Format("往返时间: {0} ", reply.RoundtripTime));
				sbuilder.Append(string.Format("存在时间: {0} ", reply.Options.Ttl));
				sbuilder.Append(string.Format("分割包: {0} ", reply.Options.DontFragment));
				sbuilder.Append(string.Format("字节: {0} ", reply.Buffer.Length));
				listBox4.Items.Add(sbuilder.ToString());
				toolStripStatusLabel5.Text="铁盒连接成功，延迟时间："+reply.RoundtripTime.ToString();
				toolStripStatusLabel5.ForeColor=Color.Green;
			}
			else
			{
				listBox4.Items.Add(reply.Status);
				toolStripStatusLabel5.Text="铁盒连接超时！";
				toolStripStatusLabel5.ForeColor=Color.Red;
			}
		}
		private void PingCompletedCallBack4(object sender, PingCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				listBox5.Items.Add("Ping Canncel");
				return;
			}
			if (e.Error != null)
			{
				listBox5.Items.Add(e.Error.Message);
				return;
			}
			StringBuilder sbuilder;
			PingReply reply = e.Reply;
			if (reply.Status == IPStatus.Success)
			{
				sbuilder = new StringBuilder();
				sbuilder.Append(string.Format("地址: {0} ", reply.Address.ToString()));
				sbuilder.Append(string.Format("往返时间: {0} ", reply.RoundtripTime));
				sbuilder.Append(string.Format("存在时间: {0} ", reply.Options.Ttl));
				sbuilder.Append(string.Format("分割包: {0} ", reply.Options.DontFragment));
				sbuilder.Append(string.Format("字节: {0} ", reply.Buffer.Length));
				listBox5.Items.Add(sbuilder.ToString());
				toolStripStatusLabel7.Text="互联网连接成功，延迟时间："+reply.RoundtripTime.ToString();
				toolStripStatusLabel7.ForeColor=Color.Green;
			}
			else
			{
				listBox5.Items.Add(reply.Status);
				toolStripStatusLabel7.Text="互联网连接超时！";
				toolStripStatusLabel7.ForeColor=Color.Red;
			}
		}
		public MainForm()
		{

			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        void btnHtmlClick(object sender, EventArgs e)
        {
            //HttpItem item = new HttpItem()
            //{
            //	URL =this.tboxAddress.Text.Trim(),//URL这里都是测试     必需项
            //	Method = "get",//URL     可选项 默认为Get
            //};
            //HttpResult result = http.GetHtml(item);
            //richTextBox1.Text=result.ToString();
            try
            {
                item = new HttpItem()
                {
                    URL = "http://192.168.253.200/goform/formPassword",//URL这里都是测试URl   必需项
                    Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                                    //Encoding = Encoding.Default,
                    Method = "post",//URL     可选项 默认为Get
                    ContentType = "application/x-www-form-urlencoded",
                    Postdata = "password=00509c4eee4657da3350647879179e3e",
                    Allowautoredirect = true
                };
                //得到新的HTML代码
                HttpResult result = http.GetHtml(item);
                MessageBox.Show(result.StatusDescription);
                item = new HttpItem()
                {
                    URL = "http://192.168.253.200/cgi-bin/upload.cgi",
                    Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                                    //Encoding = Encoding.Default,
                    Method = "post",//URL     可选项 默认为Get
                    ContentType = "application/octet-stream",
                   // PostdataByte = "password=00509c4eee4657da3350647879179e3e",
                    Allowautoredirect = true
                };
                result = http.GetHtml(item);//目前这个里面是未登入的状态
                                            //表示访问成功，具体的大家就参考HttpStatusCode类
                label2.Text = result.Html;
                //webbrow webBrow = new webbrow(item.URL);
            }
            catch
            {

            }
            }
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		void Button2Click(object sender, EventArgs e)
		{
            try
            {
                item = new HttpItem()
                {
                    URL = "http://192.168.253.200/goform/formPassword",//URL这里都是测试URl   必需项
                    Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                                    //Encoding = Encoding.Default,
                    Method = "post",//URL     可选项 默认为Get
                    ContentType = "application/x-www-form-urlencoded",
                    Postdata = "password=00509c4eee4657da3350647879179e3e",
                    Allowautoredirect = true
                };
                //得到新的HTML代码
                HttpResult result = http.GetHtml(item);
                MessageBox.Show(result.StatusDescription);
                MessageBox.Show(result.StatusCode.ToString());
                richTextBox1.Clear();
                item = new HttpItem()
                {
                    URL = "http://192.168.253.200/index.asp",
                };
                result = http.GetHtml(item);//目前这个里面是未登入的状态
                                            //表示访问成功，具体的大家就参考HttpStatusCode类
                richTextBox1.Text = result.Html;
                webbrow webBrow = new webbrow(item.URL);
                //webBrow.Show();
                //调用IE浏览器
                //System.Diagnostics.Process.Start("iexplore.exe", item.URL);
                System.Diagnostics.Process process = System.Diagnostics.Process.Start("iexplore.exe", item.URL);
                //调用系统默认的浏览器
                //System.Diagnostics.Process.Start( item.URL);
            }
            catch
            {
                MessageBox.Show("无法打开");
            }
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.listBox2.Text="开始链接。。。。。";
			showping();
            listBox2.SelectedIndex = 0;
           
        }
		void Button3Click(object sender, EventArgs e)
		{
            item = new HttpItem()
            {
                URL = "http://10.254.0.1/goform/formPassword",//URL这里都是测试URl   必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                                //Encoding = Encoding.Default,
                Method = "post",//URL     可选项 默认为Get
                ContentType = "application/x-www-form-urlencoded",
                Postdata = "password=abcd.1234",
                Allowautoredirect = true
            };
            //得到新的HTML代码
            HttpResult result = http.GetHtml(item);
            richTextBox1.Clear();
            item = new HttpItem()
            {
                URL = "http://10.254.0.1/index.asp",
            };
            result = http.GetHtml(item);//目前这个里面是未登入的状态
                                        //表示访问成功，具体的大家就参考HttpStatusCode类
            webbrow webBrow = new webbrow(item.URL);
            System.Diagnostics.Process process = System.Diagnostics.Process.Start("iexplore.exe", item.URL);
            item = new HttpItem()
            {
                URL = "http://10.254.0.1/web/sysinfo/baseinfo.asp",
            };
            result = http.GetHtml(item);
            //richTextBox1.Text = result.

            //webBrow.Show();
            //调用IE浏览器
            //System.Diagnostics.Process.Start("iexplore.exe", item.URL);

            //调用系统默认的浏览器
            //System.Diagnostics.Process.Start( item.URL);
            //Uri uri = new Uri("http://192.168.253.200/login.asp?password=1234.abcd");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            //var cache = new CredentialCache();
            //cache.Add(uri, "Basic", new NetworkCredential("admin", "admin"));
            //request.Credentials = cache;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader read = new StreamReader(response.GetResponseStream(), Encoding.Default);
            //string text = read.ReadToEnd();
            //richTextBox1.Text=text;
        }
        void StatusStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}
		void Button4Click(object sender, EventArgs e)
		{
            CmdHelper ch = new CmdHelper();
            string output = "";
            CmdHelper.RunCmd(tboxAddress.Text.Trim(), out output);
            richTextBox1.Text = output;
			//GetCmd();
		}
		private void GetCmd()
		{
			Process cmd = new Process();
			cmd.StartInfo.FileName = "ipconfig.exe";//设置程序名
			cmd.StartInfo.Arguments = "/all";  //参数
			//重定向标准输出
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.StartInfo.CreateNoWindow = true;//不显示窗口（控制台程序是黑屏）
			//cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//暂时不明白什么意思
			/* 
13 收集一下 有备无患
14        关于:ProcessWindowStyle.Hidden隐藏后如何再显示？
15        hwndWin32Host = Win32Native.FindWindow(null, win32Exinfo.windowsName);
16        Win32Native.ShowWindow(hwndWin32Host, 1);     //先FindWindow找到窗口后再ShowWindow
17        */
			cmd.Start();
			string info = cmd.StandardOutput.ReadToEnd();
			cmd.WaitForExit();
			cmd.Close();
			richTextBox1.Text=(info);
		}
		void loadinterface()
		{
			//获取说有网卡信息
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface adapter in nics) 
			{
//				if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
//				{
					//获取以太网卡网络接口信息
					IPInterfaceProperties ip = adapter.GetIPProperties();
					//获取单播地址集
					UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
					foreach (UnicastIPAddressInformation ipadd in ipCollection)
					{
						//InterNetwork    IPV4地址      InterNetworkV6        IPV6地址
						//Max            MAX 位址
						if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
							//判断是否为ipv4
							listBox2.Items.Add( ipadd.Address.ToString()+adapter.NetworkInterfaceType.ToString());//获取ip
					
					}
			}
				
			}
        #region 方法
        /// <summary>
        /// 绑定Wireless,Ehternet类型 UP的配制器
        /// </summary>
        /// <returns></returns>
        private void BindEthernetWirelessAdaptersUP()
        {
            NetworkAdapterUtil util = new NetworkAdapterUtil();
            List<NetworkAdapter> lists = util.GetEthernetWirelessNetworkAdaptersUP();

            cbxNetworkAdapter.DataSource = lists; //重新绑定数据

            if (cbxNetworkAdapter != null && cbxNetworkAdapter.Items.Count > selectIndex)
            {
                cbxNetworkAdapter.SelectedIndex = selectIndex;
            }
        }

        /// <summary>
        /// 绑定所有适配器
        /// </summary>
        private void BindAllAdapters()
        {

            NetworkAdapterUtil util = new NetworkAdapterUtil();
            List<NetworkAdapter> lists = util.GetAllNetworkAdapters(); //得到所有适配器;

            cbxNetworkAdapter.DataSource = lists; //重新绑定数据

            if (cbxNetworkAdapter != null && cbxNetworkAdapter.Items.Count > selectIndex)
            {
                cbxNetworkAdapter.SelectedIndex = selectIndex;
            }
        }

        /// <summary>
        /// 绑定适配器,会根据state的值绑定
        /// </summary>
        private void BindAdapters()
        {

            if (state == AdapaterState.All)
            {
                BindAllAdapters();
            }
            else if (state == AdapaterState.EthernetWirelessUseing)
            {
                BindEthernetWirelessAdaptersUP();
            }
        }
        #endregion
        static void SetNetworkAdapter()
		{
			ManagementBaseObject inPar = null;
			ManagementBaseObject outPar = null;
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();
			foreach (ManagementObject mo in moc)
			{
				if (!(bool)mo["IPEnabled"])
					continue;

				//设置ip地址和子网掩码
				inPar = mo.GetMethodParameters("EnableStatic");
				inPar["IPAddress"] = new string[] { "192.168.16.248", "192.168.16.249" };// 1.备用 2.IP
				inPar["SubnetMask"] = new string[] { "255.255.255.0", "255.255.255.0" };
				outPar = mo.InvokeMethod("EnableStatic", inPar, null);

				//设置网关地址
				inPar = mo.GetMethodParameters("SetGateways");
				inPar["DefaultIPGateway"] = new string[] { "192.168.16.2", "192.168.16.254" };// 1.网关;2.备用网关
				outPar = mo.InvokeMethod("SetGateways", inPar, null);

				//设置DNS
				inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
				inPar["DNSServerSearchOrder"] = new string[] { "211.97.168.129", "202.102.152.3" };// 1.DNS 2.备用DNS
				outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
				break;
			}
		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
            tboxAddress.Text = listBox2.SelectedItem.ToString();

        }
		void ToolStripDropDownButton1Click(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
			this.listBox3.Items.Clear();
			this.listBox4.Items.Clear();
			this.listBox5.Items.Clear();
		}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.Start();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnSetAutoIPAddress_Click(object sender, EventArgs e)
        {
            NetworkAdapter adapter = cbxNetworkAdapter.SelectedItem as NetworkAdapter; //获取到选中的适配器
            if (adapter == null) MessageBox.Show("请先选择适配器");
            selectIndex = cbxNetworkAdapter.SelectedIndex; //控件cbxNetworkAdapter选中的Index,用户重新加载再选中

            if (adapter.EnableDHCP()) //设置自动获取IP地址
            {
                MessageBox.Show("设置自动获取IP成功");
                BindAdapters();////绑定适配器
            }
            else
            {
                MessageBox.Show("设置自动获取IP失败");

            }
        }
        //获取所有启用网络适配器地址 事件， 如果网卡是禁用的是获取不到
        private void tsBtnDisplayAllNetwork_Click(object sender, EventArgs e)
        {
            tsBtnUsingNetwork.BackColor = SystemColors.Control;
            tsBtnDisableAdapters.BackColor = Color.SkyBlue;
            state = AdapaterState.All;
            selectIndex = 0;
            BindAdapters();
        }

        private void tsBtnDisableAdapters_Click(object sender, EventArgs e)
        {
            try
            {
                new NetworkAdapterUtil().DisableAllAdapters();
                MessageBox.Show("禁用所有网络连接成功");
                // BindAdapters(); //绑定适配器
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsBtnUsingNetwork_Click(object sender, EventArgs e)
        {
            tsBtnUsingNetwork.BackColor = Color.SkyBlue;
            tsBtnDisplayAllNetwork.BackColor = SystemColors.Control;


            state = AdapaterState.EthernetWirelessUseing;

            BindAdapters();  //重新获取适配器信息并绑定
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage.Text=="网络连接")
            {
                tsBtnUsingNetwork.BackColor = Color.SkyBlue;
                cbxNetworkAdapter.DisplayMember = "Description";
                state = AdapaterState.EthernetWirelessUseing;
                BindAdapters();
            }
        }

        private void btnGetIPAddress_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkAdapter adapter = cbxNetworkAdapter.SelectedItem as NetworkAdapter;
                if (adapter == null) MessageBox.Show("请先选择适配器");
                selectIndex = cbxNetworkAdapter.SelectedIndex; //获取适配器的index,为了重新加载再选上这

                string ipAddress = txtIpAddress.Text.Trim(); //IP地址
                string subMask = txtMask.Text.Trim(); //子网掩码           
                string getWay = txtGetway.Text.Trim(); //网关             
                string dnsMain = txtDnsMain.Text.Trim(); //主DNS
                string dnsBackup = txtDnsBackup.Text.Trim(); //备用DNS
                string reslut = adapter.IsIPAddress(ipAddress, subMask, getWay, dnsMain, dnsBackup); //检查输入设置的IP地址，如果返回空，表示成功，否则就失败
                if (!string.IsNullOrEmpty(reslut))
                {
                    MessageBox.Show(reslut);
                    return;
                }

                if (!adapter.SetIPAddressAndSubMask(ipAddress, subMask))//设置IP地址和子网掩码
                {
                    MessageBox.Show("设置IP地址和子网掩码失败");
                    return;
                }

                if (!string.IsNullOrEmpty(getWay))
                {
                    if (!adapter.SetGetWayAddress(getWay)) //设置网关地址
                    {
                        MessageBox.Show("设置网关地址失败");
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(dnsMain))
                {
                    if (!adapter.SetDNSAddress(dnsMain, dnsBackup)) //设置DNS地址;
                    {
                        MessageBox.Show("设置DNS失败");
                        return;
                    }
                }

                MessageBox.Show("设置IP地址成功");
                BindAdapters(); //绑定适配器

            }
            catch (Exception)
            {
                MessageBox.Show("Catch Exception!!!");
            }

        }

        private void cbxNetworkAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            NetworkAdapter adapter = cbxNetworkAdapter.SelectedItem as NetworkAdapter; //获取到选中的适配器
            txtIpAddress.Text = adapter.IpAddress;
            txtGetway.Text = adapter.Getway;
            txtMask.Text = adapter.Mask;
            txtPhycilAddress.Text = adapter.MacAddres;
            txtDnsMain.Text = adapter.DnsMain;
            txtDnsBackup.Text = adapter.DnsBackup;
            txtDhcpServer.Text = adapter.DhcpServer;
            if (adapter.IsDhcpEnabled)
            {
                cbxGetIPMethod.SelectedIndex = 0;
            }
            else
            {
                cbxGetIPMethod.SelectedIndex = 1;
            }
        }

        private void cbxGetIPMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDhcpServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsBtnEnableAdapters_Click(object sender, EventArgs e)
        {
            try
            {
                new NetworkAdapterUtil().EnableAllAdapters();
                MessageBox.Show("启用所有网络连接成功");
                //  BindAdapters(); //绑定适配器

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tsBtnAllIPReport_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.Show();
        }
    }




    }

#endregion