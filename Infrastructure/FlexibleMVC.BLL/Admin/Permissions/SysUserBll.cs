﻿using FlexibleMVC.Base.Jwt;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Const;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.LessBase.Ctrller;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.LessBase.Permissions.DAL;
using FlexibleMVC.LessBase.Permissions.Model;
using System;
using System.Collections.Generic;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysUserBll : BaseBLL, IUser
    {
        public SysUserDal sysUserDal { get; set; }

        public LoginResult CheckLogin(string webSiteID,string loginName, string password)
        {
            LoginResult loginResult = new LoginResult { Success = false };

            if (string.IsNullOrWhiteSpace(loginName))
            {
                loginResult.Msg = "登录名不能为空！";
                return loginResult;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                loginResult.Msg = "密码不能为空！";
                return loginResult;
            }

            SysUser sysUser = sysUserDal.GetUser(loginName);
            if(sysUser == null)
            {
                loginResult.Msg = $"登录名{loginName}不存在！";
                return loginResult;
            }

            if (sysUser.IsDeleted == 1)
            {
                loginResult.Msg = $"登录名{loginName}已被删除！";
                return loginResult;
            }

            if (sysUser.IsLocked == 1)
            {
                loginResult.Msg = $"登录名{loginName}状态为锁定！";
                return loginResult;
            }

            if (sysUser.Password != password)
            {
                loginResult.Msg = "密码错误！";
                return loginResult;
            }

            //
            SysWebSiteDal sysWebSiteDal = lessContext.GetService<SysWebSiteDal>();
            SysWebSite sysWebSite = sysWebSiteDal.GetModel(new SysWebSite{ID = webSiteID});
            if (sysWebSite == null)
            {
                loginResult.Msg = $"站点{webSiteID}不存在！";
                return loginResult;
            }

            if (sysWebSite.IsDeleted == 1)
            {
                loginResult.Msg = $"站点{webSiteID}已被删除！";
                return loginResult;
            }

            var dict = new Dictionary<string, object>();
            dict[BasicConst.JWT_USER] = new {loginName = loginName };
            string jwt = JwtUtil.Encode(dict, 24 * 60 * 60);
            loginResult.Success = true;
            loginResult.Msg = "登录成功！";
            loginResult.token = jwt;
            loginResult.sysWebSite = sysWebSite;

            //更新最近登录时间和登录次数
            sysUser.LoginCount += 1;
            sysUser.LastLoginTime = DateTime.Now;
            sysUserDal.Update(sysUser, o => sysUser.ID);

            return loginResult;
        }

        /// <summary>
        /// 得到当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public SysUser GetCurrentUser()
        {
            SysUserDal sysUserDal = lessContext.GetService<SysUserDal>();
            string loginName = lessContext.Jwt.Result[BasicConst.JWT_USER].loginName.ToString();
            SysUser sysUser = sysUserDal.GetUser(loginName);
            return sysUser;
        }

        public dynamic GetCurrentUser(LessFlexibleContext flexibleContext)
        {
            lessContext = flexibleContext;
            return GetCurrentUser();
        }
    }
}
