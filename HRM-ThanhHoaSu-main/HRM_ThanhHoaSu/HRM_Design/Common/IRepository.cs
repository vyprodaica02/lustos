using HRM_Design.Entities.ProjectEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Common
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableUntracked { get; }
        ICollection<T> Local { get; }
        T Attach(T entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetByIds(ICollection<int> ids);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities, int batchSize = 100);
        Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 100);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);
        Task DeleteAsync(int id);
        void DeleteRange(IEnumerable<T> entities);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        bool? AutoCommitEnabled { get; set; }
        void Commit();
        public IQueryable<T> GetAll();
        public Task CommitAsync();
    }
}
