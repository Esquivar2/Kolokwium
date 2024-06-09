using KolokwiumDF.Models.DTO;

namespace KolokwiumDF.Repositories
{
    public interface IClientRepository
    {
        public Task<ClientDTO> GetClientAsync(int idClient);
    }
}
