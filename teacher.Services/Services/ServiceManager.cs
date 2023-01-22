using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Db.Data;
using teacher.Services.Interfaces;

namespace teacher.Services.Services
{
    public class ServiceManager : IServiceManager
    {
        private RepositoryContext _repositoryContext;
        private IPostService _postService;
        public ServiceManager(RepositoryContext repositoryContext) 
        {
            _repositoryContext = repositoryContext;
        }
        public IPostService Post
        {
            get
            {
                if (_postService is null)
                    _postService = new PostService(_repositoryContext);
                return _postService;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
