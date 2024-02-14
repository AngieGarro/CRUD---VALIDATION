using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
	public class LoginMapper
	{
		public SqlOperation getRetrieveByEmailStatement(string correo)
		{

			var SqlOperation = new SqlOperation();
			SqlOperation.ProcedureName = "RET_OBTENER_USER_PR";

			SqlOperation.AddVarcharParam("Email", correo);
			return SqlOperation;

		}

		//HACE LOGIN
		public SqlOperation GetInicioSesionStatement(string correo, string clave)
		{
			var SqlOperation = new SqlOperation();
			SqlOperation.ProcedureName = "RET_LOGIN_PR";

			SqlOperation.AddVarcharParam("Email", correo);
			SqlOperation.AddVarcharParam("Password", clave);

			return SqlOperation;
		}
		#region "Construccion de objetos"

		public BaseDTO BuildObject(Dictionary<string, object> row)

		{
			//Basado en la composicion de la fila en la base de datos construimos el objeto en POO
			var UserDTO = new User
			{
				Id = (int)row["Id"],
				Name = (string)row["Name"],
				LastName1 = (string)row["LastName1"],
				LastName2 = (string)row["LastName2"],
				Email = (string)row["Email"],
				Password = (string)row["Password"],
				UserCode = (string)row["UserCode"],
				QuestionSecret = (int)row["QuestionSecret"],
				QuestionAnswer = (string)row["QuestionAnswer"],

			};
			return UserDTO;

		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();
			foreach (var item in lstRows)
			{
				var personaDTO = BuildObject(item);
				lstResults.Add(personaDTO);
			}

			return lstResults;

		}
		#endregion
	}
}

