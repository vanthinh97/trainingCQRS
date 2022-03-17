using Dapper;
using Management.Domain.Queries.UserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
                var sql = @"select FirstName, LastName, Email, BirthDay from Users WHERE id = @id";

                return await conn.QueryFirstOrDefaultAsync<UserDetailDto>(sql, new
                {
                    id
                });
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
