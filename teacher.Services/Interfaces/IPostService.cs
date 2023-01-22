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
        Task<Post> GetPost(int postId, bool trackChanges);
        Task DeletePost(Post post);
        Task<List<Post>> GetPostList(bool trackChanges);
        Task CreatePost(Post post);
    }
}
