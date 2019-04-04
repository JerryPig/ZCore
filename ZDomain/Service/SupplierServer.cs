using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Infrastructure;
using ZDomain.IRepository;
using ZDomain.Model;

namespace ZDomain.Service
{
    public class SupplierServer : ISupplierServer
    {
        private IRepository<Supplier, int> _supplierRepository { get; set; }
        public SupplierServer(IRepository<Supplier, int> supplierRepository)
        {
            _supplierRepository = _supplierRepository;
        }
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Supplier AddSupplier(Supplier entity)
        {
            return _supplierRepository.AddAsync(entity).Result;
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteSupplier(int Id)
        {
            int count = 0;
            if (_supplierRepository.GetAsync(Id).Result != null)
            {
                _supplierRepository.DeleteAsync(Id);
                count = 1;
            }
            return count;
        }

        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Supplier EditSupplier(Supplier entity)
        {
            return _supplierRepository.EditAsync(entity).Result;
        }

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Supplier> GetSupplier(string name, string typeCode, int pageIndex, int pageSize)
        {

            var predicate = PredicateExtensions.Begin<Supplier>(true);
            if (string.IsNullOrEmpty(name))
            {
                predicate.And(s => s.SupplierName.Contains(name) || s.ShortName.Contains(name));
            }
            if (string.IsNullOrEmpty(typeCode))
            {
                predicate.And(s => s.SupplierType == typeCode);
            }

            if (pageSize > 0)
            {
                return _supplierRepository.GetListAsync(predicate, s => s.Id, pageIndex, pageSize).Result;
            }

            else
            {
                return _supplierRepository.GetListAsync(predicate).Result;
            }
        }
    }
}
