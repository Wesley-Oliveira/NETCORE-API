using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class UserPost : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact]
        public async Task PostIntegrationTest()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registerPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registerPost.Name);
            Assert.Equal(_email, registerPost.Email);
            Assert.True(registerPost.Id != default(Guid));
        }
    }
}