# FlexibleMVC
框架基于asp.net mvc4，重写大量基类并引入优秀第三方组件，旨在打造功能强大、扩展灵活、简单易用的Web快速开发框架

## 亮点
1. 引入Autofac组件实现依赖注入、控制反转，实现模块解耦，实现插件机制
2. 在asp.net mvc Areas分离的最外层新增Module，这样模块划分维度更细，利于项目模块化开发、维护
3. 重写ActionResult，增强JsonResult，扩展FileResult：excel、pdf、xml
4. 定义FlexibleContext，整个请求生命周期都可访问的上下文对象，包括业务层、数据访问层、Controller、View、插件层
5. 自定义TempDataProvider，用HttpContext Cache或Memcached替代SessionStateTempDataProvider
6. JWT跨域认证封装
7. Json配置文件操作封装，实现dynamic类型轻松访问json配置
8. 轻量级组件FluentData代替EntityFramework访问数据库
9. log4net组件按年月、日期输出日志记录，灵活配置日志策略
10. 框架将日志、数据库、配置文件、其它附件定义到主程序目录外，在升级时只需要替换主程序、执行数据库升级脚本即可
11. 如果请求路由Controller不存在，则根据Controller、Action名称直接映射物理路径请求View cshtml文件
12 引用开源cassinidev（微型Web服务器，替代IIS），适合开发演示用，单机版布署
13 选择mvc4版本，依赖于.net framework 4.0，即便在XP系统上也能轻松布署运行

## 底层框架介绍
<html>
├ FlexibleMVC.Base <br/>
│  ├ AcResult &emsp;//重写ActionResult，增强JsonResult，扩展FileResult：excel、pdf、xml<br/>
│  │  ├ BaseExcelResult.cs <br/>
│  │  ├ BaseJsonResult.cs <br/>
│  │  ├ BasePartialViewResult.cs <br/>
│  │  ├ BasePdfResult.cs <br/>
│  │  ├ BaseViewResult.cs <br/>
│  │  ├ BaseXmlResult. <br/>
│  │  ├ ExecuteViewResult.cs <br/>
│  ├ BaseAreaRegistration.cs <br/>
│  ├ Const <br/>
│  │  ├ MvcConst.cs <br/>
│  ├Constraint &emsp;//实现IRouteConstraint接口，限定4种路由匹配规则，详见下文<br/>
│  │  ├ BaseAreaRouteConstraint.cs <br/>
│  │  ├ BaseModuleAreaRouteConstraint.cs <br/>
│  │  ├ BaseModuleRouteConstraint.cs <br/>
│  │  ├ BaseRouteConstraint.cs <br/>
│  ├ Context &emsp;//定义Context，整个请求生命周期都可访问，包括业务层、数据访问层、Controller、View、插件层<br/>
│  │  ├ FlexibleContext.cs <br/>
│  │  ├ FlexibleContextWebViewPage.cs <br/>
│  ├ Ctrller <br/>
│  │  ├ BaseController.cs &emsp;//重写Controller类<br/>
│  │  ├ FolderControllerFactory.cs &emsp;//如果路由不存在，则跳过Controller，直接映射物理路径请求View<br/>
│  ├ Filter <br/>
│  │  ├ AllowCrossSiteAttribute.cs &emsp;//重写FilterAttribute，实现跨域请求<br/>
│  ├ JsonConfig &emsp;//Json配置文件操作封装，实现dynamic类型轻松访问json配置 <br/>
│  │  ├ Config.cs <br/>
│  │  ├ ConfigObjects.cs <br/>
│  │  ├ JsonResultInfo.cs <br/>
│  │  ├ JsonUtil.cs <br/>
│  │  ├ Merger.cs <br/>
│  ├ Jwt &emsp;//跨域认证封装<br/>
│  │  ├ JwtUtil.cs <br/>
│  ├ MvcViewEngine.cs &emsp;//重写RazorViewEngine，修改View匹配规则<br/>
│  ├ packages.config <br/>
│  ├ Tools <br/>
│  │  ├ ExcelUtil.cs <br/>
│  │  ├ PropertyExpressionParser.cs <br/>
│  │  ├ ReflectionHelper.cs <br/>
</html>

## 路由规则

在asp.net mvc Areas分离的最外层新增Module，这样模块划分维度更细，利于项目模块化开发

项目结构 | 路由规则 | 备注
---|---|---
None | Controller/Action | 理解为一个mvc工程
Area | Area_Controller/Action | 理解为Areas分离的mvc工程
Module | Module_Controller/Action | 多个Module理解为多个mvc工程
ModuleAndArea | Module_Area_Controller/Action | 多个mvc工程并且Areas分离

结构示意图：

├ ModuleA <br/>
│  ├ AreaA<br/>
│  │  ├ Controller <br/>
│  │  ├ View <br/>
│  ├ AreaB<br/>
│  │  ├ Controller <br/>
│  │  ├ View <br/>
│  ├ Controller<br/>
│  ├ View<br/>
├ ModuleB <br/>
│  ├ AreaC<br/>
│  │  ├ Controller <br/>
│  │  ├ View <br/>
│  ├ AreaD<br/>
│  │  ├ Controller <br/>
│  │  ├ View <br/>
│  ├ Controller<br/>
│  ├ View<br/>
├ AreaE<br/>
│  ├ Controller <br/>
│  ├ View <br/>
├ AreaF<br/>
│  ├ Controller <br/>
│  ├ View <br/>
Controller<br/>
View<br/>

示例：<br/>
├ 系统前台项目<br/>
│  ├ 前台登录<br/>
│  │  ├ Controller <br/>
│  │  │  ├ Login        
│  │  ├ View <br/>
│  │  │  ├ Login.cshtml       
│  ├ ……<br/>
├ 系统后台管理<br/>
│  ├ 后台登录<br/>
│  │  ├ Controller <br/>
│  │  │  ├ SysLogin        
│  │  ├ View <br/>
│  │  │  ├ SysLogin.cshtml<br/>
├ ……<br/>

新增的Module放到主mvc工程的根目录下面，需要在代码中做如下映射，MVC的思想是“约定大于约束”，按照这个规则来，没错的
```
public static void RegisterViewMaps(SortedDictionary<string, string> ViewMaps)
{
    ViewMaps.Add("FlexibleMVC.Web", "~/");
    ViewMaps.Add("FlexibleMVC.Web.Admin", "~/FlexibleMVC.Web.Admin/");
    ViewMaps.Add("FlexibleMVC.Web.Frond", "~/FlexibleMVC.Web.Frond/");
}

```
## 插件机制
基于该框架做开发时，对于个性化的功能，没必要在框架主项目内实现，需要做的是：
- 从个性化的功能中抽象出接口，定义接口放到主项目内
- 打开FlexibleMVC\FlexibleMVC.Plugin\Plugin目录下的解决方案，新增类库项目
- 在项目中实现上面定义的接口
- 可在实现类中声明FlexibleContext属性，或业务层、数据库访问层的对象并且不用手动实例化就可使用，因为Autofac已经帮你做好了一切
- 并将生成路径修改至FlexibleMVC\FlexibleMVC\bin\plugins目录
- 生成dll

这样就完成了个性化功能开发，并且不会影响到主项目。至于解析插件，交给Autofac组件，会在应用启动的时候，从plugins目录下搜索插件dll，并将类型注入到主项目的接口中，这样在主项目中就能调用插件实现的功能


```
public class Multiple : IOperation
{			
	//属性会被注入
	public LessFlexibleContext flexibleContext { get; set; }
	//不带属性访问器的字段不会被注入
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
```
