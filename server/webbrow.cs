/*
 * 由SharpDevelop创建。
 * 用户： AXD-VST-3360
 * 日期: 2016/4/14
 * 时间: 14:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace server
{
	/// <summary>
	/// Description of webbrow.
	/// </summary>
	public partial class webbrow : Form
	{
		string url;
		public webbrow(string x)
		{
			url=x;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void WebbrowLoad(object sender, EventArgs e)
		{
			webBrowser1.Navigate(url);
			webBrowser1.ScriptErrorsSuppressed=true;
			this.Text=url;
		}
	}
}
