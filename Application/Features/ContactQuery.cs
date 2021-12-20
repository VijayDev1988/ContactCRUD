using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class ContactQuery : IContatcQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactRepository _contactRepository;

        public ContactQuery(IUnitOfWork unitOfWork, IContactRepository contactRepository)
        {
            _unitOfWork = unitOfWork;
            _contactRepository = contactRepository;
        }
        public async Task<Response<Contact>> AddContact(ContactViewModel contact)
        {
            var contactDetails = new Contact
            {
                Email = contact.Email,
                Firstname = contact.Firstname,
                LastName = contact.LastName
            };

            if (!await IsUniqueEmail(contact.Email))
            {
                throw new ApiExceptions("Email Id already exists");
            }

            var result = await _unitOfWork.Repository<Contact>().AddAsync(contactDetails);
            return new Response<Contact>(result);
        }

        public async Task<Response<string>> DeleteContact(int id)
        {
            var contact = await _unitOfWork.Repository<Contact>().GetByIdAsync(id);
            if (contact == null)
            {
                throw new ApiExceptions("Unable to find the contact");
            }

            await _unitOfWork.Repository<Contact>().DeleteAsync(contact);
            return new Response<string>($"Contact{contact.Email} is deleted");
        }

        public async Task<Response<IEnumerable<Contact>>> GetContatcs()
        {
            var contact = await _unitOfWork.Repository<Contact>().GetAllAsync();
            return new Response<IEnumerable<Contact>>(contact);
        }
        public async Task<Contact> GetContatcsById(int id)
        {
            var contact = await _unitOfWork.Repository<Contact>().GetByIdAsync(id);
            if (contact == null) throw new ApiExceptions($"Contact with Id {id} not found");
            return contact;
        }

        public async Task<Response<string>> UpdateContact(Contact contact)
        {
            await _unitOfWork.Repository<Contact>().UpdateAsync(contact);
            return new Response<string>("Updated the contact details");
        }


        private async Task<bool> IsUniqueEmail(string emailId)
        {
            var contact = await _unitOfWork.Repository<Contact>().GetAllAsync();
            var email = contact.FirstOrDefault(email => email.Email.ToLower().Equals(emailId.ToLower()));
            return email == null ? true : false;
        }
    }
}
