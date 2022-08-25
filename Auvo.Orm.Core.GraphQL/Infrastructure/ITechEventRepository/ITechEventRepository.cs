using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext;
using Auvo.Orm.Core.GraphQL.WebApi.models;

namespace Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.ITechEventRepository
{
    public interface ITechEventRepository
    {
        Task<TechEventInfo[]> GetTechEventsAsync();
        Task<TechEventInfo> GetTechEventByIdAsync(int id);
        Task<List<Participant>> GetParticipantInfoByEventIdAsync(int id);
        Task<TechEventInfo> AddTechEventAsync(NewTechEventRequest techEvent);
        Task<TechEventInfo> UpdateTechEventAsync(TechEventInfo techEvent);
        Task<bool> DeleteTechEventAsync(TechEventInfo techEvent);

    }
}
