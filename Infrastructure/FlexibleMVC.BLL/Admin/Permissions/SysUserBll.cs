using FlexibleMVC.Base.Jwt;
using FlexibleMVC.DAL.Admin.Permissions;
using FlexibleMVC.LessBase.Infrastructure;
using FlexibleMVC.Model.Admin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.BLL.Admin.Permissions
{
    public class SysUserBll : BaseBLL
    {
        public SysUserDal sysUserDal { get; set; }

        public LoginResult CheckLogin(string loginName, string password)
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

            SysUser sysUser = sysUserDal.GetUserByLoginName(loginName);
            if(sysUser == null)
            {
                loginResult.Msg = $"登录名{loginName}不存在！";
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

            var dict = new Dictionary<string, object>();
            dict["user"] = new { loginName = loginName };
            string jwt = JwtUtil.Encode(dict, 24 * 60 * 60);
            loginResult.Success = true;
            loginResult.Msg = "登录成功！";
            loginResult.Token = jwt;

            //更新最近登录时间和登录次数
            sysUser.LoginCount += 1;
            sysUser.LastLoginTime = DateTime.Now;
            sysUserDal.Update(sysUser);

            return loginResult;
        }
    }
}
