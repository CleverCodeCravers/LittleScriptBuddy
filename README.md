# LittleScriptBrother

[![.github/workflows/build.yml](https://github.com/CleverCodeCravers/LittleScriptBuddy/actions/workflows/build.yml/badge.svg)](https://github.com/CleverCodeCravers/LittleScriptBuddy/actions/workflows/build.yml)

An application that will watch your file changes cs-files, look for a specific comment, translate this comment into a command line, execute it and paste the results into the cs file.

```
LittleScriptBuddy.exe --targetDirectory C:\Projekte --scriptsDirectory C:\Scripts
```

The script directory contains a bunch of powershell-files. 
Every powershell file is considered a possible command.

When you write a special comment in your code it will add the result to the file:

```csharp
//lsb: collection.ps1 "IWhatever"
```

It will parse that line and convert it into the following command: 
```
collection.ps1 "IWhatever"
```

The powershell script will then output some things to stdout which will be collected:
```
public class WhateverCollection {
    private List<IWhatever> data = new List<IWhatever>();
    
    public WhateverCollection()
    {
    }
}
```

The comment will then be replaced by the content the script delivered:
```
public class WhateverCollection {
    private List<IWhatever> data = new List<IWhatever>();
    
    public WhateverCollection()
    {
    }
}
```

This "template plugin" allows for a lot of automation since we are using powershell in the backend which is fully fledged and can tap into the .net framework as a huge library.

Also it works with any editor you like, as long as it allows for auto-reloading changes that have taken place outside of the editor. VSCode and Visual Studio both do.
