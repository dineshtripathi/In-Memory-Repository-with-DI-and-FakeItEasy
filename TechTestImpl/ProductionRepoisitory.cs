using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Interview;

namespace TechTestImpl
{
    public class ProductionRepository<T> : IRepository<T> where T:IStoreable
    {
        private readonly IMetaDataContext<T> _metaDataContext;

        public ProductionRepository(IMetaDataContext<T> metaDataContext)
        {
            _metaDataContext = metaDataContext;
          
        }
        public IEnumerable<T> All()
        {
            return (IEnumerable<T>) _metaDataContext.ProductionReadyCodes;
        }

        public void Delete(IComparable id)
        {
            _metaDataContext.ProductionReadyCodes.Remove(_metaDataContext.ProductionReadyCodes.FirstOrDefault(x=>Equals(x.Id, id)));
        }

        public void Save(T item)
        {
           _metaDataContext.ProductionReadyCodes.Add(item);
            
        }

        public T FindById(IComparable id)
        {
            return _metaDataContext.ProductionReadyCodes.First(CheckToCompare(id));
        }
        private static Func<T, bool> CheckToCompare(IComparable id)
        {
            return i => i.Id.Equals(id);
        }
    }
}
