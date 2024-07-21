using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface IScore
    {
        Guid Id { get; set; }
        int TeamIndex { get; set; }
        int SetNumber { get; set; }
        int Points { get; set; }
    }
}
