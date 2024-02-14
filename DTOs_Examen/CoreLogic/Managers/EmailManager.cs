using DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Managers
{
	public class EmailManager
	{
		public void SendEmail(User usr)
		{
			//string OTP = generateOtp();
			var subject = "Hello!" + " " + usr.Name + " ";
			var body = "Welcome to APG!";

			if (usr.Email != null)
				PushEmail(usr.Email, usr.Name, subject, body).Wait();
			else
				throw new Exception("Email cannot Null");
		}

		private async Task PushEmail(string _email, string subjectText, string body, string name)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("agarrom@ucenfotec.ac.cr", "APG");
			var subject = subjectText;
			var to = new EmailAddress(_email, name);
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}
	}
}
