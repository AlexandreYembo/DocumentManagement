using AutoMapper;
using DocumentManagement.API.Controllers;
using DocumentManagement.Application.AutoMapper.Profiles;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Services;
using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Tests.Stubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DocumentManagement.Tests
{
    [TestClass]
    public class DocumentTest
    {
        [TestInitialize]
        public void Setup()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfile<DocumentProfile>());
        }

        [TestMethod]
        public void ListTest()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.List()).Returns(DocumentSub.ListDocument);

            var documentStorageMock = new Mock<IDocumentStorage>();
            documentStorageMock.Setup(x => x.GetBase64(It.IsAny<string>())).Returns(string.Empty);

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, null, documentStorageMock.Object);

            var controller = new DocumentController(documentServiceMock.Object);

            var result = controller.List();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(true, ((IEnumerable<DocumentDTO>)((ObjectResult)result).Value).Any());
        }

        [TestMethod]
        public void PostTestOk()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.List()).Returns(DocumentSub.ListDocument);

            var documentStorageMock = new Mock<IDocumentStorage>();
            documentStorageMock.Setup(x => x.GetBase64(It.IsAny<string>())).Returns(string.Empty);

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, null, documentStorageMock.Object);

            var controller = new DocumentController(documentServiceMock.Object);

            var result = controller.List();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(true, ((IEnumerable<DocumentDTO>)((ObjectResult)result).Value).Any());
        }
    }
}
