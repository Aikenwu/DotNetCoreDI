using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiAutoFac.Model;
using NetCoreDiAutoFac.Repository;
using NetCoreDiAutoFac.Repository.Implement;

namespace NetCoreDiAutoFac.Service.Implement
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository userInfoRepository;

        public UserInfoService(IUserInfoRepository _userInfoRepository)
        {
            this.userInfoRepository = _userInfoRepository;
        }

        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            return await this.userInfoRepository.GetUserInfoAsync(id);
        }
    }
}
