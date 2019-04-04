using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.SupplierServer;
using Application.SupplierServer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZDomain.Application;

namespace ZCore.Controllers
{
    [Route("api/Supplier/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppServer _appServer;


        public SupplierController(ISupplierAppServer supplierAppServer)
        {
            _appServer = supplierAppServer;
        }

        /// <summary>
        /// 获取供应工商列表
        /// </summary>
        /// <param name="supplierPageDto"></param>
        
        [HttpPost]
        public ServerResult<List<SupplierOutputDto>> GetSupplier([FromBody] SupplierPageDto supplierPageDto)
        {
            return _appServer.GetSupplier(supplierPageDto);
        }

        /// <summary>
        /// 编辑供应商列表
        /// </summary>
        /// <param name="supplierInputDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ServerResult<SupplierOutputDto> EditSupplier([FromBody] SupplierInputDto supplierInputDto)
        {
            return _appServer.EditSupplier(supplierInputDto);
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="supplierInputDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ServerResult<SupplierOutputDto> AddSupplier([FromBody]SupplierInputDto supplierInputDto)
        {
            return _appServer.AddSupplier(supplierInputDto);
        }


        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ServerResult<int> DeleteSupplier(int Id)
        {
            return _appServer.DeleteSupplier(Id);
        }
    }
}