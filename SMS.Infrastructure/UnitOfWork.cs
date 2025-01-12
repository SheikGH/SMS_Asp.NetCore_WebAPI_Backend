using Microsoft.EntityFrameworkCore;
using SMS.Core.Interfaces;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private StudentRepository _studentRepository;
        private FamilyMemberRepository _familyMemberRepository;
        private NationalityRepository _nationalityRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IStudentRepository Students => _studentRepository ??= new StudentRepository(_context);
        public IFamilyMemberRepository FamilyMembers => _familyMemberRepository ??= new FamilyMemberRepository(_context);
        public INationalityRepository Nationalities => _nationalityRepository ??= new NationalityRepository(_context);

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log inner exception
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
