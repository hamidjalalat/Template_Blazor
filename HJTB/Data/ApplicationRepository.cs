using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
	public class ApplicationRepository : Repository<Application>, IApplicationRepository
	{
		internal ApplicationRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}
