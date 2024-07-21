using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;
using TeamForge.Repository.Common;
using TeamForge.Service.Common;

namespace TeamForge.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public void AddAdmin(Admin admin)
        {
            adminRepository.AddAdmin(admin);
        }

        public Admin GetAdminById(Guid adminId)
        {
            return adminRepository.GetAdminById(adminId);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return adminRepository.GetAllAdmins();
        }

        public void UpdateAdmin(Admin admin)
        {
            adminRepository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(Guid adminId)
        {
            adminRepository.DeleteAdmin(adminId);
        }
    }
}
