using TrackingCompanies.Api.Models;
using TrackingCompanies.Api.Models.Dto;
using TrackingCompanies.Application.Commands;
using TrackingCompanies.Application.Dispatcher;

namespace TrackingCompanies.Api.Endpoints;

public static class CompaniesEndpoints
{
    public static void MapCompaniesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/companies")
            .WithTags("Companies");

        group.MapPost("/", AddCompany)
            .WithName("AddCompany")
            .WithOpenApi(openApi => new(openApi)
            {
                Summary = "AddCompany",
                Description = "AddCompany"
            })
            .Produces<BaseResponse<CreateCompanyResponse>>(StatusCodes.Status201Created)
            .Produces<BaseResponse<ValidationError>>(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
    
    private static async Task<IResult> AddCompany(CreateCompanyRequest request,
        IDispatcher dispatcher,
        CancellationToken cancellationToken)
    {
        var command = new CreateCompanyCommand(request.Name,request.Ticker, request.IndustrySectorId);

        try
        {
            var companyId = await dispatcher.Send<CreateCompanyCommand, Guid>(command, cancellationToken);
            return Results.CreatedAtRoute("GetCompany", new { id = companyId }, new { id = companyId });
        }
        catch (InvalidOperationException ex)
        {
            return Results.Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}