using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface IAdmin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IUser User { get; set; }
    }
}
