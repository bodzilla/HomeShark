using HomeShark.Core.Contracts.Dtos;

namespace HomeShark.Core.Dtos.Requests
{
    public sealed record UpdateAgentRequest(int Id, string Name, string Website, string Logo) : IRequest;
}
