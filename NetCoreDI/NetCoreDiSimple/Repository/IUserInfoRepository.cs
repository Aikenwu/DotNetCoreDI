using NetCoreDiSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDiSimple.Repository
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoAsync(long id);
    }
}
