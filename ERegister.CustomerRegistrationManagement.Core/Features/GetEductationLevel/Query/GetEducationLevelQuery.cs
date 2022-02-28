using AutoMapper;
using AutoMapper.QueryableExtensions;
using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ERegister.CustomerRegistrationManagement.Core.Features.GetEductationLevel.Query
{
    public class GetEducationLevelQuery : IRequest<List<GetEducationLevelDtos>>
    {
    }

    public class GetEducationLevelQueryHandler : IRequestHandler<GetEducationLevelQuery, List<GetEducationLevelDtos>>
    {
        private readonly IERegisterDbContext _context;
        private readonly IMapper _mapper;

        public GetEducationLevelQueryHandler(IERegisterDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetEducationLevelDtos>> Handle(GetEducationLevelQuery request, CancellationToken cancellationToken)
        {
            return await _context.EducationLevels
                        .ProjectTo<GetEducationLevelDtos>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
        }
    }
}
