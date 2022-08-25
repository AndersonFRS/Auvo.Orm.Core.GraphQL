

using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext;
using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.ITechEventRepository;
using GraphQL.Types;

namespace Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore
{
    public class TechEventInfoType : ObjectGraphType<TechEventInfo>
    {
        [Obsolete]
        public TechEventInfoType(ITechEventRepository repository)
        {
            Field(x => x.EventId).Description("Event id.");
            Field(x => x.EventName).Description("Event name.");
            Field(x => x.Speaker).Description("Speaker name.");
            Field(x => x.EventDate).Description("Event date.");

            Field<ListGraphType<ParticipantType>>(
              "participants",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
              resolve: context => repository.GetParticipantInfoByEventIdAsync(context.Source.EventId)
           );
        }
    }
}
