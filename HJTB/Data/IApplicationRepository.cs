using Data.Base;
using Models;
using System.Collections.Generic;

namespace Data
{
	public interface IApplicationRepository : IRepository<Application>
	{
	 List<Models.Application> ExecSpApplication();
	}
}
