using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Model;
using Application.SupplierServer.Dto;
using Application.AutoMapper;
using AutoMapper;
using ZDomain.Application;
using ZDomain.Service;

namespace Application.SupplierServer
{
    public class SupplierAppServer : ISupplierAppServer
    {
        private readonly ISupplierServer _supplierServer;
        public SupplierAppServer(ISupplierServer supplierServer)
        {
            _supplierServer = supplierServer;
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServerResult<SupplierOutputDto> AddSupplier(SupplierInputDto entity)
        {
            var data = AutoMapperHelper.MapTo<Supplier>(entity);
            return new ServerResult<SupplierOutputDto>() { Data = AutoMapperHelper.MapTo<SupplierOutputDto>(_supplierServer.AddSupplier(data)) };
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ServerResult<int> DeleteSupplier(int Id)
        {
            return new ServerResult<int>() { Data = _supplierServer.DeleteSupplier(Id) };
        }

        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServerResult<SupplierOutputDto> EditSupplier(SupplierInputDto entity)
        {
            var data = AutoMapperHelper.MapTo<Supplier>(entity);

            return new ServerResult<SupplierOutputDto>() { Data = AutoMapperHelper.MapTo<SupplierOutputDto>(_supplierServer.EditSupplier(data)) };
        }

        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <param name="name">查询供应商名称</param>
        /// <param name="typeCode">查询供应商类型</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ServerResult<List<SupplierOutputDto>> GetSupplier(SupplierPageDto pageDto)
        {

            return new ServerResult<List<SupplierOutputDto>>()
            {
                Data = AutoMapperHelper.MapToList<Supplier, SupplierOutputDto>(_supplierServer.GetSupplier(pageDto.Name, pageDto.TypeCode, pageDto.PageIndex, pageDto.PageSize))
            };
        }
    }

}
