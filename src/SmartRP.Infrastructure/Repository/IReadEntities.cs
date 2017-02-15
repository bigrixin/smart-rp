using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Infrastructure
{
	public interface IReadEntities
	{
		TEntity GetById<TEntity>(object id) where TEntity : class;

		Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class;

		IEnumerable<TEntity> Get<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Expression<Func<TEntity, object>>[] includeProperties = null,
			int? skip = null,
			int? take = null) where TEntity : class;

		Task<IEnumerable<T>> GetAsync<T>(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Expression<Func<T, object>>[] includeProperties = null,
			int? skip = null,
			int? take = null) where T : class;

		TEntity Single<TEntity>(
				Expression<Func<TEntity, bool>> filter = null,
				Expression<Func<TEntity, object>>[] includeProperties = null)
				where TEntity : class;

		Task<TEntity> SingleAsync<TEntity>(
				Expression<Func<TEntity, bool>> filter = null,
				Expression<Func<TEntity, object>>[] includeProperties = null)
				where TEntity : class;

		TEntity First<TEntity>(
				Expression<Func<TEntity, bool>> filter = null,
				Expression<Func<TEntity, object>>[] includeProperties = null)
				where TEntity : class;

		Task<TEntity> FirstAsync<TEntity>(
				Expression<Func<TEntity, bool>> filter = null,
				Expression<Func<TEntity, object>>[] includeProperties = null)
				where TEntity : class;


		int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

		Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

		bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

		Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
	}
}