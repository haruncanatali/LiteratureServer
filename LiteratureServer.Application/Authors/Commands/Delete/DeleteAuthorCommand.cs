using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Authors.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest<BaseResponseModel<Unit>>
    {
        public long AuthorId { get; set; }

        public class Handler : IRequestHandler<DeleteAuthorCommand, BaseResponseModel<Unit>>
        {
            private readonly IApplicationContext _context;

            public Handler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }

            public async Task<BaseResponseModel<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
            {
                
            }
        }
    }
}
