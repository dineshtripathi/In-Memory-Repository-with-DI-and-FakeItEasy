using System.Collections.Generic;

namespace TechTestImpl
{
    public class MetaDataContext<T> : IMetaDataContext<T> where T:class 
    {
        public IList<T> ProductionReadyCodes { get; set; }
    }
}