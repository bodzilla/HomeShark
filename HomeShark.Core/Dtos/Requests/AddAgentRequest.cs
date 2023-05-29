using HomeShark.Core.Contracts.Dtos;

namespace HomeShark.Core.Dtos.Requests
{
    public sealed record AddAgentRequest(string Name, string Website, string Logo) : IRequest;
}
