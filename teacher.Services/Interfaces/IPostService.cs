using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Models.Models;

namespace teacher.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post>? GetPost(int postId);
        Task DeletePost(Post post);
        Task<IQueryable<Post>> GetPostList();
        Task CreatePost(Post post);
    }
}
