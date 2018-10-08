using System.Collections.Generic;
using Dto;

namespace TechTestImpl
{
    public interface IMetaDataContext<T>
    {
        IList<T> ProductionReadyCodes { get; set; }
    }
}