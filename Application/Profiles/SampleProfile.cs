using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class SampleProfile : Profile
{
    public SampleProfile()
    {
        CreateMap<Sample, SampleResponse>();
        CreateMap<SampleRequest, Sample>();
    }
}
