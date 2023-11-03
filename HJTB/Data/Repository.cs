using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Base;

namespace Data
{
	public class Repository<T> : Base.Repository<T> where T : Entity
	{
		internal Repository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public override void Insert(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.InsertDateTime = Utility.Now;

			DbSet.Add(entity);
		}

	}
}
