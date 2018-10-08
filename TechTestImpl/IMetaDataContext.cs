using System.Collections.Generic;
using Dto;

namespace TechTestImpl
{
    public interface IMetaDataContext
    {
        IList<ProductionReadyCode> ProductionReadyCodes { get; set; }
    }
}