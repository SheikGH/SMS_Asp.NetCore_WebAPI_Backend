using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface INationalityService
    {
        Task<IEnumerable<Nationality>> GetNationalityAsync();
    }
}
