using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZDomain.Entity;
using ZDomain.IRepository;

namespace EntityFramework.Core.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IDisposable where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly ZCoreContext _context;

        public Repository(ZCoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="entity">输入的实体对象</param>
        /// <returns>返回创建的实体对象</returns>
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        /// <summary>
        /// 修改实体对象
        /// </summary>
        /// <param name="entity">输入的实体</param>
        /// <returns></returns>
        public TEntity Edit(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        /// <summary>
        /// 根据条件返回第一个实体，没有则返回null
        /// </summary>
        /// <param name="predicate">查询条件Lambda表达式</param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 根据条件查询所有
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// 根据条件查询并分页
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="predicate">查询条件Lambda表达式</param>
        /// <param name="orderBy">排序Lambda表达式</param>
        /// <param name="isOrderDesc">是否倒叙</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<TEntity> GetList<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy, int pageIndex, int pageSize, bool isOrderDesc = false)
        {
            IQueryable<TEntity> query = isOrderDesc ? _context.Set<TEntity>().OrderByDescending(orderBy) : _context.Set<TEntity>().OrderBy(orderBy);

            return query.Where(predicate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }

        /// <summary>
        /// 异步根据条件查询并分页
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="predicate">查询条件Lambda表达式</param>
        /// <param name="orderBy">排序Lambda表达式</param>
        /// <param name="isOrderDesc">是否倒叙</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetListAsync<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy, int pageIndex, int pageSize, bool isOrderDesc = false)
        {
            IQueryable<TEntity> query = isOrderDesc ? _context.Set<TEntity>().OrderByDescending(orderBy) : _context.Set<TEntity>().OrderBy(orderBy);

            return await query.Where(predicate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
        }

        /// <summary>
        /// 异步根据条件查询对象
        /// </summary>
        /// <param name="predicate">查询条件Lambda表达式</param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns></returns>
        public TEntity Get(TPrimaryKey Id)
        {
            var LambadaParam = Expression.Parameter(typeof(TEntity));
            var LambadaBody = Expression.Equal(Expression.PropertyOrField(LambadaParam, "Id"), Expression.Constant(Id, typeof(TPrimaryKey)));
            var predicate = Expression.Lambda<Func<TEntity, bool>>(LambadaBody, LambadaParam);
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 异步根据主键获取实体对象
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(TPrimaryKey Id)
        {
            var LambadaParam = Expression.Parameter(typeof(TEntity));
            var LambadaBody = Expression.Equal(Expression.PropertyOrField(LambadaParam, "Id"), Expression.Constant(Id, typeof(TPrimaryKey)));
            var predicate = Expression.Lambda<Func<TEntity, bool>>(LambadaBody, LambadaParam);
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 根据主键删除实体对象
        /// </summary>
        /// <param name="Id">主键Id</param>
        public void Delete(TPrimaryKey Id)
        {
            _context.Set<TEntity>().Remove(Get(Id));
        }

        /// <summary>
        /// 异步根据主键删除实体对象
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns></returns>
        public async Task DeleteAsync(TPrimaryKey Id)
        {
            await Task.Run(() => Delete(Id));
        }

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Delete(entity));
        }


        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await Task.Run(() => Add(entity));
        }

        /// <summary>
        /// 异步编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> EditAsync(TEntity entity)
        {
            return await Task.Run(() => Edit(entity));
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }


        public int Count()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).Count();
        }

        /// <summary>
        /// 异步查询总条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).CountAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
