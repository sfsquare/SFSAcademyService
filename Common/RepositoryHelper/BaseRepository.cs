using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RepositoryHelper
{
    public class BaseRepository<T>
    {
        public T iRepository;
        public BaseRepository(string repositoryName)
        {
            iRepository = new RepositoryFactory().GetRepositoryObject<T>(repositoryName);
        }
    }
}
