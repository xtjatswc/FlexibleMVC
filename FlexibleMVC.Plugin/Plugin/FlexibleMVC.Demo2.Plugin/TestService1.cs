/*
 * 用户： 张晓松
 * 日期: 2018/8/25
 * 时间: 17:02
 */
using System;
using System.Data;
using FlexibleMVC.IServer;
using FlexibleMVC.LessBase.Context;
using FlexibleMVC.DAL;
using FlexibleMVC.Base.JsonConfig;

namespace FlexibleMVC.Demo.Plugin
{
	/// <summary>
	/// Description of TestService1.
	/// </summary>
	public class TestService1 : ITestService
	{				
		public string GetData()
		{
			return "这是TestService1返回的消息";
		}
	}
}
