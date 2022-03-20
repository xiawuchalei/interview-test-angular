using interview_test_angular.Models.Students;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace interview_test_angular.Mediatr.Students
{
    public class GetStudentsRequest : IRequest<GetStudentsResponse>
    {
    }

    public class GetStudentsResponse
    {
        public List<Student> Students { get; set; }

        public GetStudentsResponse()
        {
            Students = new List<Student>();
        }
    }

    public class GetStudentsHandler : IRequestHandler<GetStudentsRequest, GetStudentsResponse>
    {
        public Task<GetStudentsResponse> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
