using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiSimple.Model;

namespace NetCoreDiSimple.Repository.Implement
{
    public class UserInfoRepositorySqlServer : IUserInfoRepository
    {
        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            return await Task.Run(() =>
            {
                return new UserInfo()
                {
                    Id = 1,
                    Name = "SqlServer"
                };
            });
        }
    }
}
