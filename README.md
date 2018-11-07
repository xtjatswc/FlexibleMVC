# FlexibleMVC
框架基于asp.net mvc4，重写大量基类并引入优秀第三方组件，旨在打造功能强大、扩展灵活、简单易用的Web快速开发框架


<html>
├ FlexibleMVC.Base <br/>
│  ├ AcResult <font color='red'>&emsp;重写ActionResult，增强JsonResult，扩展FileResult：excel、pdf、xml</font><br/>
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
│  ├Constraint <font color='red'>&emsp;实现IRouteConstraint接口，限定4种路由匹配规则，详见下文</font><br/>
│  │  ├ BaseAreaRouteConstraint.cs <br/>
│  │  ├ BaseModuleAreaRouteConstraint.cs <br/>
│  │  ├ BaseModuleRouteConstraint.cs <br/>
│  │  ├ BaseRouteConstraint.cs <br/>
│  ├ Context <br/>
│  │  ├ FlexibleContext.cs <br/>
│  │  ├ FlexibleContextWebViewPage.cs <br/>
│  ├ Ctrller <br/>
│  │  ├ BaseController.cs <br/>
│  │  ├ FolderControllerFactory.cs <br/>
│  ├ Filter <br/>
│  │  ├ AllowCrossSiteAttribute.cs <br/>
│  ├ JsonConfig <br/>
│  │  ├ Config.cs <br/>
│  │  ├ ConfigObjects.cs <br/>
│  │  ├ JsonResultInfo.cs <br/>
│  │  ├ JsonUtil.cs <br/>
│  │  ├ Merger.cs <br/>
│  ├ Jwt <br/>
│  │  ├ JwtUtil.cs <br/>
│  ├ MvcViewEngine.cs <br/>
│  ├ packages.config <br/>
│  ├ Tools <br/>
│  │  ├ ExcelUtil.cs <br/>
│  │  ├ PropertyExpressionParser.cs <br/>
│  │  ├ ReflectionHelper.cs <br/>
</html>

