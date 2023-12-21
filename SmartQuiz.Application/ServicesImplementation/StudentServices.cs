using SmartQuiz.Application.DTO;
using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryServices<Student> _cloudinaryServices;

        public StudentServices(IUnitOfWork unitOfWork, ICloudinaryServices<Student> cloudinaryServices)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResponse<StudentDto>> DeleteStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public List<StudentDto> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<StudentDto>> GetStudentByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<StudentDto>> UpdateStudentAsync(string studentId, UpdateStudentDto updateStudentDto)
        {
            throw new NotImplementedException();
        }
    }
}
