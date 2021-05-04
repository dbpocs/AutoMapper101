using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoMApper101.Application.Commands
{
    public class DoMappingCommandHandler : IRequestHandler<DoMappingCommand, SampleDTOOut>
    {
        public DoMappingCommandHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private readonly IMapper _mapper;

        public Task<SampleDTOOut> Handle(DoMappingCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<SampleDTOOut>(request));
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DoMappingCommand, SampleDTOOut>()
                .ForMember(d => d.Name, o => o.MapFrom(s => string.Concat(s.SampleDTOIn.FirstName, " ", s.SampleDTOIn.LastName)))
                .ForPath(d => d.YearOfBirth.Value, o => o.MapFrom(s => DateTime.Now.Year - s.SampleDTOIn.Age));
        }
    }
}