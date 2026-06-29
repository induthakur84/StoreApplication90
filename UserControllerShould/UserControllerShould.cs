using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Order.API.Controllers;
using Order.Data.Interfaces;
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
    }
}
