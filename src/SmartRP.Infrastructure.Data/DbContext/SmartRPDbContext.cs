using SmartRP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SmartRP.Infrastructure.Data
{
    public sealed class SmartRPDbContext : DbContext, IWriteEntities
    {

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Report> Reports { get; set; }

        #endregion

        #region Ctor

        public SmartRPDbContext() : base("SmartRPDbContext")
        {
        }

        public SmartRPDbContext(IDatabaseInitializer<SmartRPDbContext> initializer) : base("SmartRPDbContext")
        {
            if (initializer == null)
                throw new ArgumentNullException("initializer");

            Database.SetInitializer(initializer);
        }

        #endregion

        #region DbContext methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Supervisor>().ToTable("Supervisor");
            modelBuilder.Entity<Coordinator>().ToTable("Coordinator");
            modelBuilder.Entity<Term>().ToTable("Term");
            modelBuilder.Entity<Interest>().ToTable("Interest");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Report>().ToTable("Report");
        }

        #endregion

        #region IWriteEntities methods

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            if (id == null)
                throw new ArgumentNullException("id");

            return this.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            if (id == null)
                throw new ArgumentNullException("id");

            return await this.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return this.GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return await this.GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public TEntity Single<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null)
            where TEntity : class
        {
            return this.GetQueryable(filter, null, includeProperties).SingleOrDefault();
        }

        public async Task<TEntity> SingleAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null)
            where TEntity : class
        {
            return await this.GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public TEntity First<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null)
            where TEntity : class
        {
            return this.GetQueryable(filter, null, includeProperties).FirstOrDefault();
        }

        public async Task<TEntity> FirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null)
            where TEntity : class
        {
            return await this.GetQueryable(filter, null, includeProperties).FirstOrDefaultAsync();
        }

        public int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return this.GetQueryable(filter).Count();
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return await this.GetQueryable(filter).CountAsync();
        }

        public bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return this.GetQueryable(filter).Any();
        }

        public async Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return await this.GetQueryable(filter).AnyAsync();
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            if (this.Entry(entity).State == EntityState.Detached)
                this.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (this.Entry(entity).State == EntityState.Detached)
                this.Set<TEntity>().Attach(entity);

            this.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (this.Entry(entity).State == EntityState.Detached)
                this.Set<TEntity>().Attach(entity);

            this.Set<TEntity>().Remove(entity);
        }

        public void Save()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        public Task SaveAsync()
        {
            try
            {
                return this.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return Task.CompletedTask;
        }

        #endregion

        #region Private methods

        private IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            IQueryable<TEntity> query = this.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties)
                    if (prop != null)
                        query.Include(prop);
            }

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query;
        }

        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                                                        .SelectMany(x => x.ValidationErrors)
                                                        .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);

            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        #endregion
    }
}