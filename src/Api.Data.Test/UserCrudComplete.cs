using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "User CRUD")]
        [Trait("CRUD", "UserEntity")]
        public async Task CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registerCreated = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registerCreated);
                Assert.Equal(_entity.Email, _registerCreated.Email);
                Assert.Equal(_entity.Name, _registerCreated.Name);
                Assert.False(_registerCreated.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registerUpdated = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registerUpdated);
                Assert.Equal(_entity.Email, _registerUpdated.Email);
                Assert.Equal(_entity.Name, _registerUpdated.Name);

                var _registerExists = await _repository.ExistAsync(_registerUpdated.Id);
                Assert.True(_registerExists);

                var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.Email, _registerSelected.Email);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);

                var _allRegisters = await _repository.SelectAsync();
                Assert.NotNull(_allRegisters);
                Assert.True(_allRegisters.Count() > 1);

                var _removed = await _repository.DeleteAsync(_registerSelected.Id);
                Assert.True(_removed);

                var _defaultAdminUser = await _repository.FindByLogin("admin@mail.com");
                Assert.NotNull(_defaultAdminUser);
                Assert.Equal("admin@mail.com", _defaultAdminUser.Email);
                Assert.Equal("Admin", _defaultAdminUser.Name);
            }
        }
    }
}