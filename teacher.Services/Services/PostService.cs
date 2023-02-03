using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public async Task<IQueryable<Post>> GetPostList()
        {
            return await Task.Run(() => _repositoryContext.Posts
                                 .Join(_repositoryContext.Subject,
                                       post => post.Id,
                                       subject => subject.PostId,
                                       (post, subject) => new { post, subject })
                                 .AsEnumerable()
            .GroupBy(x => x.post.Id).Select(x => new Post
            {
                Id = x.Key,
                FirstName = x.First().post.FirstName,
                LastName = x.First().post.LastName,
                TeachSubjects = x.Select(y => y.subject)
            })
                                  .AsQueryable());

        } //=> await FindAllAsync().ContinueWith(x => (IQueryable<Post>)x.Result);
    }
}
