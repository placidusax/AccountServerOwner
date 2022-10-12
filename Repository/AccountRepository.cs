using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public PagedList<Account> AccountsByOwner(Guid ownerId, AccountParameters parameters)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

            return PagedList<Account>.ToPagedList(accounts,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public IEnumerable<Account> AccountsByOwner2(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId));
        }
    }
}
