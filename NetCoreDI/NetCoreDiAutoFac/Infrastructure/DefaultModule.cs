using Autofac;
using NetCoreDiAutoFac.Repository;
using NetCoreDiAutoFac.Repository.Implement;
using NetCoreDiAutoFac.Service;
using NetCoreDiAutoFac.Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDiAutoFac.Infrastructure
{
    public class DefaultModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>();

            //default InstancePerDependency

            #region Property
            //Property Inject

            //builder.RegisterType<UserInfoRepositoryMySql>().As<IUserInfoRepository>();
            //builder.RegisterType<UserInfo2Service>().As<IUserInfoService>().PropertiesAutowired();

            #endregion


            //注册泛型仓储
            //builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
        }
    }
}
