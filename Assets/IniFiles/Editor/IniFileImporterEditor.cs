using UnityEditor;
using UnityEditor.Experimental.AssetImporters;

namespace IniFiles.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(IniFileImporter))]
    public class IniFileImporterEditor : ScriptedImporterEditor
    {
    }
}