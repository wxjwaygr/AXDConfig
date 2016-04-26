/*
 * 由SharpDevelop创建。
 * 用户： AXD-VST-3360
 * 日期: 2016/4/8
 * 时间: 14:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
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
		HttpHelper http=new HttpHelper ();
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
			Ping p4 = new Ping();
			p4.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack4);//设置PingCompleted事件处理程序
			p4.SendAsync("www.163.com", null);
		}
		private void tping3()
		{
			Ping p3 = new Ping();
			p3.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack3);//设置PingCompleted事件处理程序
			p3.SendAsync("192.168.3.100", null);
		}
		private void tping2()
		{
			Ping p2 = new Ping();
			p2.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack2);//设置PingCompleted事件处理程序
			p2.SendAsync("10.254.0.1", null);
		}
		private void tping()
		{
			Ping p1 = new Ping();
			p1.PingCompleted += new PingCompletedEventHandler(this.PingCompletedCallBack);//设置PingCompleted事件处理程序
			p1.SendAsync("192.168.253.200", null);
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
			HttpItem item = new HttpItem()
			{
				URL =this.tboxAddress.Text.Trim(),//URL这里都是测试     必需项
				Method = "get",//URL     可选项 默认为Get
			};
			HttpResult result = http.GetHtml(item);
			richTextBox1.Text=result.ToString();
			
		}

		void Label1Click(object sender, EventArgs e)
		{
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			
			
			item = new HttpItem()
			{
				URL = "http://192.168.253.200/goform/formPassword",//URL这里都是测试URl   必需项
				Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
				//Encoding = Encoding.Default,
				Method = "post",//URL     可选项 默认为Get
				ContentType = "application/x-www-form-urlencoded",
				Postdata = "password=00509c4eee4657da3350647879179e3e",
				Allowautoredirect=true
			};
			//得到新的HTML代码
			HttpResult result = http.GetHtml(item);
			richTextBox1.Clear();
			item = new HttpItem()
			{
				URL = "http://192.168.253.200/index.asp",
			};
			result = http.GetHtml(item);//目前这个里面是未登入的状态
			//表示访问成功，具体的大家就参考HttpStatusCode类
			richTextBox1.Text=result.Html;
			webbrow webBrow=new webbrow(item.URL);
			//webBrow.Show();
			//调用IE浏览器
			//System.Diagnostics.Process.Start("iexplore.exe", item.URL);
			System.Diagnostics.Process process = System.Diagnostics.Process.Start("iexplore.exe",item.URL );
			//调用系统默认的浏览器
			//System.Diagnostics.Process.Start( item.URL);

		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.listBox2.Text="开始链接。。。。。";
			showping();
		}
		void Button3Click(object sender, EventArgs e)
		{
			Uri uri = new Uri("http://192.168.253.200/login.asp?password=1234.abcd");
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			var cache = new CredentialCache();
			cache.Add(uri, "Basic", new NetworkCredential("admin", "admin"));
			request.Credentials = cache;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader read = new StreamReader(response.GetResponseStream(), Encoding.Default);
			string text = read.ReadToEnd();
			richTextBox1.Text=text;
		}
		void StatusStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}
		void Button4Click(object sender, EventArgs e)
		{
//			SetNetworkAdapter();
//			MessageBox.Show("dd");
			loadinterface();
//			GetIP6();
		}
		private void GetIP6()
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
//				}
				
			}
//			foreach (NetworkInterface adapter in nics)
//			{
//				//判断是否为以太网卡
//				//Wireless80211         无线网卡    Ppp     宽带连接
//				//Ethernet              以太网卡
//				//这里篇幅有限贴几个常用的，其他的返回值大家就自己百度吧！
//				if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
//				{
//					//获取以太网卡网络接口信息
//					IPInterfaceProperties ip = adapter.GetIPProperties();
//					//获取单播地址集
//					UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
//					foreach (UnicastIPAddressInformation ipadd in ipCollection)
//					{
//						//InterNetwork    IPV4地址      InterNetworkV6        IPV6地址
//						//Max            MAX 位址
//						if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
//							//判断是否为ipv4
//							label1.Text = ipadd.Address.ToString();//获取ip
//					}
//				}
		}
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
			
		}
		void ToolStripDropDownButton1Click(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
			this.listBox3.Items.Clear();
			this.listBox4.Items.Clear();
			this.listBox5.Items.Clear();
		}
	}
}
