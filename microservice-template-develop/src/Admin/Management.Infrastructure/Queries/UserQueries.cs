using Dapper;
using Management.Domain.Queries.GroupAggregate;
using Management.Domain.Queries.UserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Infrastructure.Queries
{
    public class UserQueries : QueryBase, IUserQueries
    {
        public UserQueries(Func<IDbConnection> connectionBuilder) : base(connectionBuilder)
        {
        }

        public async Task<UserDetailDto> GetDetailAsync(int id)
        {
            return await WithConnection(async conn =>
            {
                var sqlUserDetail = @"select FullName = FirstName + ' ' + LastName, Email, RoleId from Users WHERE id = @id;";

                var sqlGroupOfUser = @"select g.Id, g.Name from groups g
                                    join GroupUsers gu ON g.Id = gu.GroupId
                                    where gu.UserId = @id";

                using var multiple = await conn.QueryMultipleAsync(sqlUserDetail + sqlGroupOfUser, new
                {
                    id
                });
                var user = multiple.Read<UserDto>().FirstOrDefault();
                var lstGroup = multiple.Read<GroupDto>().ToList();


                return new UserDetailDto(user.FullName, user.Email, user.RoleId, lstGroup);
            });
       
        }

        public async Task<IEnumerable<UserDto>> GetListAsync(
            int? isActive,
            int? arrangeType, 
            string keyword, 
            List<int?> roleIds, 
            string fromDate, 
            string toDate, 
            int? pageNumber, 
            int? pageSize)
        {
            // query name
            var whereSql = !string.IsNullOrEmpty(keyword) ? $@" AND (FirstName + ' ' + LastName COLLATE Latin1_General_CI_AI LIKE @keyword
                            OR LastName + ' ' + FirstName COLLATE Latin1_General_CI_AI LIKE @keyword
                            )" : "";

            // query status user
            var whereStatusUser = isActive != null ? (isActive == (int)StatusUser.IsActive ? "IsDeleted = @isActive" : "IsDeleted = @isActive") : "";

            // order last name
            var orderLastNameSql = arrangeType != null ? (arrangeType == (int)ArrangeType.nameAz ? "LastName ASC," : "LastName DESC,") : "";

            // query role id
            var whereRoleId = "";
            var roleSearch = new List<int>();
            if (roleIds?.Count() > 0)
            {
                for (int i = 0; i < roleIds.Count(); i++)
                {
                    roleSearch.Add((int)roleIds[i]);
                }
                whereRoleId = $" AND RoleId IN @roleSearch";
            }

            // query created date
            var whereCreatedDate = "";
            if (fromDate == null && toDate == null)
            {
                whereCreatedDate = "";
            }
            else if (fromDate != null && toDate != null)
            {
                whereCreatedDate = " AND (CreatedDate >= @fromDate and CreatedDate <= @toDate)";
            }
            else if (fromDate == null && toDate != null)
            {
                whereCreatedDate = " AND CreatedDate <= @toDate";
            }
            else 
            {
                whereCreatedDate = " AND CreatedDate >= @fromDate";
            }
            
            // return data
            return await WithConnection(async conn =>
            {
                var addWhere = (whereStatusUser ?? whereSql ?? whereRoleId ?? whereCreatedDate).Length > 0 ? "where" : "";
                var sql = @$"select COUNT(Id) OVER () AS TotalRecord, FullName = FirstName + ' ' + LastName, Email, RoleId, CreatedDate, IsDeleted from Users
                      {addWhere} {whereStatusUser} {whereSql} {whereRoleId} {whereCreatedDate} ORDER BY {orderLastNameSql} Id DESC ";
                if (pageNumber != null && pageSize != null)
                {
                    sql += " OFFSET ((@pageNumber - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY;";
                }

                return await conn.QueryAsync<UserDto>(sql, new
                {
                    keyword = new DbString { Value = string.Concat("%", keyword, "%"), IsAnsi = false },
                    isActive = isActive,
                    roleSearch = roleSearch,
                    fromDate = fromDate,
                    toDate = toDate,
                    pageNumber,
                    pageSize
                });
            });
        }
    }
}
