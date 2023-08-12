using HRM_Design.Common;
using HRM_Infrastructure.DataEx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRM_Infrastructure.DataEx
{
    public partial class ExRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;

        public ExRepository(AppDbContext context)
        {
            _context = context;
        }

        #region interface members

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public virtual IQueryable<T> TableUntracked
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        public virtual ICollection<T> Local
        {
            get
            {
                return this.Entities.Local;
            }
        }

        public virtual T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public virtual T Attach(T entity)
        {
            return Entities.Attach(entity).Entity;
        }

        public virtual void Add(T entity)
        {
            this.Entities.Add(entity);

            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
            this.Entities.Attach(entity).State = EntityState.Detached;
        }

        public virtual void AddRange(IEnumerable<T> entities, int batchSize = 100)
        {
            if (entities.Any())
            {
                if (batchSize <= 0)
                {
                    // insert all in one step
                    this.Entities.AddRange(entities);
                    if (this.AutoCommitEnabledInternal)
                    {
                        _context.SaveChanges();
                    }
                }
                else
                {
                    int i = 1;
                    bool saved = false;
                    foreach (var entity in entities)
                    {
                        this.Entities.Add(entity);
                        saved = false;
                        if (i % batchSize == 0)
                        {
                            if (this.AutoCommitEnabledInternal)
                            {
                                _context.SaveChanges();
                            }
                            i = 0;
                            saved = true;
                        }
                        i++;
                    }

                    if (!saved)
                    {
                        if (this.AutoCommitEnabledInternal)
                        {
                            _context.SaveChanges();
                        }
                    }
                }

            }
        }

        public virtual void Update(T entity)
        {
            ChangeStateToModifiedIfApplicable(entity);

            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                ChangeStateToModifiedIfApplicable(entity);
            }

            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
        }

        private void ChangeStateToModifiedIfApplicable(T entity)
        {

            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                // Entity was detached before or was explicitly constructed.
                // This unfortunately sets all properties to modified.
                entry.State = EntityState.Modified;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var userHt = _context.qa_users.FirstOrDefault(x => x.Id == id);

            if (this.AutoCommitEnabledInternal)
            {
                _context.Remove(userHt);
                await CommitAsync();
            }
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await this.Entities.AddAsync(entity);

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
            this.Entities.Attach(entity).State = EntityState.Detached;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 100)
        {
            if (entities.Any())
            {
                if (batchSize <= 0)
                {
                    // insert all in one step
                    await this.Entities.AddRangeAsync(entities);
                    if (this.AutoCommitEnabledInternal)
                    {
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    int i = 1;
                    bool saved = false;
                    foreach (var entity in entities)
                    {
                        await this.Entities.AddRangeAsync(entity);
                        saved = false;
                        if (i % batchSize == 0)
                        {
                            if (this.AutoCommitEnabledInternal)
                            {
                                await _context.SaveChangesAsync();
                            }
                            i = 0;
                            saved = true;
                        }
                        i++;
                    }

                    if (!saved)
                    {
                        if (this.AutoCommitEnabledInternal)
                        {
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        public async Task UpdateAsync(T entity)
        {
            ChangeStateToModifiedIfApplicable(entity);

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                ChangeStateToModifiedIfApplicable(entity);
            }

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<T> GetByIds(ICollection<int> ids)
        {
            return Entities.Where(x => ids.Contains(x.Id));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool? AutoCommitEnabled { get; set; }

        private bool AutoCommitEnabledInternal
        {
            get
            {
                return this.AutoCommitEnabled ?? true;
            }
        }


        #endregion

        #region Helpers
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities as DbSet<T>;
            }
        }

        #endregion

    }
}
