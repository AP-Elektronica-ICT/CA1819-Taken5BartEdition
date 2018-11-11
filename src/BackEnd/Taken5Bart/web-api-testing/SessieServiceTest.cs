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

    public class SessieServiceTest
    {
        SessieService _service;
        ISessionRepository _fakeSessieRepo;

        public SessieServiceTest()
        {
            _fakeSessieRepo = new SessieRepoFake();
            _service = new SessieService(_fakeSessieRepo);
        }

        [Fact]
        public void Get_Sessies()
        {
            //Act
            var result = _service.GetSessies();

            //Assert
            Assert.Equal(1, result.Count);
            Assert.IsType<List<Sessie>>(result);
        }

        [Fact]
        public void Get_Sessie_ReturnItem()
        {
            //Arrange
            var existingId = 1;

            // Act
            var result = _service.GetSessie(existingId);

            // Assert
            Assert.IsType<Sessie>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Sessie_NotReturnItem()
        {
            //Arrange
            var id = -1;

            // Act
            var result = _service.GetSessie(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Teams_Sessie() 
        {
            //Arrange
            var id = 1;

            // Act
            var result = _service.GetTeamsBySessie(id);

            // Assert
            Assert.Equal(2, result.Count);

        }

        [Fact]
        public void Get_Teams_WrongSessie()
        {
            //Arrange
            var id = -1;

            // Act
            var result = _service.GetTeamsBySessie(id);

            // Assert
            Assert.Null(result);

        }

        
    }
}