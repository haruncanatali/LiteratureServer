using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.CommonValues.Queries.Dtos;
using LiteratureServer.Domain.Enums;
using MediatR;

namespace LiteratureServer.Application.CommonValues.Queries.GetGenders
{
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, BaseResponseModel<List<KeyValueModel>>>
    {
        private readonly IApplicationContext _context;

        public GetGendersQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<List<KeyValueModel>>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            List<KeyValueModel> model = new List<KeyValueModel>();

            foreach (var value in Enum.GetValues(typeof(Gender)))
            {
                model.Add(new KeyValueModel
                {
                    Key = (long)value,
                    Value = value.ToString()
                });
            }

            return BaseResponseModel<List<KeyValueModel>>.Success(model, "Cinsiyetler başarıyla getirildi.");
        }
    }
}
