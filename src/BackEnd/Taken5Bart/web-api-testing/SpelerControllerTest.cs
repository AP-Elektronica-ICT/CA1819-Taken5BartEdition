using System;
using Taken5Bart.Controllers;
using Xunit;
using Interface.T5B;
using Microsoft.AspNetCore.Mvc;
using Models.T5B;
using System.Collections.Generic;
using BusinessLayer.T5B;
using Repository.T5B;

namespace web_api_testing
{

    public class SpelerControllerTest
    {
        SpelerController _controller;
        ISpelerService _service;

        public SpelerControllerTest()
        {
            _service = new SpelerServiceFake();
            _controller = new SpelerController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Speler>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
