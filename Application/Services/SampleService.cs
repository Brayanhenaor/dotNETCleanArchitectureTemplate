using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions.Sample;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class SampleService(
    IUnitOfWork unitOfWork,
    IMapper mapper
) : ISampleService
{
    public async Task<ApiResponse<IEnumerable<SampleResponse>>> GetSampleAsync()
    {
        var samples = await unitOfWork.SampleRepository.GetAllAsync();
        return new ApiResponse<IEnumerable<SampleResponse>>
        {
            Success = true,
            Message = "Samples retrieved successfully",
            Result = mapper.Map<IEnumerable<SampleResponse>>(samples)
        };
    }

    public async Task<ApiResponse<SampleResponse>> GetSampleByIdAsync(int id)
    {
        var sample = await unitOfWork.SampleRepository.GetByIdAsync(id);

        if (sample == null)
            throw new SampleNotFoundException(id);

        return new ApiResponse<SampleResponse>
        {
            Success = true,
            Message = "Sample retrieved successfully",
            Result = mapper.Map<SampleResponse>(sample)
        };
    }

    public async Task<ApiResponse> SaveSampleAsync(SampleRequest request)
    {
        var sample = mapper.Map<Sample>(request);
        await unitOfWork.SampleRepository.AddAsync(sample);
        await unitOfWork.SaveChangesAsync();
        return new ApiResponse
        {
            Success = true,
            Message = "Sample saved successfully"
        };
    }
}
