using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EmailLab
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly TextBox TO_TEXTBOX;
		readonly TextBox FROM_TEXTBOX;
		readonly TextBox PASSWORD_TEXTBOX;
		readonly TextBox SUBJECT_TEXTBOX;
		readonly TextBox MESSAGE_TEXTBOX;

		public MainWindow()
		{
			InitializeComponent();
			TO_TEXTBOX = (TextBox) this.FindName("to_textbox");
			FROM_TEXTBOX = (TextBox) this.FindName("from_textbox");
			PASSWORD_TEXTBOX = (TextBox) this.FindName("password_textbox");
			SUBJECT_TEXTBOX = (TextBox) this.FindName("subject_textbox");
			MESSAGE_TEXTBOX = (TextBox) this.FindName("message_textbox");
		}

		private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
			
        }
    }
}
