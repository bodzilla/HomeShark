using AutoMapper;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;

namespace HomeShark.Core.Dtos.MappingProfiles
{
    public sealed class AddAgentRequestProfile : Profile
    {
        public AddAgentRequestProfile() => CreateMap<AddAgentRequest, Agent>();
    }
}
