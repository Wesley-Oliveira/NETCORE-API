using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTests
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdated { get; set; }
        public static string UserEmailUpdated { get; set; }
        public static Guid UserId { get; set; }

        public List<UserDto> UserDtoList = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTests()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdated = Faker.Name.FullName();
            UserEmailUpdated = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                UserDtoList.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}