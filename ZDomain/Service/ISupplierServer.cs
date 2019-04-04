using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Model;

namespace ZDomain.Service
{
    public interface ISupplierServer
    {
        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<Supplier> GetSupplier(string name, string typeCode, int pageIndex, int pageSize);
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Supplier EditSupplier(Supplier entity);
        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteSupplier(int Id);
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Supplier AddSupplier(Supplier entity);
    }
}
