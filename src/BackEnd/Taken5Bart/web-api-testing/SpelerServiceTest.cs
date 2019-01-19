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
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();

            spelerMock.Setup(s => s.GetSpelers()).Returns(_fakeSpelerRepo.GetSpelers());
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            //Act
            var okResult = speler.GetSpelers();

            //Assert
            Assert.IsType<List<Speler>>(okResult);
        }

        [Fact]
        public void Get_Speler_ReturnsAllItems()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();
            spelerMock.Setup(s => s.GetSpelers()).Returns(_fakeSpelerRepo.GetSpelers());
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            //Act
            var result = speler.GetSpelers();

            // Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void Get_Speler_ReturnItem()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();
            spelerMock.Setup(s => s.GetSpeler(5)).Returns(_fakeSpelerRepo.GetSpeler(5));
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            //Arrange
            var existingId = 5;

            // Act
            Speler result = speler.GetSpeler(existingId);

            // Assert
            Assert.IsType<Speler>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Speler_NotReturnItem()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(1,2,3,4,5))).Returns((Speler)null); //returned null van het type speler
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);
            //Arrange
            var id = -1;

            // Act
            Speler result = speler.GetSpeler(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Team_ReturnItem()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();

            //Arrange
            spelerMock.Setup(s => s.GetSpeler(2)).Returns(_fakeSpelerRepo.GetSpeler(2));
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(2)).Returns(_fakeTeamRepo.GetTeam(2));
            teamMock.Setup(t => t.GetTeam(2)).Returns(_fakeTeamRepo.GetTeam(2));
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            var id = 2;

            // Act
            Team result = speler.GetTeamFromSpeler(id);
            
            // Assert
            Assert.IsType<Team>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Team_NotReturnItem() 
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();

            //Arrange
            var id = 2;

            spelerMock.Setup(s => s.GetSpeler(id)).Returns(_fakeSpelerRepo.GetSpeler(id));
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(2))).Returns((Speler)null);
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(2)).Returns(_fakeTeamRepo.GetTeam(2));
            teamMock.Setup(t => t.GetTeam(3)).Returns(_fakeTeamRepo.GetTeam(3));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1,2,3))).Returns((Team)null);
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            var sid = -1;
            // Act
            Team result = speler.GetTeamFromSpeler(sid);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Team_NotInTeam()
        {
            var spelerMock = new Mock<ISpelerRepository>();
            var teamMock = new Mock<ITeamRepository>();

            //Arrange
            var id = 2;

            spelerMock.Setup(s => s.GetSpeler(id)).Returns(new Speler() {
                Id = 2,
                AssignedTeam = null,
                DeviceId = "1",
                
            });
            spelerMock.Setup(s => s.GetSpeler(It.IsNotIn(2))).Returns((Speler)null);
            teamMock.Setup(t => t.GetTeam(1)).Returns(_fakeTeamRepo.GetTeam(1));
            teamMock.Setup(t => t.GetTeam(2)).Returns(_fakeTeamRepo.GetTeam(2));
            teamMock.Setup(t => t.GetTeam(3)).Returns(_fakeTeamRepo.GetTeam(3));
            teamMock.Setup(t => t.GetTeam(It.IsNotIn(1, 2, 3))).Returns((Team)null);
            var speler = new SpelerService(spelerMock.Object, teamMock.Object);

            var sid = 2;
            // Act
            Team result = speler.GetTeamFromSpeler(sid);

            // Assert
            Assert.Null(result);
        }
    }
}
