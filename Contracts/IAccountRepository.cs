using Entities.Helpers;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        PagedList<Account> AccountsByOwner(Guid ownerId, AccountParameters parameters);
        IEnumerable<Account> AccountsByOwner2(Guid ownerId);
    }
}
