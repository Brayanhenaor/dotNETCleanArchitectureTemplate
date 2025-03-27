using Application.Commands;
using Application.DTO;
using Application.DTO.Response;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<SampleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<IEnumerable<SampleResponse>>> GetSampleAsync()
    {
        return await mediator.Send(new GetSampleQuery());
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse> PostSampleAsync(SaveSampleCommand request)
    {
        return await mediator.Send(request);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<SampleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<SampleResponse>> GetSampleByIdAsync(int id)
    {
        return await mediator.Send(new GetSampleByIdQuery { Id = id });
    }
}
