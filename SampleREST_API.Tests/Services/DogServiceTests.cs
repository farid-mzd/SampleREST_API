using Moq;
using SampleREST_API.Models.Custom;
using SampleREST_API.Models.Pagination.PaginationParameters;
using SampleREST_API.Models.Sorting;
using SampleREST_API.Repositories.Abstract;
using SampleREST_API.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleREST_API.Tests.Services
{
    public class DogServiceTests
    {
        private readonly IEnumerable<Dog> _dogList = new List<Dog> {
            new Dog { Name = "Jessie", Color = "red & white", Tail_Length = 44, Weight = 10 },
            new Dog { Name = "Kyle", Color = "red & black", Tail_Length = 40, Weight = 5 }
            };


private readonly DogService _sut;

        public readonly Mock<IUnitOfWork> _uwMock = new Mock<IUnitOfWork>();

        public readonly Mock<ISortHelper<Dog>> _sortHelperMock = new Mock<ISortHelper<Dog>>();

        public DogServiceTests()
        {
            _sut = new DogService(_uwMock.Object, _sortHelperMock.Object);

            //_dogList = new List<Dog> {
            //new Dog { Name = "Jessie", Color = "red & white", Tail_Length = 44, Weight = 10 },
            //new Dog { Name = "Kyle", Color = "red & black", Tail_Length = 40, Weight = 5 }
            //};
        }

        [Fact]
        public async Task GetDogs_SholudReturnDogs_WhenDogsExists()
        {
            //Arrange

            var parameters = new DogParameters();

            _uwMock.Setup(x => x.DogRepository.Get()).Returns(Task.FromResult<IEnumerable<Dog>>(_dogList));

            //_sortHelperMock.Setup(x => x.ApplySort(_dogList.AsQueryable<Dog>(), parameters.Attribute, parameters.Order)).
            //    Returns(_dogList.AsQueryable<Dog>());

            _sortHelperMock.Setup(x => x.ApplySort(It.IsAny<IQueryable<Dog>>(),null,null)).
          Returns(_dogList.AsQueryable<Dog>());

            //_sortHelperMock.VerifyAll();

            //Act
            var result = _sut.GetDogs(parameters).Result.ToList();

            //Assert

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            //Assert.Collection(result,
            //                item => { Assert.Equal("Jessie", item.Name); Assert.Equal("red & white", item.Color);
            //                    Assert.Equal(44, item.Tail_Length); Assert.Equal(10, item.Weight);
            //                },
            //                item => {
            //                    Assert.Equal("Kyle", item.Name); Assert.Equal("red & black", item.Color);
            //                    Assert.Equal(40, item.Tail_Length); Assert.Equal(5, item.Weight);
            //                }
            //            );
            Assert.Equal(result, _dogList);
             

        }
    }
}
