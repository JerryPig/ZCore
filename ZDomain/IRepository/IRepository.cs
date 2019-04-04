using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZDomain.Entity;

namespace ZDomain.IRepository
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity, TPrimaryKey> : IDisposable where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="entity">输入的实体对象</param>
        /// <returns>返回创建的实体对象</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// 异步添加实体对象
        /// </summary>
        /// <param name="entity">输入的实体对象</param>
        /// <returns>返回创建的实体对象</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// 根据主键返回实体对象
        /// </summary>
        /// <param name="Id">输入主键</param>
        /// <returns>返回实体对象</returns>
        TEntity Get(TPrimaryKey Id);

        /// <summary>
        /// 异步根据主键返回实体对象
        /// </summary>
        /// <param name="Id">输入主键</param>
        /// <returns>返回实体对象</returns>
        Task<TEntity> GetAsync(TPrimaryKey Id);

        /// <summary>
        /// 根据条件返回第一个实体，没有则返回null
        /// </summary>
        /// <param name="predict">查询条件Lambda表达式</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件返回列表
        /// </summary>
        /// <param name="predict">查询条件Lambda表达式</param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

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
        List<TEntity> GetList<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy, int pageIndex, int pageSize, bool isOrderDesc = false);

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
        Task<List<TEntity>> GetListAsync<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy, int pageIndex, int pageSize, bool isOrderDesc = false);

        /// <summary>
        /// 异步根据条件返回列表
        /// </summary>
        /// <param name="predict">查询条件Lambda表达式</param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">输入的实体</param>
        /// <returns></returns>
        TEntity Edit(TEntity entity);

        /// <summary>
        /// 异步更新实体对象
        /// </summary>
        /// <param name="entity">输入的实体</param>
        /// <returns></returns>
        Task<TEntity> EditAsync(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 根据主键删除实体对象
        /// </summary>
        /// <param name="Id"></param>
        void Delete(TPrimaryKey Id);

        /// <summary>
        /// 异步根据主键删除实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task DeleteAsync(TPrimaryKey Id);

        /// <summary>
        /// 异步删除实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 根据条件获取数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 异步根据条件获取数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
