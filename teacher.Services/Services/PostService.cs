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
        private readonly RepositoryContext _repositoryContext;
        public PostService(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task CreatePost(Post post) => await CreateAsync(post);
        public async Task DeletePost(Post post) => await RemoveAsync(post);
        public async Task<Post> GetPost(int postId)
        {   
            var post = await FindByConditionAsync(e => e.Id.Equals(postId)).Result.SingleOrDefaultAsync();
            if (post == null) return null;
            post.TeachingTakesPlace = await _repositoryContext.TeachingTakesPlace.Where(u => u.PostId== postId).SingleOrDefaultAsync();
            post.TeachSubjects = await _repositoryContext.Subject.Where(u => u.PostId== postId).ToListAsync();
            return post;
        }

        public async Task<List<Post>> GetPostList() => (List<Post>)await FindAllAsync();
    }
}
