using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreDiSimple.Model;
using NetCoreDiSimple.Service;

namespace NetCoreDiSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService userInfoService;

        public UserInfoController(IUserInfoService _userInfoService)
        {
            this.userInfoService = _userInfoService;
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserInfo> GetAsync(int id)
        {
            return await this.userInfoService.GetUserInfoAsync(id);
        }
    }
}
