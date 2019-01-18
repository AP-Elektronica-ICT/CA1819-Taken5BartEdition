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

namespace web_api_testing
{

    public class SessieServiceTest
    {
        SessieService _service;
        ISessionRepository _fakeSessieRepo;
        ITeamRepository _fakeTeamRepo;
        IPuzzelRepository _fakePuzzelRepo;

        public SessieServiceTest()
        {
            _fakeTeamRepo = new TeamRepositoryFake();
            _fakeSessieRepo = new SessieRepoFake();
            _fakePuzzelRepo = new PuzzelRepoFake();
            _service = new SessieService(_fakeSessieRepo,_fakeTeamRepo, _fakePuzzelRepo);
        }

        [Fact]
        public void Get_Sessies()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessies()).Returns(_fakeSessieRepo.GetSessies());
            var sessie = new SessieService(sessieMock.Object,teamMock.Object,puzzelMock.Object);
            //Act
            var result = sessie.GetSessies();

            //Assert
            Assert.Equal(1, result.Count);
            Assert.IsType<List<Sessie>>(result);
        }

        [Fact]
        public void Get_Sessie_ReturnItem()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var existingId = 1;

            // Act
            var result = sessie.GetSessie(existingId);

            // Assert
            Assert.IsType<Sessie>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Sessie_NotReturnItem()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessie(1)).Returns(_fakeSessieRepo.GetSessie(1));
            sessieMock.Setup(s => s.GetSessie(It.IsNotIn(1, 2, 3, 4, 5))).Returns((Sessie)null);
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var id = -1;

            // Act
            var result = sessie.GetSessie(id);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void Get_Sessie_ByCode_ReturnItem()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessies()).Returns(_fakeSessieRepo.GetSessies());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var existingId = "aC";

            // Act
            var result = sessie.GetSessieByCode(existingId);

            // Assert
            Assert.IsType<Sessie>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Sessie_ByCode_NotReturnItem()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessies()).Returns(_fakeSessieRepo.GetSessies());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var id = "dd";

            // Act
            var result = sessie.GetSessieByCode(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Teams_Sessie() 
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessies()).Returns(_fakeSessieRepo.GetSessies());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var id = "ac";

            // Act
            var result = sessie.GetTeamsBySessie(id);

            // Assert
            Assert.Equal(2, result.Count);

        }

        [Fact]
        public void Get_Teams_WrongSessie()
        {
            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.GetSessies()).Returns(_fakeSessieRepo.GetSessies());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var id = "-1";

            // Act
            var result = sessie.GetTeamsBySessie(id);

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public void Create_Sessie()
        {

            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.AddSessie(It.IsAny<Sessie>())).Returns((Sessie newS)=> {
                newS.Id = 5;
                newS.Code = "12";
                return newS;
            });
            puzzelMock.Setup(p => p.GetPuzzels()).Returns(_fakePuzzelRepo.GetPuzzels());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);
            //Arrange
            var newSessie = new Sessie()
            {
                StartTijd = DateTime.Now,
                Teams = new List<Team>()
                {
                    new Team()
                    {
                        TeamNaam = "Jonas"
                    },
                    new Team()
                    {
                        TeamNaam = "Viktor"
                    },
                    new Team()
                    {
                        TeamNaam = "Joren"
                    },
                }

            };

            // Act
            var result = sessie.CreateSessie(newSessie);
            Console.WriteLine(result.ToString());
            // Assert
            Assert.NotEqual("-1",result);
        }

        [Fact]
        public void Get_Teams_Sessie_NewCreated()
        {
            //Arrange
            var newSessie = new Sessie()
            {
                StartTijd = DateTime.Now,
                Teams = new List<Team>()
                {
                    new Team()
                    {
                        TeamNaam = "Jonas"
                    },
                    new Team()
                    {
                        TeamNaam = "Viktor"
                    },
                    new Team()
                    {
                        TeamNaam = "Joren"
                    },
                }

            };

            var sessieMock = new Mock<ISessionRepository>();
            var teamMock = new Mock<ITeamRepository>();
            var puzzelMock = new Mock<IPuzzelRepository>();
            sessieMock.Setup(s => s.AddSessie(It.IsAny<Sessie>())).Returns((Sessie newS) => {
                newS.Id = 5;
                newS.Code = "12";
                return newS;
            });
            sessieMock.Setup(s => s.GetSessies()).Returns(()=> {
                var sessies = _fakeSessieRepo.GetSessies();
                sessies.Add(newSessie);
                return sessies;
                });
            puzzelMock.Setup(p => p.GetPuzzels()).Returns(_fakePuzzelRepo.GetPuzzels());
            var sessie = new SessieService(sessieMock.Object, teamMock.Object, puzzelMock.Object);

           

            // Act
            var resultId = sessie.CreateSessie(newSessie);
            var result = sessie.GetTeamsBySessie(resultId);

            // Assert
            Assert.Equal(result, newSessie.Teams);
        }
    }
}
