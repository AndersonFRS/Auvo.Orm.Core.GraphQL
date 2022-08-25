using GraphQL.Types;
using System.Xml.Linq;

namespace Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore
{
    public class TechEventInputType : InputObjectGraphType
    {
        public TechEventInputType()
        {
            Name = "AddEventInput";
            Field<NonNullGraphType<StringGraphType>>("eventName");
            Field<StringGraphType>("speaker");
            Field<NonNullGraphType<DateGraphType>>("eventDate");
        }
    }
}
