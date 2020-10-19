Service, such as database context, must be registered in DI container

[HttpGet] 属性表示响应 HTTP GET 请求的方法。每个方法的 URL 路径构造如下所示：

- 在控制器的`Route`属性中以模版字符串开头
- 将`[controller]`替换为控制器的名称，按照惯例，在控制器类名称中去掉`Controller`后缀。例如，`TodoController` => `todo`, ASP.NET Core 路由不区分大小写。
- 如果`[HttpGet]`属性具有路由模版，例如，`[HttpGet("products")]`，则将它追到路径。此示例，控制器类名称为`Todo`控制器
- 删除`Properties/launchSettings.json中的launchUrl`以便在项目的默认文件 index.html 强制打开应用

appsetting.json: 项目的 runtime 设置

Program.cs & Startup.cs: 主管程序入口以及系统的生命周期
Startup.cs: 依赖注入，中间件，请求通道

Startup 类： Asp .net core 的配置信息， 如注入依赖，配置中间件，处理请求通道, 都会使用 Startup 类来进行管理

Startup 类：

- ConfigureServices: 管理各种服务组件的依赖, 将 services(自定义的 service，.net core 自带的 service)注入到 IOC 容器中
- Configure: 配置中间件(middleware)，配置请求通道(request pipeline)

请求通过都是通过`IApplicationBuilder`来创建的, 每个中间件都可以截获，修改，传递请求对象，输出，响应对象。
某些中间件可以做短路处理，直接向前端输出响应对象
每个中间件截获的请求对象都来自于上一个中间件所输出的响应对象，所以在管道设计上是需要有一点的顺序要求的

环境变量：

- 设置：Properties/launchSettings.json => environmentVariables -> ASPNETCORE_ENVIRONMENT(Development/Production)

路由：

- 分段路由 Segments(自定义路由: www.LanzhouBeefNoodles.com/Noddle/Detail/1)
  - {域名}/{Controller}/{Action}/{id} => id 作为 Action 的入参来参与页面处理获得数据输出
  - Asp.Net Core MVC 是如何定义/知道 URL 和 Controller 之间的映射规则的呢
  - Asp.Net MVC 默认的路由系统： app.UseMvcWithDefaultRoute(); // 其默认映射路由：{域名}/{Controller=Home}/{Action=Index}/{Value?}
- 自定义默认路由
  - 使用中间件`app.UseMvc(routes => {})`代替`app.UseMvcWithDefaultRoute()`;
    ```typescript
      // app.UseMvcWithDefaultRoute();
      app.UseMvc(routes => {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"
        )
      });
    ```
- 路由映射模式
  - 传统路由(使用路由表) Conventional Routing
    - URL 被分段解析为 controller 和 action 两个部分, 例如{域名}/{controller}/{action}
    - 使用路由表(routing table)来设置路由规则, routes.MapRoute(name: "default", template:"{controller=Home}/{action=Index}")
  - 特性注释路由 Attribute Routing(AOP 方式)
    - 不需要路由表，只需要在 controller 和 action 代码中直接使用 attribute 来定义路由

控制器：

- 三种方式使得一个类符合控制器的定义
  1. 直接在类的名称后面加`Controller`
  2. 使用 attribute 注释方式，在类名上方加`[Controller]`
  3. 继承 Controller 基类，在类名后加`: Controller`。相比较 2 的方式，此方式能给 Action 函数里的 this 添加很多辅助方法

模型：

- 定义：模型就是一个类，这个类中包含各种各样的属性
  - 属性映射数据库， 对象化数据
  - 模型主要用于获取数据，更新数据，传递数据， 保存数据
  - 处理业务逻辑， 视为 Business Layer 业务层
  - View Model 与视图数据绑定

模型的业务操作：就是在模型中定义的各种函数
业务函数不会映射数据库，但是会对数据作出更新

从数据库中获取数据的方式

- JDBC
- Ado.Next
- ORM
- repository 仓库模式(数据持久化设计)

使用模型和数据仓库的好处

- 业务逻辑与数据模型紧密耦合，减少分层，降低代码数量
- 完全剥离数据库业务，专注于实现业务逻辑
- 面向对象编程，数据转化为对象，符合程序员的思考方式

注入自己的 service 到 IOC 容器

- AddTransient(创建一个新的实例，对于每个请求， 请求结束后，销毁实例),
- AddSingleton(程序启动时创建的一个单例)
- AddScoped(引入 transaction 的概念)

控制器与 Model 之间的绑定方式: 通过控制器的构造函数注入模型

视图模型(View Model): 针对一个视图需要多个模型，提供一种灵活的方式解决这个痛点
ViewModel中的数据与UI界面双向绑定，一旦ViewModel中的数据变化，结果都会立即反应到UI界面中
ViewModel依旧是Model，以数据为导向，只是其数据不是业务数据，而是通过映射业务数据形成的页面数据，并仅用于展示UI
ViewModel组合一个或多个Model，形成UI需要的数据，同时UI产生的新数据，通过处理后再返回到Model，从而更新Model

如何使用视图模型
  - 在控制器中获取相应的数据，然后把数据装载进入到viewmodel中

## Issuses

1. 'HttpResponse' does not contain a definition for 'WriteAsync' and no accessible extension method 'WriteAsync' accepting a first argument of type 'HttpResponse' could be found (are you missing a using directive or an assembly reference?)
   https://stackoverflow.com/questions/36598741/in-mvc6-where-is-writeasync-function
   引入 namespace: using Microsoft.AspNetCore.Http;

2. Feature 'using declarations' is not available in C# 7.3. Please use language version 8.0 or greater.
   https://stackoverflow.com/questions/58624146/feature-using-declarations-is-not-available-in-c-sharp-7-3-please-use-languag
