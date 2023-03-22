using Microsoft.EntityFrameworkCore;
using SoftwareLab.Core.Entities;
using SoftwareLab.Core.Repositories;
using SoftwareLab.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLab.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly DbSet<User> _users;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _users=context.Set<User>();
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
