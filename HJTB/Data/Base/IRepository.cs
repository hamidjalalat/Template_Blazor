using Models.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Base
{
	public interface IRepository<T> where T : Entity
	{
		void Insert(T entity);

		Task InsertAsync(T entity);

		void Update(T entity);

		Task UpdateAsync(T entity);

		void Delete(T entity);

		Task DeleteAsync(T entity);

		T GetById(Guid id);

		Task<T> GetByIdAsync(Guid id);

		bool DeleteById(Guid id);

		Task<bool> DeleteByIdAsync(Guid id);

		IList<T> GetAll();

		Task<IList<T>> GetAllAsync();
	}
}
