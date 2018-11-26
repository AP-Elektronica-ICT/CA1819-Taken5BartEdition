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

    public class TeamServiceTest
    {
        TeamService _service;
        ISpelerRepository _fakeSpelerRepo;
        ITeamRepository _fakeTeamRepo;
        ISessionRepository _fakeSessieRepo;

        public TeamServiceTest()
        {
            _fakeSpelerRepo = new SpelerRepoFake();
            _fakeTeamRepo = new TeamRepositoryFake();
            _fakeSessieRepo = new SessieRepoFake();
            _service = new TeamService(_fakeTeamRepo,_fakeSpelerRepo, _fakeSessieRepo);
        }

        [Fact]
        public void Get_Teams()
        {
            //Act
            var result = _service.GetTeams();

            //Assert
            Assert.IsType<List<Team>>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Team_ReturnsAllItems()
        {
            // Act
            var result = _service.GetTeams();

            // Assert
            Assert.Equal(6, result.Count); //3 van de Database en 3 gemaakt door de Creat_Sessie
        }

        [Fact]
        public void Get_Team_ReturnItem()
        {
            //Arrange
            var existingId = 1;

            // Act
            var result = _service.GetTeam(existingId);

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
            var result = _service.GetTeam(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_ScorePosition() 
        {
            //Arrange
            var id = 1;

            // Act
            int result = _service.GetScorePos(id);

            // Assert
            Assert.Equal(2, result);

        }

        [Fact]
        public void Get_ScorePosition_NotExistingTeam()
        {
            //Arrange
            var teamId = -1;

            // Act
            int result = _service.GetScorePos(teamId);

            // Assert
            Assert.Equal(-1, result);
        }
        [Fact]
        public void Get_ScorePosition_NotTeamInSession()
        {
            //Arrange
            var teamId = 5;

            // Act
            int result = _service.GetScorePos(teamId);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ExistingSpeler_Join_Team()
        {
            //Arrange
            var teamId = 1;
            var spelerId = 3;

            // Act
            bool result = _service.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NotExistingSpeler_Join_Team()
        {
            //Arrange
            var teamId = 5;
            var spelerId = 999;

            // Act
            bool result = _service.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ExistingSpeler_Join_NotExistingTeam()
        {
            //Arrange
            var teamId = 9999;
            var spelerId = 2;

            // Act
            bool result = _service.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.False(result);
        }
    }
}
