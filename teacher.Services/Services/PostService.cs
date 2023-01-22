using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Db.Data;
using teacher.Db.Repository.Repositories;
using teacher.Models.Models;
using teacher.Services.Interfaces;

namespace teacher.Services.Services
{
    public class PostService : RepositoryBase<Post>, IPostService
    {
        public PostService(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePost(Post post) => await CreateAsync(post);
        public async Task DeletePost(Post post) => await RemoveAsync(post);
        public async Task<Post> GetPost(int postId, bool trackChanges) => await FindByConditionAsync(e => e.Id.Equals(postId), trackChanges).Result.SingleOrDefaultAsync();


        public async Task<List<Post>> GetPostList(bool trackChanges) => (List<Post>)await FindAllAsync(trackChanges);
    }
}
