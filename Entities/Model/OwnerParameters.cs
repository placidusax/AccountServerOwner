using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class OwnerParameters : QueryStringParameters
    {
        public uint MinYearOfBirth { get; set; }
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
    }
}
