# FlexibleMVC
框架基于asp.net mvc4，重写大量基类并引入优秀第三方组件，旨在打造功能强大、扩展灵活、简单易用的Web快速开发框架

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
│  ├ MvcViewEngine.cs &emsp;//重写RazorViewEngine，修改View配置规则<br/>
│  ├ packages.config <br/>
│  ├ Tools <br/>
│  │  ├ ExcelUtil.cs <br/>
│  │  ├ PropertyExpressionParser.cs <br/>
│  │  ├ ReflectionHelper.cs <br/>
</html>

