using Microservices.Core.Domain.SeedWork;

namespace Management.Domain.Models.GroupUserAggregate
{
    public class GroupUser : EntityBase
    {
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="GroupUser"/>
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        public GroupUser(int groupId, int userId)
        {
            GroupId = groupId;
            UserId = userId;
        }

        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
