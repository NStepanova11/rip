using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRipBlog.Models
{
    public class UserRepository : IRepository<User>
    {
        private readonly MyRipBlogContext _db;

        public UserRepository(MyRipBlogContext dbContext)
        {
            _db = dbContext;
        }
        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task<User> GetById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task Update(int id, User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
