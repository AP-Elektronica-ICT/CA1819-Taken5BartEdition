using System;
using Taken5Bart.Controllers;
using Xunit;
using Interface.T5B;
using Microsoft.AspNetCore.Mvc;
using Models.T5B;
using System.Collections.Generic;
using BusinessLayer.T5B;
using Repository.T5B;
using Interface;

namespace web_api_testing
{

    public class TeamServiceTest
    {
        TeamService _service;
        ISpelerRepository _fakeSpelerRepo;
        ITeamRepository _fakeTeamRepo;
        ISessionRepository _fakeSessieRepo;
        IPuzzelRepository _fakePuzzelRepo;

        public TeamServiceTest()
        {
            _fakeSpelerRepo = new SpelerRepoFake();
            _fakeTeamRepo = new TeamRepositoryFake();
            _fakeSessieRepo = new SessieRepoFake();
            _fakePuzzelRepo = new PuzzelRepoFake();
            _service = new TeamService(_fakeTeamRepo,_fakeSpelerRepo, _fakeSessieRepo, _fakePuzzelRepo);
        }

        [Fact]
        public void Get_Teams()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Act
            var result = _service.GetTeams();

            //Assert
            Assert.IsType<List<Team>>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Team_ReturnsAllItems()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            // Act
            var result = _service.GetTeams();

            // Assert
            Assert.Equal(3, result.Count); //3 van de Database en 3 gemaakt door de Creat_Sessie
        }

        [Fact]
        public void Get_Team_ReturnItem()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
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
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 9999;
            var spelerId = 2;

            // Act
            bool result = _service.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetActive_Puzzel_existingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamIdActive = 2; //team 2 is bezig met een actieve puzzel
            var teamIdNotActive = 1; //team1 is niet bezig met een puzzel

            // Act
            var resultActive = _service.ActivePuzzel(teamIdActive);
            var resultNotActive = _service.ActivePuzzel(teamIdNotActive);

            // Assert
            Assert.IsType<Puzzel>(resultActive);
            Assert.Null(resultNotActive);
        }

        [Fact]
        public void GetActive_Puzzel_NotexistingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 99999;

            // Act
            var result = _service.ActivePuzzel(teamId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetActive_PuzzelID_NotexistingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 99999;

            // Act
            var result = _service.ActivePuzzelID(teamId);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void SetActive_Puzzel_ExistingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 1;

            // Act
            var result = _service.SetActivePuzzel(teamId,false);
            var resultId = _service.ActivePuzzelID(teamId);
            // Assert
            Assert.IsType<Puzzel>(result);
            Assert.NotEqual(-1, resultId);
        }
        [Fact]
        public void ResetActive_Puzzel_ExistingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 1;

            // Act
            var result = _service.SetActivePuzzel(teamId, true);
            var resultId = _service.ActivePuzzelID(teamId);
            // Assert
            Assert.Null(result);
            Assert.Equal(-1, resultId);
        }

        [Fact]
        public void SetActive_Puzzel_NotexistingTeam()
        {
            (_fakeSpelerRepo as SpelerRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakePuzzelRepo as PuzzelRepoFake).reset();
            //Arrange
            var teamId = 9999;

            // Act
            var result = _service.SetActivePuzzel(teamId, false);
            var resultId = _service.ActivePuzzelID(teamId);

            // Assert
            Assert.Equal(-1, resultId);
            Assert.Null(result);
        }
    }
}
