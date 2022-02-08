using Contact.Core.Models;
using Contact.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            person.UUID = Guid.NewGuid();
            var newPerson = await _personService.AddAsync(person);
            return Created(string.Empty, newPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetByUUID(Guid uuid)
        {
            var person = await _personService.GetByUUIDAsync(uuid);
            return Ok(person);
        }

        [HttpGet("{uuid}/contactinformations")]
        public async Task<IActionResult> GetWithContactInformationsByUUIDAsync(Guid uuid)
        {
            var person = await _personService.GetWithContactInformationsByUUIDAsync(uuid);
            return Ok(person);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Remove(Guid uuid)
        {
            var person = await _personService.GetByUUIDAsync((Guid)uuid);
            await _personService.RemoveAsync(person);
            return NoContent();
        }
    }
}
