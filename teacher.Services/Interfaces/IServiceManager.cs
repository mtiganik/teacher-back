using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teacher.Services.Interfaces
{
    public interface IServiceManager
    {
        IPostService Post { get; }

        Task SaveAsync();
    }
}
