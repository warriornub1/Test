using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLearn.Domain.Transactions.User
{
    public class UserType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
