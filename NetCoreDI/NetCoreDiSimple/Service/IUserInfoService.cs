using NetCoreDiSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDiSimple.Service
{
    public interface IUserInfoService
    {
        Task<UserInfo> GetUserInfoAsync(long id);
    }
}
