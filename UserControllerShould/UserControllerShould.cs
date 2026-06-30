using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Order.API.Controllers;
using Order.Data.Interfaces;
using Order.Dto.DTO.Request;
using Order.Dto.DTO.Response;

namespace UserControllerShould
{
    public class UserControllerShould
    {

        private readonly IUserInterface _userMock;

        private readonly UserController _userController;

        public UserControllerShould()
        {
            //Arrange
            _userMock= Substitute.For<IUserInterface>();
            _userController= new UserController( _userMock );
        }


        [Fact]
        public async Task GiveRequest_WhenGetAll_ThenReturnUsers()
        {

            //Arrange
            var users = new List<UserResponse>
            {

                new UserResponse
                {
                    Id=1,
                    Name="Ram"
                },
                new UserResponse
                {
                    Id=2,
                    Name="Ram12"
                }
            }; 

            _userMock.GetAll().Returns( users );
            //Act

            var result= await _userController.GetAll();


            //Arrange

            result.Should().NotBeNull();

            var okResult= Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<UserResponse>>
                 (okResult.Value);

            data.Should().HaveCount(2);
            
        }


        [Fact]

        public async Task GivenRequest_WhenGetById_ThenRetunNotFound()
        {
            //Arrange
            _userMock.GetById(1).Returns((UserResponse)null);   
            //Act
            var result= await _userController.Getbyid(1);
            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }


        [Fact]

        public async Task GivenRequest_WhenGetById_ThenRetunUser()
        {
            //Arrange

            var user = new UserResponse
            {
                Id = 1,
                Name = "Ram"
            };



            _userMock.GetById(1).Returns(user);
            //Act
            var result = await _userController.Getbyid(1);
            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }


        #region Create TEst user

        [Fact]
        public async Task GivenRequest_WhenCreate_ThenReturnCreatedUser()
        {
            //Arrange

            var userRequest = new UserRequest
            {
                Name = "Ram"
            };


            var userResponse = new UserResponse
            {
                Id = 1,
                Name = "Ram"
            };

            _userMock.Create(userRequest).Returns(userResponse);


            //Act
            var result= await _userController.Create(userRequest);



            ///Assert
            ///
            result.Should().BeOfType<OkObjectResult>();


        }

        #endregion

        #region Upate user

        [Fact]
        public async Task GivenRequest_WhenUpdate_ThenReturnUpdatedUser()
        {
            //Arrange

            var userRequest = new UserRequest
            {
                Name = "Ram updated"
            };


            var userResponse = new UserResponse
            {
                Id = 1,
                Name = "Ram updated"
            };

            _userMock.Update(1,userRequest).Returns(userResponse);


            //Act
            var result = await _userController.Update(1,userRequest);



            ///Assert
            ///
            result.Should().BeOfType<OkObjectResult>();


        }

        #endregion

        [Fact]

        public async Task GivenValidRequest_WhenDelete_ThenReturnTrue()
        {

            ///Arrange
            _userMock.Delete(1).Returns(true);


            //Act

            var result= await _userController.Delete(1);

            //Asset
            result.Should().BeOfType<OkObjectResult>();


        }


    }
}
