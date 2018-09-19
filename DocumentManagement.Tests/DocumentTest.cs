using AutoMapper;
using DocumentManagement.API.Controllers;
using DocumentManagement.Application.AutoMapper.Profiles;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces;
using DocumentManagement.Application.Services;
using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using DocumentManagement.Tests.Stubs;
using Microsoft.AspNetCore.Http;
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
        public void PostTestUserExistsOk()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(1);

            var documentStorageMock = new Mock<IDocumentStorage>();
            documentStorageMock.Setup(x => x.Store(It.IsAny<string>(), It.IsAny<string>())).Returns("C://files/file.docx");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(UserSub.SimpleUser);

            var userServiceMock = new Mock<UserService>(userRepositoryMock.Object);

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, userServiceMock.Object, documentStorageMock.Object);

            var controller = new DocumentController(documentServiceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["username"] = "victorhugo";

            var result = controller.Post(DocumentSub.DocumentInsert);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
            Assert.IsTrue((long)(((CreatedResult)result).Value) > 0);
        }

        [TestMethod]
        public void PostTestUserDontExistsOk()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(1);

            var documentStorageMock = new Mock<IDocumentStorage>();
            documentStorageMock.Setup(x => x.Store(It.IsAny<string>(), It.IsAny<string>())).Returns("C://files/file.docx");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>()));
            userRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(UserSub.UserCreated);

            var userServiceMock = new Mock<UserService>(userRepositoryMock.Object);

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, userServiceMock.Object, documentStorageMock.Object);

            var controller = new DocumentController(documentServiceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["username"] = "victorhugo2";

            var result = controller.Post(DocumentSub.DocumentInsert);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
            Assert.IsTrue((long)(((CreatedResult)result).Value) > 0);
        }

        [TestMethod]
        public void UpdateAccessDateOk()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.UpdateAccessDate(DocumentSub.SimpleDocument.Id));

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, null, null);

            var controller = new DocumentController(documentServiceMock.Object);

            var result = controller.UpdateAccessDate(DocumentSub.SimpleDocument.Id);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void UpdateAccessDateInvalidId()
        {
            var controller = new DocumentController(null);

            var result = controller.UpdateAccessDate(-1);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteOk()
        {
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(x => x.Delete(DocumentSub.SimpleDocument2));

            var documentServiceMock = new Mock<DocumentService>(documentRepositoryMock.Object, null, null);

            var controller = new DocumentController(documentServiceMock.Object);

            var result = controller.Delete(DocumentSub.SimpleDocument.Id);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            var controller = new DocumentController(null);

            var result = controller.Delete(-1);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
