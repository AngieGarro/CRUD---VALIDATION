using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
	public class UserMapper : IObjectMapper, ISqlStatements
	{
		public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var usr = new User()
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

			return usr;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();

			foreach (var row in lstRows)
			{
				var user = BuildObject(row);
				lstResults.Add(user);
			}

			return lstResults;
		}

		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		//REGISTRO USUARIO
		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "REGISTER_USER_PR"
			};

			var usr = (User)Dto;
			operation.AddVarcharParam("NAME", usr.Name);
			operation.AddVarcharParam("LAST_NAME1", usr.LastName1);
			operation.AddVarcharParam("LAST_NAME2", usr.LastName2);
			operation.AddVarcharParam("EMAIL", usr.Email);
			operation.AddVarcharParam("PASSWORD", usr.Password);
			operation.AddVarcharParam("USER_CODE", usr.UserCode);
			operation.AddIntParam("QUESTION_SECRET", usr.QuestionSecret);
			operation.AddVarcharParam("QUESTION_ANSWER", usr.QuestionAnswer);

			return operation;
		}

		//RESTABLECER CLAVE:
		public SqlOperation GetUpdateStatements(string pwrd, string QuestionAnswer)
		{
			var SqlOperations = new SqlOperation();
			SqlOperations.ProcedureName = "UPD_PASSWORD_PR";

			SqlOperations.AddVarcharParam("QUESTION_ANSWER", QuestionAnswer);
			SqlOperations.AddVarcharParam("PASSWORD", pwrd);

			return SqlOperations;
		}
		//-----------------------------------------------------------------------------------
		public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetRetriveAllStatement()
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}
	}
}
