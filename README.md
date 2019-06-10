# Core.Flash2 [![NuGet](https://img.shields.io/nuget/v/Core.Flash2.svg)](https://www.nuget.org/packages/Core.Flash2/)

Minimalistic flash message system for ASP.NET MVC Core to provide contextual feedback messages between actions. Forked from lurumad/core-flash and
converted to run on netcoreapp2.2

### Install Core.Flash2

You should install [Core.Flash2](https://www.nuget.org/packages/Core.Flash2/):

    Install-Package Core.Flash2

This command from Package Manager Console will download and install Core.Flash2 and all required dependencies.

### Meet Core.Flash2

Register **Core.Flash2** services in your **Startup** class

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services
      .AddFlashes()
      .AddMvc();
}
```
Once you have been register **Core.Flash2** services, you can inject the **IFlasher** interface in your Controllers:

```csharp
public HomeController(IFlasher f)
{
    this.f = f;
}
```
And call **Flash** method passing a type and the message:

```csharp
public IActionResult YourAction()
{
    f.Flash("success", "Flash message system for ASP.NET MVC Core");

    return RedirectToAction("AnotherAction");
}
```
Add **Core.Flash2 TagHelper** to your **_ViewImports.cs**

```csharp
@using Core.Flash2.Web
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, Core.Flash2
```
Add the TagHelper to your **_Layout.cs**

```html
<div class="container body-content">
    <div flashes></div>
    @RenderBody()
    <hr />
    <footer>
        <p>&copy; 2017</p>
    </footer>
</div>
```

**Core.Flash2** uses [Bootstrap Alerts](https://v4-alpha.getbootstrap.com/components/alerts/).

![Sample](https://github.com/lurumad/core-flash/blob/master/assets/flash.gif)

_Copyright &copy; 2017 Lurumad Contributors

