using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiAutoFac.Model;

namespace NetCoreDiAutoFac.Repository.Implement
{
    public class UserInfoRepositoryMySql : IUserInfoRepository
    {
        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            return await Task.Run(() =>
              {
                  return new UserInfo()
                  {
                      Id = 1,
                      Name = "MySql"
                  };
              });
        }
    }
}
