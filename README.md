# UnityIniFiles
A very naive implementation to import .ini configuration files into Unity

### When is this useful?
This is useful if you have .ini file(s) that holds configuration and you are too lazy to convert them to another format that Unity can support. With this piece of code, you can import them directly.

### How to use
 - Add your ini files to your Unity project.  
 - Unity will automatically import them, and you will be able to reference them as `ScriptableObject` of type `IniFile`
 - You should see the values from the ini file in the inspector (read only, as this plugin does not support writing/saving data)
 - You can call `IniFile.GetValue(string key, string sectionName = null)` to read the value of the configuration.
 - See sample scene for more (even though that's about it).

### Limitations
 - This plugin does not implement all ini features
 - This plugin only read ini files (at import time) and does not support changing/writing values.
