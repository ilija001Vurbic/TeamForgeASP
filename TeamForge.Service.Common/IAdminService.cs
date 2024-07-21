using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface IAdminService
    {
        void AddAdmin(Admin admin);
        Admin GetAdminById(Guid adminId);
        IEnumerable<Admin> GetAllAdmins();
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Guid adminId);
    }
}
