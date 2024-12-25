﻿
namespace OneLearn.Domain.Transactions.User
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
