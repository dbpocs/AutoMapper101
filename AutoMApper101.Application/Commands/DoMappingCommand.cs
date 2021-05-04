using MediatR;

namespace AutoMApper101.Application.Commands
{
    public class DoMappingCommand : IRequest<SampleDTOOut>
    {
        public SampleDTOIn SampleDTOIn { get; set; }
    }
}