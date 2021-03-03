using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);

        Task<CepDto> GetCep(string cep);

        Task<CepDtoCreateResult> Post(CepDtoCreate cep);

        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);

        Task<bool> Delete(Guid id);
    }
}