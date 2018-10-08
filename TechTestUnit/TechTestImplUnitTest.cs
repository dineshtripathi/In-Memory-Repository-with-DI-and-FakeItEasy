using System.Collections.Generic;
using Dto;
using FakeItEasy;
using FluentAssertions;
using Interview;
using TechTestImpl;
using TechTestUnit.HelperData;
using Xunit;

namespace TechTestUnit
{
    public class TechTestImplUnitTest :ProductionCodeTestData
    {
        [Theory]
        [MemberData(nameof(GetAllProductionCodes))]
        public void ProductionRepoisitoryTest(List<ProductionReadyCode> Codes)
        {
           

        }

        [Theory]
        [MemberData(nameof(GetAllProductionCodes))]
        public void Get_All_Production_ReadyCode_From_RepositoryTest(List<ProductionReadyCode> allCodes)
        {
            var fakeDbContext = A.Fake<IMetaDataContext<ProductionReadyCode>>(ops=>ops.Strict());
            var fakeRepository = A.Fake<IRepository<ProductionReadyCode>>();
            //Setup
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).Returns(allCodes);
            var prodRepository = new ProductionRepository<ProductionReadyCode>(fakeDbContext);
            //Act
            var results = prodRepository.All();
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).MustHaveHappened();

            //Assert
            results.Should().BeEquivalentTo(allCodes);
        }

        [Theory]
        [MemberData(nameof(GetProductionCodesAfterDeletingById_4))]
        public void Delete_Specified_ProductionReadyCode_ById_From_Test(List<ProductionReadyCode> allCodes,List<ProductionReadyCode> codesAfterDeletion,int idForDeletion)
        {
            var fakeDbContext = A.Fake<IMetaDataContext<ProductionReadyCode>>(ops => ops.Strict());
            //Setup

            var prodRepository =new ProductionRepository<ProductionReadyCode>(fakeDbContext);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).Returns(allCodes);
            
            //Act
            prodRepository.Delete(idForDeletion);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).MustHaveHappened();
            var results = fakeDbContext.ProductionReadyCodes;
            
            //Assert
            results.Should().BeEquivalentTo(codesAfterDeletion);
        }

        [Theory]
        [MemberData(nameof(SaveProductionCodesNewDataSet))]
        public void Save_ProductionReadyCode_To_Repository_Test(List<ProductionReadyCode> allCodes,ProductionReadyCode saveData)
        {
            var fakeDbContext = A.Fake<IMetaDataContext<ProductionReadyCode>>(ops => ops.Strict());
            //Setup

            var prodRepository = new ProductionRepository<ProductionReadyCode>(fakeDbContext);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).Returns(allCodes);

            //Act
            prodRepository.Save(saveData);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).MustHaveHappened();
            var results = fakeDbContext.ProductionReadyCodes;

            //Assert
            results.Should().Contain(x=>Equals(x.Id, saveData.Id));
            results.Should().HaveCount(allCodes.Count);
        }

        [Theory]
        [MemberData(nameof(FindByIdInProductionCode))]
        public void Find_ProductionReadyCode_From_Repository_ById_Test(List<ProductionReadyCode> allCodes,ProductionReadyCode searchedResult,int id)
        {
            var fakeDbContext = A.Fake<IMetaDataContext<ProductionReadyCode>>(ops => ops.Strict());
            //Setup

            var prodRepository = new ProductionRepository<ProductionReadyCode>(fakeDbContext);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).Returns(allCodes);

            //Act
            var results=prodRepository.FindById(id);
            A.CallTo(() => fakeDbContext.ProductionReadyCodes).MustHaveHappened();
         //   var results = fakeDbContext.ProductionReadyCodes;

            //Assert
            results.Should().BeEquivalentTo(searchedResult);
            results.Should().NotBeNull();
        }
    }
}