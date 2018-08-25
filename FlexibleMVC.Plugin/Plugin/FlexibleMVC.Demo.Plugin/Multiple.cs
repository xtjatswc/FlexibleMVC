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
	/// Description of Multiple.
	/// </summary>
	public class Multiple : IOperation
	{			
		//属性会被注入
		public LessFlexibleContext flexibleContext { get; set; }
		//字段不会被注入
		public LessFlexibleContext flexibleContext2;
		public FoodDal foodDal { get; set; }
		
		public int Operate(int left, int right)
		{
			flexibleContext.log.Error("abc");
			DataTable patientbasicinfo = flexibleContext.db.Sql(@"select * from patientbasicinfo limit 30 ").QuerySingle<DataTable>();
			
			var foods = foodDal.GetModels();
			
            var jsonSettings = Config.Global.LessBase.JsonSettings;
            var a = jsonSettings.DateFormatString;
			return left * right;
		}
	}
}
