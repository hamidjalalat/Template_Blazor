using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
	public class ApplicationRepository : Repository<Application>, IApplicationRepository
	{
		internal ApplicationRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
			
		}
		public List<Models.Application> ExecSpApplication()
		{
			 string name = "taha";

             var result= DatabaseContext.Applications.FromSqlInterpolated($"sptest {name}").ToList();

            return result;
		}
	}
}
