using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    public interface IPasswordHasher
    {
        public string GenerateSalt();
        public string Hash(string password, string salt);
        public bool IsValid(string password, string hash, string salt);
    }
}
