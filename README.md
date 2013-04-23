Muntz
=====

Muntz makes it easy to generate mocks for your libraries for use in testing that can be used across multiple platforms. This approach avoids the need for runtime code generation, which is not allowed on iOS.

This is a work in progress, so the current functionality is somewhat limited. In its current form, you can use Muntz to generate mocks for any interface.

Getting Started
---------------

It's very simple to get started with Muntz:

1. In your test project, add in the `Muntz.include` file found in the `src` folder of this repository
2. Add a new T4 template to your test project named whatever you want, containing the following:
```
<#@ template language="C#" hostspecific="true" #>
<#@ include file="Muntz.include" #>
<#@ Output Extension="cs" #>
```

3. For each assembly you want to generate mocks for, add a line to this new template file:
```
<# MockAssembly(Host.ResolvePath("../Library/bin/Debug/Library.dll"));#>
```

By default, Muntz will generate mocks for any interface it finds in the assemblies you tell it about. You can override this behavior by providing a list of namespaces to include:

    <# MockAssembly(Host.ResolvePath("../Library/bin/Debug/Library.dll", "NamespaceOne", "NamespaceTwo"));#>

Using the Mocks
---------------

Let's say you had an interface defined as:

```
interface IService
{
    int Foo(string bar);
}
```

You could use the Muntz-generated mock as follows:

```
var mock = new MockService();
mock.FooBody = bar => 42;

int length = mock.Foo("baz");
```
