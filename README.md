# Simple Dependency Injection for Unity

Simple Dependency Injection is a lightweight C# system designed for managing dependencies within Unity projects. This system enables developers to bind types to specific instances and retrieve them as needed, facilitating a modular and decoupled architecture suitable for Unity game development.

## Features

- **Unity-Compatible:** Designed specifically for integration with Unity projects.
- **Type and Instance Binding:** Bind Unity objects or custom classes to types with optional aliases to manage multiple instances of the same type.
- **Easy Retrieval:** Efficiently retrieve instances based on type and alias.
- **Dynamic Binding Management:** Add or remove bindings at runtime to adapt to game dynamics.

## Getting Started

### Installation

To integrate Simple Dependency Injection into your Unity project, follow these steps:

1. **Download the Scripts:** Download the C# files.
2. **Add to Unity:** Import the downloaded scripts into your Unity project's `Assets` folder.

### Usage

#### Adding a Binding

To add a binding in your Unity project, you can do so by creating an instance of `Bind` and adding it through `DependencyInjectionManager.AddBind`:

```csharp
var myComponent = GetComponent<MyComponent>();
var bind = new Bind(typeof(MyComponent), "myAlias", myComponent);
DependencyInjectionManager.AddBind(bind);
```

#### Retrieving an Instance

Retrieve an instance anywhere in your Unity scripts using the `Get<T>` method:

```csharp
var myComponentInstance = DependencyInjectionManager.Get<MyComponent>("myAlias");
```

#### Removing a Binding

To remove a binding, you can either use the type and alias:

```csharp
DependencyInjectionManager.RemoveBind(typeof(MyComponent), "myAlias");
```

Or by directly using the `Bind` instance:

```csharp
DependencyInjectionManager.RemoveBind(bind);
```

## Contributing

Contributions to improve or extend the functionality are welcome. Please feel free to fork the repository, make changes, and submit pull requests. You can also open issues for bugs, feature requests, or other discussions.

## License
This project is licensed under the MIT License
