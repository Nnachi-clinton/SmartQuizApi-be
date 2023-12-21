using AutoMapper;
using Serilog;
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
        //private readonly ICloudinaryServices<Student> _cloudinaryServices;
        private readonly IMapper _mapper;

        public StudentServices(IUnitOfWork unitOfWork, ICloudinaryServices<Student> cloudinaryServices, IMapper mapper)
        {
            _unitOfWork = unitOfWork;            
            //_cloudinaryServices = cloudinaryServices;
            _mapper = mapper;
        }

        public Task<ApiResponse<StudentDto>> DeleteStudentAsync(string studentId)
        {
            try
            {
                var existingStudent = _unitOfWork.StudentRepository.GetStudentById(studentId);
                if (existingStudent == null)
                {
                    return Task.FromResult(new ApiResponse<StudentDto>(false, 404, $"Student not found."));

                }
                _unitOfWork.StudentRepository.DeleteStudentAsync(existingStudent);
                _unitOfWork.SaveChanges();
                return Task.FromResult(new ApiResponse<StudentDto>(true, 200, $"Student deleted successfully ."));
            }
            catch (Exception ex) 
            {
                return Task.FromResult(new ApiResponse<StudentDto>(false, 500, $"An error occured during this process. {ex.Message}"));
            }
            
        }

        public List<StudentDto> GetAllStudents()
        {
            var students = _unitOfWork.StudentRepository.GetStudentsAsync();
            List<StudentDto> list = new();

            foreach (var student in students)
            {
                var presponse = new StudentDto()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Address = student.Address,
                    Gender = student.Gender,
                    ImageUrl = student.ImageUrl,
                    State   = student.State,
                };
                list.Add(presponse);
            }

            return list;
        }

        public ApiResponse<StudentDto> GetStudentByIdAsync(string studentId)
        {
            try
            {
                var student = _unitOfWork.StudentRepository.GetStudentById(studentId);

                if (student == null)
                {
                    return ApiResponse<StudentDto>.Failed(false, "Student not found.", 404, new List<string> { "Student not found." });
                }

                var studentDto = _mapper.Map<StudentDto>(student);

                return ApiResponse<StudentDto>.Success(studentDto, "Student found.", 200);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving the student. StudentId: {StudentId}", studentId);
                return ApiResponse<StudentDto>.Failed(false, "An error occurred while retrieving the user.", 500, new List<string> { ex.Message });
            }
        }

        public ApiResponse<bool> UpdateStudentAsync(string studentId, UpdateStudentDto updateStudentDto)
        {
            try
            {
                var student = _unitOfWork.StudentRepository.GetStudentById(studentId);

                if (student == null)
                {
                    return ApiResponse<bool>.Failed(false, "Student not found.", 404, new List<string> { "Student not found." });
                }

                _mapper.Map(updateStudentDto, student);

                _unitOfWork.StudentRepository.GetStudentById(studentId);
                _unitOfWork.SaveChanges();

                return ApiResponse<bool>.Success(true, "Student updated successfully.", 200);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating the student. StudentId: {StudentId}", studentId);

                return ApiResponse<bool>.Failed(false, "An error occurred while updating the student.", 500, new List<string> { ex.Message });
            }
        }
    }
}
