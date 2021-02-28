using AutoMapper;
using Contact.Mgmt.API.Controllers;
using Contact.Mgmt.API.Mappers;
using Contact.Mgmt.DataModel.Interfaces;
using Contact.Mgmt.DataModel.Models;
using Contact.Mgmt.DataModel.ResponseHandler;
using Contact.Mgmt.UnitTest.MockData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Contact.Mgmt.UnitTest.Controller
{
    public class ContactControllerTest
    {
        private readonly IMapper _mapper;
        private readonly ContactsController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerTest()
        {
            _mapper = ConfigureMapper();
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactsController(_contactServiceMock.Object, _mapper);
        }

        private static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.AddProfile(typeof(ResourceModelMapper));
            });
            return new Mapper(config);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void ContactsController_WhereMapperIsNull_ThrowsArgumentNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContactsController(_contactServiceMock.Object,null));
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void ContactsController_WhereContactServiceIsNull_ThrowsArgumentNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContactsController(null,_mapper));
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task AddContactAsync_WhereInputIsValid_ReturnsSuccessContactStatus()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.AddContactAsync(It.IsAny<ContactInfo>()))
                .Returns(Task.FromResult(new ResultHandler(ServiceMock.GetContact())));
            var controller = new ContactsController(_contactServiceMock.Object,_mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (OkObjectResult)await controller.PostAsync(ServiceMock.GetAddContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task UpdateContactAsync_WhereInputIsInvalid_ReturnsFailureContactStatus()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.UpdateContactAsync(It.IsAny<int>(), It.IsAny<ContactInfo>()))
                .Returns(Task.FromResult(new ResultHandler(String.Empty)));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (BadRequestObjectResult)await controller.PutAsync(ServiceMock.GetNonExistingContactRequest(), ServiceMock.GetInvalidAddContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task UpdateContactAsync_WhereInputIsValid_ReturnsSuccessContactStatus()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.UpdateContactAsync(It.IsAny<int>(), It.IsAny<ContactInfo>()))
                .Returns(Task.FromResult(new ResultHandler(ServiceMock.GetContact())));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (OkObjectResult)await controller.PutAsync(ServiceMock.GetExistingContactRequest(), ServiceMock.GetAddContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task AddContactAsync_WhereInputIsInvalid_ReturnsFailureContactStatus()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.AddContactAsync(It.IsAny<ContactInfo>()))
                .Returns(Task.FromResult(new ResultHandler(String.Empty)));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (BadRequestObjectResult)await controller.PostAsync(ServiceMock.GetInvalidAddContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task DeleteUsersAsync_WhereInputIsValid_ReturnsSuccessCode()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.DeleteContactAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResultHandler(ServiceMock.GetContact())));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (OkObjectResult)await _controller.DeleteAsync(ServiceMock.GetExistingContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task DeleteUsersAsync_WhereUserDoesNotExist_ReturnsSuccessCode()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.DeleteContactAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResultHandler(String.Empty)));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var result = (BadRequestObjectResult)await _controller.DeleteAsync(ServiceMock.GetNonExistingContactRequest());

            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task GetAllUsersAsync_WhereContactsExist_ReturnsSuccessCode()
        {
            //Arrange
            _contactServiceMock.Setup(x => x.GetContactsAsync())
                .Returns(Task.FromResult(ServiceMock.GetAllContacts()));
            var controller = new ContactsController(_contactServiceMock.Object, _mapper)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            //Act
            var expected = typeof(List<ContactInfo>);
            var result = await _controller.GetAllContactsAsync();

            //Assert
            Assert.IsType<List<ContactInfo>>(result);
            Assert.IsType(expected, result);
        }
    }
}
