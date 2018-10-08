using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Interview;

namespace TechTestImpl
{
    public class ProductionRepository : IRepository<ProductionReadyCode> 
    {
        private readonly IMetaDataContext _metaDataContext;

        public ProductionRepository(IMetaDataContext metaDataContext)
        {
            _metaDataContext = metaDataContext;
          
        }
        public IEnumerable<ProductionReadyCode> All()
        {
            return _metaDataContext.ProductionReadyCodes;
        }

        public void Delete(IComparable id)
        {
            _metaDataContext.ProductionReadyCodes.Remove(_metaDataContext.ProductionReadyCodes.FirstOrDefault(x=>Equals(x.Id, id)));
        }

        public void Save(ProductionReadyCode item)
        {
            _metaDataContext.ProductionReadyCodes.Add(item);
            
        }

        public ProductionReadyCode FindById(IComparable id)
        {
            return All().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
