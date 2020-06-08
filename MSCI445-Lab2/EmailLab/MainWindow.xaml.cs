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
using System.Net.Mail;

namespace EmailLab
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// declare variables
		readonly TextBox TO_TEXTBOX;
		readonly TextBox FROM_TEXTBOX;
		readonly TextBox SUBJECT_TEXTBOX;
		readonly TextBox MESSAGE_TEXTBOX;
		MyEmail myEmail;

		public MainWindow()
		{
			InitializeComponent();
			// initialize variables
			TO_TEXTBOX = (TextBox) this.FindName("to_textbox");
			FROM_TEXTBOX = (TextBox) this.FindName("from_textbox");
			SUBJECT_TEXTBOX = (TextBox) this.FindName("subject_textbox");
			MESSAGE_TEXTBOX = (TextBox) this.FindName("message_textbox");
		}

		private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
			string subject = SUBJECT_TEXTBOX.Text;
			string message = MESSAGE_TEXTBOX.Text;
			string from = FROM_TEXTBOX.Text;
			string to = TO_TEXTBOX.Text;
			// if input is valid, prompt the user to enter password
			if (validateInput(subject, message, from , to)) {
				myEmail = new MyEmail(subject, message, from, "", to);
				var passwordWindow = new PasswordWindow(myEmail);
				passwordWindow.Show();
			};
		}

		private bool validateInput(string subject, string message, string from, string to)
        {
			// default value is true
			bool stats = true;
			// default value of errors
			string errors = "One or more errors occured: \n";
			try
			{
				// if sender is empty, show the error
				if (from != "") { MailAddress s = new MailAddress(from); } else { errors += "Sender's email address can not be empty. \n"; }
				// if recipient is empty, show the error
				if (to != "") { MailAddress r = new MailAddress(to); } else { errors += "Receiver's email address can not be empty. \n"; }
			}
			catch (FormatException)
			{
				// append error
				errors += "Sender's or user's email address is invalid.\n";
				// return false
				stats = false;
			}

			// if sender is not using gmail, return error
            if (!from.EndsWith("@gmail.com", true, null) && from != "")
            {
				errors += "Sender is not using Gmail. \n";
				stats = false;
            }

			// if subject or message is empty, return error
			if (subject == "" || message == ""){
				errors += "Subject or message can not be empty. \n";
				stats = false;
            }
			// if at the end, stats is false, that means we have one or more errors. Display the error box
            if (stats == false)
            {
				var errorwindow = new ErrorWindow(errors);
				errorwindow.Show();
			}

			return stats;
		}
    }
}
