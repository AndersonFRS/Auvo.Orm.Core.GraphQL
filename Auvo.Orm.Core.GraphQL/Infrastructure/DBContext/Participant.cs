using System;
using System.Collections.Generic;

namespace Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext
{
    public partial class Participant
    {
        public Participant()
        {
            EventParticipants = new HashSet<EventParticipant>();
        }

        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }
    }
}
