using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.Services;

public interface ISampleService
{
    Task<ApiResponse<IEnumerable<SampleResponse>>> GetSampleAsync();
    Task<ApiResponse<SampleResponse>> GetSampleByIdAsync(int id);
    Task<ApiResponse> SaveSampleAsync(SampleRequest request);
}
