using StudentApi.Models.Students;
using StudentApi.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class GetStudentsRequest : IRequest<GetStudentsResponse>
    {
    }

    public class GetStudentsResponse
    {
        public List<Student> Students { get; set; }
    }

    public class GetStudentsHandler : IRequestHandler<GetStudentsRequest, GetStudentsResponse>
    {
        private IStudentsService _studentsService;

        public GetStudentsHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<GetStudentsResponse> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
        {
            // Gets all of the students
            var response = new GetStudentsResponse
            {
                Students = _studentsService.GetAllStudents()
            };

            return Task.FromResult(response);
        }
    }
}
