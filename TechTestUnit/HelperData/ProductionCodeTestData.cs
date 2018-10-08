using System.Collections.Generic;
using System.Linq;
using Dto;

namespace TechTestUnit.HelperData
{
    public class ProductionCodeTestData
    {
        private static readonly IList<ProductionReadyCode> ProductionCodes = new List<ProductionReadyCode>
        {
            new ProductionReadyCode
            {
                BranchName = "Story_GetStateForProduction",
                ReleaseVersion = "V_1.0.1",
                Id = 1
            },
            new ProductionReadyCode
            {
                BranchName = "Story_GetActorsForProduction",
                ReleaseVersion = "V_1.0.2",
                Id = 2
            },
            new ProductionReadyCode
            {
                BranchName = "Story_GetEventsForProduction",
                ReleaseVersion = "V_1.0.3",
                Id = 3
            },
            new ProductionReadyCode
            {
                BranchName = "Story_GetEventCallerForProduction",
                ReleaseVersion = "V_1.0.4",
                Id = 4
            }
        };

        public static IEnumerable<object[]> GetAllProductionCodes()
        {
            yield return new object[]
            {
                ProductionCodes
            };
        }

        public static IEnumerable<object[]> GetProductionCodesAfterDeletingById_4()
        {
            yield return new object[]
            {
                ProductionCodes,
                ProductionCodes.Where(x=>x.Id != null && !Equals(x.Id, 4)).ToList(),
                4
            };
          
        }

        public static IEnumerable<object[]> SaveProductionCodesNewDataSet()
        {
            yield return new object[]
            {
                ProductionCodes,
                new ProductionReadyCode
                {
                    BranchName = "Story_GetEventCallerForProduction",
                    ReleaseVersion = "V_1.0.5",
                    Id = 5
                }
            };
        }

        public static IEnumerable<object[]> FindByIdInProductionCode()
        {
            yield return new object[]
            {
                ProductionCodes,
                new ProductionReadyCode
                {
                    BranchName = "Story_GetEventsForProduction",
                    ReleaseVersion = "V_1.0.3",
                    Id = 3
                },
                3
            };
        }
    }
}