namespace Auvo.Orm.Core.GraphQL.WebApi.models
{
    public class NewTechEventRequest
    {
        public string EventName { get; set; }
        public string Speaker { get; set; }
        public DateTime EventDate { get; set; }
    }
}
