using System.Collections.Generic;
using Dto;

namespace TechTestImpl
{
    public class MetaDataContext : IMetaDataContext
    {
        public IList<ProductionReadyCode> ProductionReadyCodes { get; set; }
    }
}