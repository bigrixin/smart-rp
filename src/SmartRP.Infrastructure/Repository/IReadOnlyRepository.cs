using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAbilityFirst.Infrastructure
{
	public interface IReadOnlyRepository
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

		IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class;
	}
}