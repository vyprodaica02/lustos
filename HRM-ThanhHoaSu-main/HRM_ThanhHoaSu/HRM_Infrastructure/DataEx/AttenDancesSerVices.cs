using HRM_Design.Common;
using HRM_Design.Entities.ProjectEntity;
using HRM_Design.Entities.TimeKeeping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Infrastructure.DataEx
{
    public class AttenDancesSerVices<T> : IRepository<T> where T : Attendance
    {
        private readonly AppDbContext dbContext;
        private DbSet<T> _entities;

        public AttenDancesSerVices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public IQueryable<T> TableUntracked
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        public ICollection<T> Local
        {
            get
            {
                return Entities.Local;
            }
        }

        public bool? AutoCommitEnabled { get ; set; }

        public void Add(T entity)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Kiểm tra sự tồn tại của đối tượng trong cơ sở dữ liệu dựa trên điều kiện liên quan đến Email và Code
                    if (Entities.Any(x => x.Id == entity.Id))
                    {
                        // Nếu đối tượng đã tồn tại, ném ngoại lệ để thông báo
                        throw new InvalidOperationException("Tài khoản đã tồn tại");
                    }
                    // Nếu đối tượng không tồn tại, thêm vào cơ sở dữ liệu
                    Entities.Add(entity);
                    // Nếu được yêu cầu, lưu các thay đổi vào cơ sở dữ liệu
                    if (AutoCommitEnabledInternal)
                    {
                        CommitAsync();
                    }
                    // Hủy đính kèm đối tượng để không theo dõi thay đổi
                    Entities.Attach(entity).State = EntityState.Detached;
                    // Hoàn thành
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, hủy giao dịch và ném ngoại lệ để thông báo
                    trans.Rollback();
                    throw;
                }
            }
        }
        //thêm user
        public async Task AddAsync(T entity)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Kiểm tra sự tồn tại của đối tượng trong cơ sở dữ liệu dựa trên điều kiện liên quan đến Email và Code
                    if (Entities.Any(x => x.Id == entity.Id))
                    {
                        // Nếu đối tượng đã tồn tại, ném ngoại lệ để thông báo
                        throw new InvalidOperationException("Tài khoản đã tồn tại");
                    }
                    // Nếu đối tượng không tồn tại, thêm vào cơ sở dữ liệu
                    await Entities.AddAsync(entity);
                    // Nếu được yêu cầu, lưu các thay đổi vào cơ sở dữ liệu
                    if (AutoCommitEnabledInternal)
                    {
                        await CommitAsync();
                    }
                    // Hủy đính kèm đối tượng để không theo dõi thay đổi
                    Entities.Attach(entity).State = EntityState.Detached;
                    // Hoàn thành
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, hủy giao dịch và ném ngoại lệ để thông báo
                    trans.Rollback();
                    throw;
                }
            }
        }


        public void AddRange(IEnumerable<T> entities, int batchSize = 100)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 100)
        {
            using var trans = dbContext.Database.BeginTransaction();
            {
                try
                {
                    if (entities.Any())
                    {
                        if (batchSize <= 1)
                        {
                            // Add all in one step
                            entities.ToList().ForEach(async x => await AddAsync(x));
                        }
                        else
                        {
                            // Add each one in
                            int i = 0; bool saved = false;
                            foreach (var entity in _entities)
                            {
                                if (!_entities.Any())
                                {
                                    await this.Entities.AddAsync(entity);
                                    saved = false;
                                    if (i % batchSize == 0)
                                    {
                                        if (AutoCommitEnabledInternal)
                                        {
                                            Commit();
                                        }
                                        i = 0;
                                        saved = true;
                                    }
                                    i++;
                                }
                            }
                            if (!saved)
                            {
                                if (AutoCommitEnabledInternal) Commit();
                            }
                        }
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public T Attach(T entity) //gán
        {
            return Entities.Attach(entity).Entity;

        }

        public void Commit()
        {
            dbContext.SaveChanges();

        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var userHt = dbContext.qa_attendances.FirstOrDefault(x => x.Id == id);

            if (AutoCommitEnabledInternal)
            {
                dbContext.Remove(userHt);
                await CommitAsync();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;

            if (AutoCommitEnabledInternal)
            {
                await CommitAsync();
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
            }

            if (AutoCommitEnabledInternal)
            {

                await CommitAsync();
            }
        }

        public T GetById(int id)
        {
            return Entities.Find(id);

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);

        }

        public IQueryable<T> GetByIds(ICollection<int> ids)
        {
            return Entities.Where(x => ids.Contains(x.Id));

        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    ChangeStateToModifiedIfApplicable(entity);

                    if (AutoCommitEnabledInternal)
                    {
                        await CommitAsync();

                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw;
                }
            }

        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        private bool AutoCommitEnabledInternal
        {
            get
            {
                return AutoCommitEnabled ?? true;
            }
        }
        private void ChangeStateToModifiedIfApplicable(T entity)
        {

            var entry = dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                // Entity was detached before or was explicitly constructed.
                // This unfortunately sets all properties to modified.
                entry.State = EntityState.Modified;
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        ChangeStateToModifiedIfApplicable(entity);
                    }

                    if (AutoCommitEnabledInternal)
                    {
                        await CommitAsync();
                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw new Exception("Lỗi rồi");
                }
            }

        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = dbContext.Set<T>();
                }

                return _entities as DbSet<T>;
            }
        }
    }
}
