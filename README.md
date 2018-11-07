# FlexibleMVC
框架基于asp.net mvc4，重写大量基类并引入优秀第三方组件，旨在打造功能强大、扩展灵活、简单易用的Web快速开发框架

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
