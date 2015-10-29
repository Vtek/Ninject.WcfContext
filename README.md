Ninject.WebContext
=======

Smart IoC library for your WCF application.


## Installation

```
PM> Install-Package Ninject.WcfContext -Pre
```


## Getting started

This library is a complet implementation of IoC with Ninject for WCF. It ease you the implementation in your WCF web service project.
First you need to create an automatic injection module to define your bindings :

```csharp
public class MyModule : AutoInjectionModule
{
	public override void Load()
	{
		Bind<IMyInterface>().To<IMyImplementation>();
	}
}
```

In Ninject, bindings are in transient scope by default. The library allow you to set the Http request as scope :

```csharp
Bind<IMyInterface>().To<IMyImplementation>().InHttpScope();
```

When your modules are ready, you have done 95% of the work ! Start the NinjectContext in your Global.asax application start method with one line :

```csharp
NinjectContext
  .Get()
  .AddModule<MyModule>()
  .UseWcf()
  .WithAutoInjection()
  .Initialize();
```

Now define contract & implementation for your .svc :

```csharp
[ServiceContract]
public interface IMyContract
{
    [OperationContract]
    MyModel GetMyModel();
}
```

```csharp
public class MyContract : IMyContract
{
  public IMyInterace MyInterface { get; set; }
  
  public MyModel GetMyModel()
  {
      return MyInterface.GetMyModel();
  }
}
```

Add Ninject.WcfContext service factory in your .svc :

```xml
<%@ ServiceHost Language="C#" Service="MyContract" Factory="Ninject.WcfContext.NinjectServiceHostFactory" %>
```


## About AutoInjection

AutoInjection is an out of the box feature in the library but you must activate it with WithAutoInjection method. If you want to use a classic IoC implementation, don't call this method and define constructor with dependecies in parameter :

```csharp
public class MyContract : IMyContract
{
	IMyInterace MyInterface { get; set; }
	
	public MyContract(IMyInterace myInterface)
	{
		MyInterface = myInterface;
	}
	
  public MyModel GetMyModel()
  {
      return MyInterface.GetMyModel();
  }
}
```

If you do that, you can use standard NinjectModule to define your Bind but without the use of AutoInjection, Filter can't be inject (You can inject dependencies into a constructor of an attribute).


## Sample

You can find a complete sample [here](https://github.com/Vtek/Ninject.CoreContext.Samples/tree/master/src/WcfContextSample).


## Licence

The MIT License (MIT)

Copyright (c) 2015 Sylvain PONTOREAU (pontoreau.sylvain@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
