using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using SampleREST_API.Controllers;
using SampleREST_API.Models.Custom;
using SampleREST_API.Models.Pagination;
using SampleREST_API.Models.Pagination.PaginationParameters;
using SampleREST_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleREST_API.Tests
{
   public class DogControllerTests
    {
        private readonly IEnumerable<Dog> _dogList = new List<Dog> {
            new Dog { Name = "Jessie", Color = "red & white", Tail_Length = 44, Weight = 10 },
            new Dog { Name = "Kyle", Color = "red & black", Tail_Length = 40, Weight = 5 }
            };


        private readonly DogController _sut;

        public readonly Mock<IDogService> _dogServiceMock = new Mock<IDogService>();

        public readonly Mock<ControllerBase> _controllerBaseMock = new Mock<ControllerBase>();

        public DogControllerTests()
        {
         

            _sut = new DogController(_dogServiceMock.Object);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            //Arrange

            DogParameters dogParameters = new DogParameters();

            var dogsPagedList = PagedList<Dog>.ToPagedList(_dogList, dogParameters.PageNumber, dogParameters.PageSize);

            var metadata = new
            {
                dogsPagedList.PageSize,
                dogsPagedList.CurrentPage,
                dogsPagedList.TotalPages,
                dogsPagedList.TotalCount,
                dogsPagedList.HasNext,
                dogsPagedList.HasPrevious
            };

            _dogServiceMock.Setup(x => x.GetDogs(dogParameters)).Returns(Task.FromResult<PagedList<Dog>>(dogsPagedList));

            _sut.ControllerContext = new ControllerContext();

            _sut.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var okResult = await _sut.Get(dogParameters);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public async Task Get_WhenCalled_ReturnsNoContentResult()
        {
            //Arrange

            DogParameters dogParameters = new DogParameters();

            IEnumerable<Dog> emptyDogList = new List<Dog>();

            var dogsPagedList = PagedList<Dog>.ToPagedList(emptyDogList, dogParameters.PageNumber, dogParameters.PageSize);

       

            _dogServiceMock.Setup(x => x.GetDogs(dogParameters)).Returns(Task.FromResult<PagedList<Dog>>(dogsPagedList));

          

            // Act
            var noContentResult = await _sut.Get(dogParameters);
            // Assert
            Assert.IsType<NoContentResult>(noContentResult as NoContentResult);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
  
            DogParameters dogParameters = new DogParameters();

            var dogsPagedList = PagedList<Dog>.ToPagedList(_dogList, dogParameters.PageNumber, dogParameters.PageSize);

            var metadata = new
            {
                dogsPagedList.PageSize,
                dogsPagedList.CurrentPage,
                dogsPagedList.TotalPages,
                dogsPagedList.TotalCount,
                dogsPagedList.HasNext,
                dogsPagedList.HasPrevious
            };

            _dogServiceMock.Setup(x => x.GetDogs(dogParameters)).Returns(Task.FromResult<PagedList<Dog>>(dogsPagedList));

            _sut.ControllerContext = new ControllerContext();

            _sut.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var okResult = (await _sut.Get(dogParameters) as OkObjectResult);

            var items = Assert.IsType<PagedList<Dog>>(okResult.Value);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);

            Assert.Equal(_dogList.Count(), items.Count);
        }


        [Fact]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Dog()
            {
               Color="red",
               Tail_Length = 15,
               Weight = 10
            };
            _sut.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = await _sut.Add(nameMissingItem) as BadRequestObjectResult;
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async Task Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Dog testItem = new Dog()
            {
                Name = "Adry",
                Color = "red",
                Tail_Length = 15,
                Weight = 10
            };
            // Act
            var createdResponse = await _sut.Add(testItem) as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public async Task Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            Dog testItem = new Dog()
            {
                Name = "Adry",
                Color = "red",
                Tail_Length = 15,
                Weight = 10
            };
            // Act
            _dogServiceMock.Setup(x => x.AddDog(testItem)).Returns(Task.FromResult(testItem));

            var createdResponse = ( await _sut.Add(testItem) as OkObjectResult);
            var item = createdResponse.Value as Dog;
            // Assert
            Assert.IsType<Dog>(item);
            Assert.Equal("Adry", item.Name);
        }

        [Fact]
        public async Task Add_ObjectWithExistednamePassed_ReturnedConflictResponse()
        {
            // Arrange
            Exception exception = new Exception("Dog with the given name already exists!");

            Dog testItem = new Dog()
            {
                Name = "Adry",
                Color = "red",
                Tail_Length = 15,
                Weight = 10
            };

            // Act

            _dogServiceMock.Setup(x => x.AddDog(testItem)).ThrowsAsync(exception);

            var createdResponse = (await _sut.Add(testItem) as ConflictObjectResult);

            // Assert
            Assert.IsType<ConflictObjectResult>(createdResponse);

        }


    }
}
