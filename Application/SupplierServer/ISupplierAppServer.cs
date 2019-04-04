using Application.SupplierServer.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Application;
using ZDomain.Model;


namespace Application.SupplierServer
{
    public interface ISupplierAppServer
    {
        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        ServerResult<List<SupplierOutputDto>> GetSupplier(SupplierPageDto entity);
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServerResult<SupplierOutputDto> EditSupplier(SupplierInputDto entity);
        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ServerResult<int> DeleteSupplier(int Id);
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServerResult<SupplierOutputDto> AddSupplier(SupplierInputDto entity);
    }
}
