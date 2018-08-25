/*
 * 用户： 张晓松
 * 日期: 2018/8/25
 * 时间: 17:00
 */
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using FlexibleMVC.IServer;
using FlexibleMVC.LessBase.Context;

namespace FlexibleMVC.Demo.Plugin
{
	/// <summary>
	/// Description of TestService2.
	/// </summary>
	public class TestService2 : ITestService
	{
		public LessFlexibleContext flexibleContext { get; set; }
		
		public List<IOperation> operation = DependencyResolver.Current.GetServices<IOperation>().ToList();

		public string GetData()
		{
			return "这是TestService2返回的消息";
		}
	}
}
