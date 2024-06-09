using KolokwiumDF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumDF.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }



        [HttpGet("{idClient:int}")]
        public async Task<IActionResult> GetClient(int idClient) 
        {
            var result = await _clientRepository.GetClientAsync(idClient);
            
            if(result == null) 
            { 
                return NotFound();
            }
            
            return Ok(result);
        }
        
        [HttpPost("{idClient:int},{idSubscription:int},{payment:int}")]
        public async Task<IActionResult> AddData(int idClient, int idSubscription, int payment)
        {
            var result = await _clientRepository.AddDataAsync(idClient, idSubscription, payment);

            if (result == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }



    }
}
