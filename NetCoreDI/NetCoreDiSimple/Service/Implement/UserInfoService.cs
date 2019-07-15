using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiSimple.Model;
using NetCoreDiSimple.Repository;
using NetCoreDiSimple.Repository.Implement;

namespace NetCoreDiSimple.Service.Implement
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository userInfoRepository;

        //public UserInfoService()
        //{
        //    this.userInfoRepository = new UserInfoRepository();
        //}

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
