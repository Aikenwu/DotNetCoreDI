using NetCoreDiAutoFac.Model;
using NetCoreDiAutoFac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDiAutoFac.Service.Implement
{
    public class UserInfo2Service: IUserInfoService
    {
        public IUserInfoRepository userInfoRepository { get; set; }

        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            return await this.userInfoRepository.GetUserInfoAsync(id);
        }
    }
}
