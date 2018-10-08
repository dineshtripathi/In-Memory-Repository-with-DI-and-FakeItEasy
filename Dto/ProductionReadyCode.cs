using Interview;
using System;

namespace Dto
{
    public class ProductionReadyCode :IStoreable 
    {
        public string BranchName { get; set; }
        public string ReleaseVersion { get; set; }
        public IComparable Id { get; set; }
    }
}
