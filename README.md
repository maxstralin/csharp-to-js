# C# to JS
> Used for converting C# models and DTOs to javascript classes

A global .NET Core tool to easily convert C# models and classes into Javascript classes

**C# Input**
![](./docs/cs-input.png)
**JS output**
![](./docs/js-output.png)

## Installation
**Install the tool**
```sh
dotnet tool install --global CSharpToJs
```
**Update .csproj**

Update your project to output all its dependencies by adding `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>` to your `.csproj` file for the project you're running the tool for. This is so the CSharpToJs tool can resolve any dependencies used, e.g. Nuget packages.
```
<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

**Create a configuration file**

Add a `csharptojs.config.json`. I'd recommend the project's root folder but you can place it wherever you want. By default, the tool will look in the folder in which you're executing the tool in but also accepts a path (excl. filename) to the config file. Note that any relative paths in the config will be relative to where the tool is being executed, not where the config file is.

See [Usage](#configuration-file) for details.


## Usage

**Simple**

Simply execute `csharptojs` in the command line without any arguments. The `csharptojson.config.json` will be read from the folder where the tool is being executed. 
```sh
$ csharptojs
```

**With path to config**

The first, and only, argument is the path to the config file, without the filename.
E.g. `c:/config/a-folder/csharptojson.config.json` would be:
```sh
$ csharptojs c:/config/a-folder
```

### Configuration file
Docs in progress. See [example in Samples](https://github.com/maxstralin/csharp-to-js/blob/master/samples/ConsoleAppSample/csharptojs.config.json) or [definition file](https://github.com/maxstralin/csharp-to-js/blob/master/src/Core/Models/CSharpToJsConfig.cs)


## Release History
* 0.2.1
    * [JsIgnore] attribute added

* 0.1.0
    * First initial release

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are greatly appreciated.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request