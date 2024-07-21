using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Coach : ICoach
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string ContactInfo { get; set; }
        IUser ICoach.User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
