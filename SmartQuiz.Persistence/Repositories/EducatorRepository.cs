﻿using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Domain.Entities;
using SmartQuiz.Persistence.Context;
using System.Linq.Expressions;

namespace SmartQuiz.Persistence.Repositories
{
    public class EducatorRepository : GenericRepository<Educator>, IEducatorRepository
    {
        private readonly SmartQuizDbContext _context;

        public EducatorRepository(SmartQuizDbContext context) : base(context) 
        {
            _context = context;
        }

        public void AddEducatorAsync(Educator educator) =>           
             AddAsync(educator);
        

        public void DeleteAllEducatorsAsync(List<Educator> educators)
        {
            DeleteAllAsync(educators);
        }

        public void DeleteEducatorAsync(Educator educator)
        {
            DeleteAsync(educator);
        }

        public List<Educator> FindEducatorAsync(Expression<Func<Educator, bool>> condition)
        {
            return FindAsync(condition);
        }

        public Educator GetEducatorById(string id)
        {
            return GetByIdAsync(id);
        }

        public List<Educator> GetEducatorsAsync()
        {
            return GetAllAsync();
        }

        public void UpdateEducatorAsync(Educator educator)
        {
            UpdateAsync(educator);
        }
    }
}
