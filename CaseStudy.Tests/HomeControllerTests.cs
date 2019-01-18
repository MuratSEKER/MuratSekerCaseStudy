using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CaseStudyServices;
using Moq;
using MuratSekerCaseStudy.Controllers;
using MuratSekerCaseStudy.Data.Entities;
using Xunit;

namespace CaseStudy.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void CanReadFile()
        {
            Mock<IReadFileService> mock = new Mock<IReadFileService>();
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles/jsonFile.json");

            HomeController home = new HomeController(mock.Object);

            IEnumerable<Hotel> result = home.List().ViewData.Model as IEnumerable<Hotel>;

            var list = mock.Setup(m => m.ReadFile(path,true));

            Assert.NotNull(list);
        }
    }
}
