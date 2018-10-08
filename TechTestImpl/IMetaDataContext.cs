using System.Collections.Generic;

namespace TechTestImpl
{
    public interface IMetaDataContext<T>
    {
        IList<T> ProductionReadyCodes { get; set; }
    }
}