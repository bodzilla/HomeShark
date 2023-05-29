using AutoMapper;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;

namespace HomeShark.Core.Dtos.MappingProfiles
{
    public sealed class UpdateAgentRequestProfile : Profile
    {
        public UpdateAgentRequestProfile() => CreateMap<UpdateAgentRequest, Agent>();
    }
}
