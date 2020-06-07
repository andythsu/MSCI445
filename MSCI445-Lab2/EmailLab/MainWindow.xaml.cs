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
		readonly TextBox SUBJECT_TEXTBOX;
		readonly TextBox MESSAGE_TEXTBOX;
		MyEmail myEmail;

		public MainWindow()
		{
			InitializeComponent();
			TO_TEXTBOX = (TextBox) this.FindName("to_textbox");
			FROM_TEXTBOX = (TextBox) this.FindName("from_textbox");
			SUBJECT_TEXTBOX = (TextBox) this.FindName("subject_textbox");
			MESSAGE_TEXTBOX = (TextBox) this.FindName("message_textbox");
		}

		private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
			validateInput();
			myEmail = new MyEmail(SUBJECT_TEXTBOX.Text, 
				MESSAGE_TEXTBOX.Text, FROM_TEXTBOX.Text, "", TO_TEXTBOX.Text);
			var passwordWindow = new PasswordWindow(myEmail);
			passwordWindow.Show();
		}

        private void validateInput()
        {
			/**	Users tend to make mistakes in inputting data, 
			 * please make the appropriate error checks to ensure that the user 
			 * has inputted a valid email address and the sender's address is in fact a gmail address. 
			 * No one likes receiving messages with only a Subject or only a Body, 
			 * therefore please prompt the user to fill out both of these sections should they be empty.
			*/
        }
    }
}
