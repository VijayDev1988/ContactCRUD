using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        private readonly DbSet<Contact> _contact;
        public ContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _contact = dbContext.Set<Contact>();
        }
    }
}
