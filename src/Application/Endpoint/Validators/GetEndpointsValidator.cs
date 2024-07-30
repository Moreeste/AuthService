using Application.Endpoint.Queries;
using FluentValidation;

namespace Application.Endpoint.Validators
{
    public class GetEndpointsValidator : AbstractValidator<GetEndpointsQuery>
    {
        public GetEndpointsValidator()
        {
            
        }
    }
}
