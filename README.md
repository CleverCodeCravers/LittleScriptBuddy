# LittleScriptBrother

LittleScriptBrother is an application that will watch your file changes cs-files in a specific directory.

```
LittleScriptBrother.exe --targetDirectory C:\Projekte --scriptDirectory C:\Scripts
```

The script directory contains a bunch of powershell-files. 
Every powershell file is considered a possible command.

When you write a special comment in your code it will add the result to the file:

```csharp
// lsb: collection of IWhatever
```

It will parse that line and convert it into the following command: 
```
collection.ps -of IWhatever
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

The text will then end up below the comment:
```
// lsb: collection of IWhatever
public class WhateverCollection {
    private List<IWhatever> data = new List<IWhatever>();
    
    public WhateverCollection()
    {
    }
}
// end ļsb
```

You can now change your command as often as you like. The text between the `lsb` command line and `end lsb` will be replaced every time
the file is saved again.

When you like your code, simply add an exclamation mark to the end of the lsb command line:
```
// lsb: collection of IWhatever!
public class WhateverCollection {
    private List<IWhatever> data = new List<IWhatever>();
    
    public WhateverCollection()
    {
    }
}
// end ļsb
```

This will remove the lsb line itself as well as the `end lsb` line leaving the new code block where it is.


