using System;
using System.Net;

namespace Application.Exceptions.Sample;

public class SampleNotFoundException(int id) : BaseException($"No se encontró un Sample con el id {id}", HttpStatusCode.NotFound)
{
}
