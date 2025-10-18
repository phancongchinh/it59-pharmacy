// using System;
// using System.Collections.Generic;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
//
// namespace IT59_Pharmacy.Data.Repositories {
//     public interface IRepository<T> where T : class {
//         // Create
//         Task<T> AddAsync(T entity);
//         T Add(T entity);
//         Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
//         IEnumerable<T> AddRange(IEnumerable<T> entities);
//
//         // Read
//         Task<T> GetByIdAsync(int id);
//         T GetById(int id);
//         Task<T> GetAsync(Expression<Func<T, bool>> predicate);
//         T Get(Expression<Func<T, bool>> predicate);
//         Task<IEnumerable<T>> GetAllAsync();
//         IEnumerable<T> GetAll();
//         Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
//         IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
//         Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
//         IEnumerable<T> GetPaged(int pageNumber, int pageSize);
//         Task<int> CountAsync();
//         int Count();
//         Task<int> CountAsync(Expression<Func<T, bool>> predicate);
//         int Count(Expression<Func<T, bool>> predicate);
//         Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
//         bool Exists(Expression<Func<T, bool>> predicate);
//
//         // Update
//         T Update(T entity);
//         void UpdateRange(IEnumerable<T> entities);
//
//         // Delete
//         void Remove(T entity);
//         void RemoveRange(IEnumerable<T> entities);
//         Task<bool> RemoveByIdAsync(int id);
//         bool RemoveById(int id);
//     }
// }