using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.ITechEventRepository;
using GraphQL;
using GraphQL.Types;
using System.Xml.Linq;

namespace Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore
{
    public class TechEventQuery : ObjectGraphType<object>
    {
        [Obsolete]
        public TechEventQuery(ITechEventRepository repository)
        {
            Name = "TechEventQuery";

            Field<TechEventInfoType>(
               "event",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
               resolve: context => repository.GetTechEventByIdAsync(context.GetArgument<int>("eventId"))
            );

            Field<ListGraphType<TechEventInfoType>>(
             "events",
             resolve: context => repository.GetTechEventsAsync()
          );
        }
    }
}
