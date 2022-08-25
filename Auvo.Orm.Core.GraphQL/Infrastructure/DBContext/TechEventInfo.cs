using System;
using System.Collections.Generic;

namespace Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext
{
    public partial class TechEventInfo
    {
        public TechEventInfo()
        {
            EventParticipants = new HashSet<EventParticipant>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime? EventDate { get; set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }
    }
}
