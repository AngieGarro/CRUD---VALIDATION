using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Managers
{
	public class UserManager
	{
		public void Create(User user)
		{
			//Data BD
			var crud = new UserCrudFactory();
			crud.Create(user);

			//Para envio de sms de bienvenida.
			var responseEmail = new EmailManager();
			responseEmail.SendEmail(user);	
		}

		//RESTABLECER CLAVE
		public void PasswordReset(string pwrd, string QuestionAnswer)
		{
			var crudFactory = new UserCrudFactory();
			crudFactory.UpdatePassword(pwrd, QuestionAnswer);
		}
	}
}
