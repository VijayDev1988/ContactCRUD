using Application.DTO;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactController : BaseController
    {
        private readonly IContatcQuery _contatcQuery;

        public ContactController(IContatcQuery contatcQuery)
        {
            _contatcQuery = contatcQuery;
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetContatcs()
        {
            var contact = await _contatcQuery.GetContatcs();
            return Ok(contact);
        }

        [HttpPost("contacts")]
        public async Task<IActionResult> AddContact(ContactViewModel contact)
        {

            var contactDetails = await _contatcQuery.AddContact(contact);
            return Ok(contactDetails);
        }

        [HttpDelete("contacts/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contatcQuery.DeleteContact(id);
            return Ok(contact);
        }

        [HttpPatch("conatcts/{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] JsonPatchDocument<ContactViewModel> contact)
        {
            var contactDetails = await _contatcQuery.GetContatcsById(id);

            var conatctDetailVieModel = new ContactViewModel
            {
                Firstname = contactDetails.Firstname,
                LastName = contactDetails.LastName,
                Email = contactDetails.Email
            };

            contact.ApplyTo(conatctDetailVieModel);


            var updatedContact = new Contact
            {
                Id = id,
                Firstname = conatctDetailVieModel.Firstname,
                LastName = conatctDetailVieModel.LastName,
                Email = conatctDetailVieModel.Email
            };

            var response = await _contatcQuery.UpdateContact(updatedContact);

            return Ok(response);

        }
    }
}

