using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore
{
    public class TechEventSchema : Schema
    {
        public TechEventSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = resolver.GetRequiredService<TechEventQuery>();
            Mutation = resolver.GetRequiredService<TechEventMutation>();
        }
    }
}
