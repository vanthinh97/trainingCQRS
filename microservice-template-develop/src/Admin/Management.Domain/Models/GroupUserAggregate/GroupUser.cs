using Microservices.Core.Domain.SeedWork;

namespace Management.Domain.Models.GroupUserAggregate
{
    public class GroupUser : EntityBase
    {
        public int GroupId { get; set; }

        public int UserId { get; set; }
    }
}
