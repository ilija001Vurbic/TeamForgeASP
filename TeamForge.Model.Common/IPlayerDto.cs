using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface IPlayerDto
    {
        Guid Id { get; set; }
        string Name { get; set; }
        int Height { get; set; }
        int Weight { get; set; }
        int Age { get; set; }
        int Blocking { get; set; }
        int Attacking { get; set; }
        int Serving { get; set; }
        int Passing { get; set; }
        int Setting { get; set; }
    }
}
