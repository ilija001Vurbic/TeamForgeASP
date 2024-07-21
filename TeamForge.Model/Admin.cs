using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Admin : IAdmin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        IUser IAdmin.User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
