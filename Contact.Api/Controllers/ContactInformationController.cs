using Contact.Core.Models;
using Contact.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : Controller
    {
        private readonly IContactInformationService _service;
        public ContactInformationController(IContactInformationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactInformation contactInformation)
        {
            contactInformation.UUID = Guid.NewGuid();
            var newPerson = await _service.AddAsync(contactInformation);
            return Created(string.Empty, newPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactInformations = await _service.GetAllAsync();
            return Ok(contactInformations);
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetByUUID(Guid uuid)
        {
            var person = await _service.GetByUUIDAsync(uuid);
            return Ok(person);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Remove(Guid uuid)
        {
            var person = await _service.GetByUUIDAsync((Guid)uuid);
            await _service.RemoveAsync(person);
            return NoContent();
        }
        
        #region Reports
        [HttpGet("LocationReport")]
        public async Task<IActionResult> PersonsLocationReport()
        {
            var report = await _service.PersonsLocationReportAsync();
            return Ok(report);
        }
        #endregion
    }
}
