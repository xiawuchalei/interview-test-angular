using MediatR;
using StudentApi.Models.Students;
using StudentApi.Services;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class AddStudentRequest : IRequest<AddStudentResponse>
    {
        public Student Student { get; set; }
    }

    public class AddStudentResponse
    {
        public bool Success { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentRequest, AddStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<AddStudentResponse> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            var success = _studentsService.AddStudent(request.Student);
            return Task.FromResult(new AddStudentResponse { Success = success });
        }
    }
}