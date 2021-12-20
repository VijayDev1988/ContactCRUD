using Application.DTO;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContatcQuery
    {
        public Task<Response<IEnumerable<Contact>>> GetContatcs();
        public Task<Response<string>> DeleteContact(int id);
        public Task<Response<Contact>> AddContact(ContactViewModel contact);

        public Task<Response<string>> UpdateContact(Contact contact);
        public Task<Contact> GetContatcsById(int id);

    }
}
