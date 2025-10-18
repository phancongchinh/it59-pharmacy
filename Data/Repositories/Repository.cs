using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Data.Repositories {
    
    public class Repository<T> where T : class {
        
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly CurrentUserService _currentUserService;

        public Repository(AppDbContext context, CurrentUserService currentUserService) {
            _context = context;
            _dbSet = context.Set<T>();
            _currentUserService = currentUserService;
        }

        // Create
        // public async Task<T> AddAsync(T entity) {
        //     SetAuditFieldsForAdd(entity);
        //     await _dbSet.Add(entity);
        //     return entity;
        // }

        public T Add(T entity) {
            SetAuditFieldsForAdd(entity);
            _dbSet.Add(entity);
            return entity;
        }

        // public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities) {
        //     foreach (var entity in entities) {
        //         SetAuditFieldsForAdd(entity);
        //     }
        //     await _dbSet.AddRangeAsync(entities);
        //     return entities;
        // }

        public IEnumerable<T> AddRange(IEnumerable<T> entities) {
            foreach (var entity in entities)
            {
                SetAuditFieldsForAdd(entity);
            }

            _dbSet.AddRange(entities);
            return entities;
        }

        // Read
        public async Task<T> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }

        public T GetById(int id) {
            return _dbSet.Find(id);
        }

        private void SetAuditFieldsForAdd(T entity) {
            if (!(entity is Auditable auditable)) return;

            var userId = _currentUserService.getCurrentUserId();

            var now = DateTime.UtcNow;
            auditable.CreatedById = userId ??
                                  throw new InvalidOperationException("Current session is not valid.");
            auditable.CreatedDate = now;
            auditable.UpdatedById = userId;
            auditable.UpdatedDate = now;
        }
    }
}