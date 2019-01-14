using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

namespace IniFiles.Editor {
    [ScriptedImporter(1, "ini")]
    public class IniFileImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var textContent = File.ReadAllText(ctx.assetPath);
            var iniObject = IniFile.ParseIniFile(textContent);
            ctx.AddObjectToAsset("IniFileObject", iniObject);
            ctx.SetMainObject(iniObject);
        }
    }
}
