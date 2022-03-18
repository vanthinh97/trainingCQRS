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
                var sqlUserDetail = @"select FirstName, LastName, Email, BirthDay from Users WHERE id = @id;";

                var sqlGroupOfUser = @"select g.Id, g.Name from groups g
                                    join GroupUsers gu ON g.Id = gu.GroupId
                                    where gu.UserId = @id";

                using var multiple = await conn.QueryMultipleAsync(sqlUserDetail + sqlGroupOfUser, new
                {
                    id
                });
                var user = multiple.Read<UserDto>().FirstOrDefault();
                var lstGroup = multiple.Read<GroupDto>().ToList();


                return new UserDetailDto(user.FirstName, user.Email, lstGroup);
            });
       
        }

        public async Task<IEnumerable<UserDto>> GetListAsync(string keyword, int? pageNumber, int? pageSize)
        {
            var whereSql = !string.IsNullOrEmpty(keyword) ? $@" AND (FirstName + ' ' + LastName COLLATE Latin1_General_CI_AI LIKE @keyword
                            OR LastName + ' ' + FirstName COLLATE Latin1_General_CI_AI LIKE @keyword
                            )" : "";
            return await WithConnection(async conn =>
            {
                var sql = @$"select COUNT(Id) OVER () AS TotalRecord, FirstName, Email from Users
                      where IsDeleted = 0 {whereSql} ORDER BY Id DESC ";
                if (pageNumber != null && pageSize != null)
                {
                    sql += " OFFSET ((@pageNumber - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY;";
                }

                return await conn.QueryAsync<UserDto>(sql, new
                {
                    keyword = new DbString { Value = string.Concat("%", keyword, "%"), IsAnsi = false },
                    pageNumber,
                    pageSize
                });
            });
        }
    }
}
