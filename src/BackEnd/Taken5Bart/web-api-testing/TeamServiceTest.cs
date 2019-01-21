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
using Moq;
using web_api_testing.Fakes;
using System.Linq;

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
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            var team = new TeamService(teamMock.Object, 
                                        spelerMock.Object,
                                        sessieMock.Object, 
                                        puzzelMock.Object);
            
            //Act
            var result = team.GetTeams();

            //Assert
            Assert.IsType<List<Team>>(result);
            Assert.NotNull(result);
        }

       
        [Fact]
        public void Get_Team_ReturnsAllItems()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            var team = new TeamService(teamMock.Object, 
                                        spelerMock.Object,
                                        sessieMock.Object, 
                                        puzzelMock.Object);
            
            //Act
            var result = team.GetTeams();
            // Assert
            Assert.Equal(3, result.Count); //3 van de Database en 3 gemaakt door de Creat_Sessie
        }
       
        [Fact]
        public void Get_Team_ReturnItem()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var existingId = 1;

            // Act
            var result = team.GetTeam(existingId);

            // Assert
            Assert.IsType<Team>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Team_NotReturnItem()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var id = -1;

            // Act
            var result = team.GetTeam(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_ScorePosition() 
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var id = 1;

            // Act
            int result = team.GetScorePos(id);

            // Assert
            Assert.Equal(2, result);

        }

        [Fact]
        public void Get_ScorePosition_NotExistingTeam()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = -1;

            // Act
            int result = team.GetScorePos(teamId);

            // Assert
            Assert.Equal(-1, result);
        }
        [Fact]
        public void Get_ScorePosition_NotTeamInSession()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 5;

            // Act
            int result = team.GetScorePos(teamId);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ExistingSpeler_Join_Team()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            spelerMock.Setup(s => s.GetSpeler(It.IsIn(1,2,3,4,5))).Returns((int i)=>_fakeSpelerRepo.GetSpeler(i));
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(1, 2, 3, 4, 5))).Returns((Speler)null);
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 1;
            var spelerId = 3;

            // Act
            bool result = team.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NotExistingSpeler_Join_Team()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            spelerMock.Setup(s => s.GetSpeler(It.IsIn(1, 2, 3, 4, 5))).Returns((int i) => _fakeSpelerRepo.GetSpeler(i));
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(1, 2, 3, 4, 5))).Returns((Speler)null);
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 5;
            var spelerId = 999;

            // Act
            bool result = team.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ExistingSpeler_Join_NotExistingTeam()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1))).Returns((Team)null);
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            spelerMock.Setup(s => s.GetSpeler(It.IsIn(1, 2, 3, 4, 5))).Returns((int i) => _fakeSpelerRepo.GetSpeler(i));
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(1, 2, 3, 4, 5))).Returns((Speler)null);
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 9999;
            var spelerId = 2;

            // Act
            bool result = team.SpelerJoin(spelerId, teamId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetActive_Puzzel_existingTeam()
        {
            var _LocalfakeTeamRepo = new TeamRepositoryFake();
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_LocalfakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int id) => { return GameDBFake.teams.Where(g => g.Id == id).FirstOrDefault(); });
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            teamMock.Setup(t => t.GetActivePuzzel(2)).Returns((int id) => { return GameDBFake.teams.Where(g => g.Id == id).FirstOrDefault().ActivePuzzel; });
            teamMock.Setup(t => t.GetActivePuzzel(1)).Returns((int id) => { return -1; });
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamIdActive = 2; //team 2 is bezig met een actieve puzzel
            var teamIdNotActive = 1; //team1 is niet bezig met een puzzel

            // Act
            var resultActive = team.ActivePuzzel(teamIdActive);
            var resultNotActive = team.ActivePuzzel(teamIdNotActive);
            var activepuzzelID = team.GetActivePuzzel(1);
            // Assert
            Assert.IsType<Puzzel>(resultActive);
            Assert.Equal(-1, activepuzzelID);
            Assert.Null(resultNotActive);

        }

        [Fact]
        public void GetActive_Puzzel_NotexistingTeam()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int i) => _fakeTeamRepo.GetTeam(i));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 99999;

            // Act
            var result = team.ActivePuzzel(teamId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetActive_PuzzelID_NotexistingTeam()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_fakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int i) => _fakeTeamRepo.GetTeam(i));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 99999;

            // Act
            var result = team.ActivePuzzelID(teamId);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void SetActive_Puzzel_ExistingTeam()
        {
            var _LocalfakeTeamRepo = new TeamRepositoryFake();
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_LocalfakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int i) => _LocalfakeTeamRepo.GetTeam(i));
            teamMock.Setup(t => t.SetActivePuzzel(It.IsIn(1, 2), It.IsAny<int>())).Callback<int, int>((a,b)=> _LocalfakeTeamRepo.SetActivePuzzel(a,b));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 1;

            // Act
            var result = team.SetActivePuzzel(teamId,false);
            var resultId = team.ActivePuzzelID(teamId);
            // Assert
            Assert.IsType<Puzzel>(result);
            Assert.NotEqual(-1, resultId);
        }
        [Fact]
        public void ResetActive_Puzzel_ExistingTeam()
        {
            var _LocalfakeTeamRepo = new TeamRepositoryFake();
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_LocalfakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int i) => _LocalfakeTeamRepo.GetTeam(i));
            teamMock.Setup(t => t.SetActivePuzzel(It.IsIn(1, 2), It.IsAny<int>())).Callback<int, int>((a, b) => _LocalfakeTeamRepo.SetActivePuzzel(a, b));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 1;

            // Act
            var result = team.SetActivePuzzel(teamId, true);
            var resultId = team.ActivePuzzelID(teamId);
            // Assert
            Assert.Null(result);
            Assert.Equal(-1, resultId);

        }

        [Fact]
        public void SetActive_Puzzel_NotexistingTeam()
        {
            var _LocalfakeTeamRepo = new TeamRepositoryFake();
            var spelerMock = new Mock<ISpelerRepository>();
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            teamMock.Setup(t => t.GetTeams()).Returns(_LocalfakeTeamRepo.GetTeams());
            teamMock.Setup(t => t.GetTeam(It.IsIn(1, 2))).Returns((int i) => _LocalfakeTeamRepo.GetTeam(i));
            teamMock.Setup(t => t.SetActivePuzzel(It.IsIn(1, 2), It.IsAny<int>())).Callback<int, int>((a, b) => _LocalfakeTeamRepo.SetActivePuzzel(a, b));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2))).Returns((Team)null);
            puzzelMock.Setup(p => p.GetPuzzel(It.IsAny<int>())).Returns(new Puzzel());
            var team = new TeamService(teamMock.Object,
                                        spelerMock.Object,
                                        sessieMock.Object,
                                        puzzelMock.Object);
            //Arrange
            var teamId = 9999;

            // Act
            var result = team.SetActivePuzzel(teamId, false);
            var resultId = team.ActivePuzzelID(teamId);

            // Assert
            Assert.Equal(-1, resultId);
            Assert.Null(result);

        }
    }
}
