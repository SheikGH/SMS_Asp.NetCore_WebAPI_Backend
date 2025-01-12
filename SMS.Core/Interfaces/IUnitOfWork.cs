using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        IFamilyMemberRepository FamilyMembers { get; }
        INationalityRepository Nationalities { get; }
        Task<int> CompleteAsync();
    }
}
