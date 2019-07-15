using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiAutoFac.Model;

namespace NetCoreDiAutoFac.Repository.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    return new UserInfo()
                    {
                        Id = 1,
                        Name = "Simple"
                    };
                });
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
