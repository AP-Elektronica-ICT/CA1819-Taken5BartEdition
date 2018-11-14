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

    public class SpelerServiceTest
    {
        SpelerService _service;
        ISpelerRepository _fakeSpelerRepo;
        ITeamRepository _fakeTeamRepo;

        public SpelerServiceTest()
        {
            _fakeSpelerRepo = new SpelerRepoFake();
            _fakeTeamRepo = new TeamRepositoryFake();
            _service = new SpelerService(_fakeSpelerRepo,_fakeTeamRepo);
        }

        [Fact]
        public void Get_Spelers()
        {
            //Act
            var okResult = _service.GetSpelers();

            //Assert
            Assert.IsType<List<Speler>>(okResult);
        }

        [Fact]
        public void Get_Speler_ReturnsAllItems()
        {
            // Act
            ICollection<Speler> result = _service.GetSpelers();

            // Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void Get_Speler_ReturnItem()
        {
            //Arrange
            var existingId = 5;

            // Act
            Speler result = _service.GetSpeler(existingId);

            // Assert
            Assert.IsType<Speler>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Speler_NotReturnItem()
        {
            //Arrange
            var id = -1;

            // Act
            Speler result = _service.GetSpeler(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Team_ReturnItem()
        {
            //Arrange
            var id = 2;

            // Act
            Team result = _service.GetTeamFromSpeler(id);

            // Assert
            Assert.IsType<Team>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Team_NotReturnItem() 
        {
            //Arrange
            var id = -1;

            // Act
            Team result = _service.GetTeamFromSpeler(id);

            // Assert
            Assert.Null(result);
        }
    }
}
