using KolokwiumDF.Context;
using KolokwiumDF.Models;
using KolokwiumDF.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace KolokwiumDF.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MasterContext _context;
        public ClientRepository(MasterContext context) { _context = context; }
        public async Task<ClientDTO> GetClientAsync(int idClient)
        {
            var client = await _context
                .Clients
                .FirstOrDefaultAsync(e => e.IdClient == idClient);

            if (client == null)
            {
                return null;
            }

            var discount = await _context.Discounts.FirstOrDefaultAsync(e => e.IdClient == idClient);

            var idSale = await _context.Sales.Select(e => idClient == e.IdClient).ToListAsync();
            var subscriptions = await _context.Subscriptions.Select(e => e.Sales == idSale).ToListAsync();

           


            var clientDTO = new ClientDTO
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
                Value = discount.Value,
                //....
            };

            

            return clientDTO;
        }

        public async Task<int> AddDataAsync(int idClient, int idSubscription, int payment)
        {
            var client = await _context
                .Clients
                .FirstOrDefaultAsync(e => e.IdClient == idClient);

            if (client == null)
            {
                return 0;
            }

            var subscription = await _context
                .Subscriptions
                .FirstOrDefaultAsync(e => e.IdSubscription == idSubscription);

            if (subscription == null)
            {
                return 0;
            }

            if(subscription.EndTime <  DateTime.UtcNow)
            {
                return 0;
            }

            if (subscription.Payments.Count == 0)
            {
                return 0;
            }

            return 1;
        }
    }
}
