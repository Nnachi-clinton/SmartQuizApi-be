﻿using SmartQuiz.Domain.Entities;
using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IQuizRepository : IGenericRepository<Quiz>
    {
        List<Quiz> GetQuizAsync();
        List<Quiz> GetAllQuiz(Expression<Func<Quiz, bool>> educatorid);
        void AddQuizAsync(Quiz quiz);
        void DeleteQuizAsync(Quiz quiz);
        void DeleteAllQuizAsync(List<Quiz> quiz);
        public List<Quiz> FindQuizAsync(Expression<Func<Quiz, bool>> condition);
        Quiz GetQuizById(string id);
        void UpdateQuizAsync(Quiz quiz);
    }
}
