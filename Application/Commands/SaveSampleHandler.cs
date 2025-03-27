using Application.DTO.Response;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands;

public class SaveSampleHandler(ISampleService sampleService) : IRequestHandler<SaveSampleCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(SaveSampleCommand request, CancellationToken cancellationToken) => await sampleService.SaveSampleAsync(request);
}
