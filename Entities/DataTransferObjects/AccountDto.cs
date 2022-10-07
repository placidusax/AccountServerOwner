using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? AccountType { get; set; }
        public Guid? OwnerId { get; set; }
        //public Owner? Owner { get; set; } //----- if put this then it will cycle through the database a lot then error if wanna get the owner detail

        //add owner s othat the owner will not null 
    }
}
