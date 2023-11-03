using Models.Base;
using System;
using System.Threading.Tasks;

namespace Data.Base
{
	public interface IUnitOfWork : IDisposable
	{
		bool IsDisposed { get; }

		void Save();

		Task SaveAsync();

		Repository<T> GetRepository<T>() where T : Entity;
	}
}
