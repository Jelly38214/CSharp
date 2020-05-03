Service, such as database context, must be registered in DI container

[HttpGet] 属性表示响应 HTTP GET 请求的方法。每个方法的 URL 路径构造如下所示：

- 在控制器的`Route`属性中以模版字符串开头
- 将`[controller]`替换为控制器的名称，按照惯例，在控制器类名称中去掉`Controller`后缀。例如，`TodoController` => `todo`, ASP.NET Core 路由不区分大小写。
- 如果`[HttpGet]`属性具有路由模版，例如，`[HttpGet("products")]`，则将它追到路径。此示例，控制器类名称为`Todo`控制器
- 删除`Properties/launchSettings.json中的launchUrl`以便在项目的默认文件 index.html 强制打开应用
