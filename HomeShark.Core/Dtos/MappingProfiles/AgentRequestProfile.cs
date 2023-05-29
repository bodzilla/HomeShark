using AutoMapper;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;

namespace HomeShark.Core.Dtos.MappingProfiles
{
    public sealed class AgentRequestProfile : Profile
    {
        public AgentRequestProfile() => CreateMap<AgentRequest, Agent>();
    }
}
