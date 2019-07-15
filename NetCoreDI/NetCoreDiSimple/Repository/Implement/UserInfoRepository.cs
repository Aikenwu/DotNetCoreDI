using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreDiSimple.Model;

namespace NetCoreDiSimple.Repository.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public async Task<UserInfo> GetUserInfoAsync(long id)
        {
            //await Task.Yield();
            try
            {
                return await Task.Run(() =>
                  {
                      //throw new Exception();
                      return new UserInfo()
                      {
                          Id = 1,
                          Name = "Simple"
                      };
                  });

                //return Task.Factory.StartNew(() =>
                //{
                //    //throw new Exception();
                //    return new UserInfo()
                //    {
                //        Id =1,
                //        Name = "Simple"
                //    };
                //}).Result;

                //Task.Run(() =>
                //  {
                //    //throw new Exception();              
                //  });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
