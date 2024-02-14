using DataAccess.DAO;
using DataAccess.MAPPER;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
	public class UserCrudFactory : CrudFactory
	{
		UserMapper mapper;
		public UserCrudFactory() : base()
		{
			mapper = new UserMapper();
			dao = SqlDAO.GetInstance();
		}

		//REGISTRO USUARIO:
		public override void Create(BaseDTO dto)
		{
			var usr = (User)dto;

			var sqlOperation = mapper.GetCreateStatements(usr);

			dao.ExecuteProcedure(sqlOperation);
		}
		//RESTABLECER CLAVE:
		public void UpdatePassword(string pwrd, string QuestionAnswer)
		{
			var SqlOperations = mapper.GetUpdateStatements(pwrd, QuestionAnswer);
			dao.ExecuteProcedure(SqlOperations);
		}
		public override void Delete(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override T Retrieve<T>()
		{
			throw new NotImplementedException();
		}

		public override List<T> RetrieveAll<T>()
		{
			throw new NotImplementedException();
		}

		public override T RetrieveById<T>(int Id)
		{
			throw new NotImplementedException();
		}

		public override void Update(BaseDTO dto)
		{
			throw new NotImplementedException();
		}
	}
}
