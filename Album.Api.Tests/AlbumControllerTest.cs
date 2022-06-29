using Album.Api.Controllers;
using Album.Api.Models;
using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Album.Api.Tests
{
    public class AlbumControllerTest
    {
        private readonly AlbumController _controller;
        private readonly IAlbumService<Albummodel> _service;
        public AlbumControllerTest()
        {
            _service = new AlbumServiceFake();
            _controller = new AlbumController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAlbums();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAlbums() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Albummodel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }


        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetAlbummodel(12);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = 2;

            // Act
            var okResult = _controller.GetAlbummodel(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = 1;

            // Act
            var okResult = _controller.GetAlbummodel(testGuid) as OkObjectResult;

            // Assert
            Assert.IsType<Albummodel>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Albummodel).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Albummodel()
            {
            };
            _controller.ModelState.AddModelError("Name", "Required");
            _controller.ModelState.AddModelError("Artist", "Required");
            _controller.ModelState.AddModelError("ImageUrl", "Required");

            // Act
            var badResponse = _controller.PostAlbummodel(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Albummodel testItem = new Albummodel()
            {
                Name = "Guinness Original 6 Pack",
                Artist = "Guinness",
                ImageUrl = "nothing.com"
            };

            // Act
            var createdResponse = _controller.PostAlbummodel(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Albummodel()
            {
                Name = "Guinness Original 6 Pack",
                Artist = "Guinness",
                ImageUrl = "google.com"
            };

            // Act
            var createdResponse = _controller.PostAlbummodel(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Albummodel;

            // Assert
            Assert.IsType<Albummodel>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Name);
        }

/*
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = 15;

            // Act
            var badResponse = _controller.DeleteAlbummodel(notExistingGuid);

            // Assert
            Assert.IsType<NoContentResult>(badResponse);
        }*/

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = 1;

            // Act
            var noContentResponse = _controller.DeleteAlbummodel(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = 3;

            // Act
            var okResponse = _controller.DeleteAlbummodel(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }

    }
}
