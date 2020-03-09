using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRipBlog.Models
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly MyRipBlogContext _db;

        public TagRepository(MyRipBlogContext dbContext)
        {
            _db = dbContext;
        }
        public async Task Create(Tag entity)
        {
            await _db.Tags.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _db.Tags.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _db.Tags;
        }

        public Task<Tag> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> GetById(int id)
        {
            return await _db.Tags.FindAsync(id);
        }

        public Task<Tag> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, Tag entity)
        {
            _db.Tags.Update(entity);
            await _db.SaveChangesAsync();

        }
    }
}
