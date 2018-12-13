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
        ITeamRepository _fakeTeamRepo;

        public SessieServiceTest()
        {
            _fakeTeamRepo = new TeamRepositoryFake();
            _fakeSessieRepo = new SessieRepoFake();
            _service = new SessieService(_fakeSessieRepo,_fakeTeamRepo);
        }

        [Fact]
        public void Get_Sessies()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Act
            var result = _service.GetSessies();

            //Assert
            Assert.Equal(1, result.Count);
            Assert.IsType<List<Sessie>>(result);
        }

        [Fact]
        public void Get_Sessie_ReturnItem()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
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
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var id = -1;

            // Act
            var result = _service.GetSessie(id);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void Get_Sessie_ByCode_ReturnItem()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var existingId = "aC";

            // Act
            var result = _service.GetSessieByCode(existingId);

            // Assert
            Assert.IsType<Sessie>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Sessie_ByCode_NotReturnItem()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var id = "dd";

            // Act
            var result = _service.GetSessieByCode(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Teams_Sessie() 
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var id = "ac";

            // Act
            var result = _service.GetTeamsBySessie(id);

            // Assert
            Assert.Equal(2, result.Count);

        }

        [Fact]
        public void Get_Teams_WrongSessie()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var id = "-1";

            // Act
            var result = _service.GetTeamsBySessie(id);

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public void Create_Sessie()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var Sessie = new Sessie()
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
            var result = _service.CreateSessie(Sessie);
            Console.WriteLine(result.ToString());
            // Assert
            Assert.NotEqual("-1",result);
        }

        [Fact]
        public void Get_Teams_Sessie_NewCreated()
        {
            (_fakeSessieRepo as SessieRepoFake).reset();
            (_fakeTeamRepo as TeamRepositoryFake).reset();
            //Arrange
            var sessie = new Sessie()
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
            var resultId = _service.CreateSessie(sessie);
            var result = _service.GetTeamsBySessie(resultId);

            // Assert
            Assert.Equal(result, sessie.Teams);
        }
    }
}
