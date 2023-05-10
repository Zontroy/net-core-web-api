using Oprazi.Bll.Services.IServices;
using Xunit;
using Moq;
using Oprazi.Dal.Repositories.IRepositories;
using AutoMapper;
using Oprazi.Utility.Utilities;
using Oprazi.Bll.Services;
using Oprazi.Dto.DTOs;
using System.Threading.Tasks;
using Oprazi.Entity.Entities;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace Oprazi.Test
{
    public class UserTests
    {
        private IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;

        public UserTests()
        {
            //_userRepository = new Mock<IUserRepository>();

            //var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            //_mapper = new Mapper(configuration);
        }
        //[Fact]
        //public async Task AddUserTest()
        //{
        //    //Arrange

        //    var entity = new User()
        //    {
        //        Id = "22",
        //        UserName = "Test Username",
        //        Name = "Test Name",
        //        Surname = "Test Surname"
        //    };


        //    _userRepository.Setup(repo => repo.Add(It.IsAny<User>()))
        //        .Returns(Task.FromResult(entity));


        //    _userService = new UserService(_userRepository.Object, _mapper);

        //    //Act
        //    var res = await _userService.AddUser(Mock.Of<UserToAddDTO>());

        //    //Assert
        //    Assert.IsType<UserToListDTO>(res);
        //    Assert.Equal(entity.Id, res.Id);
        //}

        //[Fact]
        //public async Task GetUsersTest()
        //{
        //    //Arrange
        //    var returnUsers = new List<User>() {
        //    new User()
        //    {
        //        Id = "1",
        //        UserName = "user1",
        //        Name = "name1",
        //        Surname = "surname1"
        //    },
        //    new User()
        //    {
        //        Id = "2",
        //        UserName = "user2",
        //        Name = "name2",
        //        Surname = "surname2"
        //    }
        //};
        //    _userRepository.Setup(repo => repo.GetList(It.IsAny<Expression<Func<User, bool>>>()))
        //            .Returns(Task.FromResult(returnUsers));

        //    //Act
        //    _userService = new UserService(_userRepository.Object, _mapper);
        //    var res = await _userService.GetUsers();

        //    //Assert
        //    Assert.Equal(2, res.Count());

        //}
    }
}
