using UnityEditor;

namespace IniFiles.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(IniFile))]
    public class IniFileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            foreach (var o in targets)
            {
                var iniObject = o as IniFile;
                if (iniObject == null) continue;

                if (targets.Length > 1)
                {
                    var filename = AssetDatabase.GetAssetPath(iniObject);
                    EditorGUILayout.LabelField(filename, EditorStyles.boldLabel);
                }

                foreach (var section in iniObject.Sections)
                {
                    if (!string.IsNullOrEmpty(section.Title))
                    {
                        EditorGUILayout.LabelField($"[{section.Title}]", EditorStyles.boldLabel);
                    }

                    for (int i = 0; i < section.Keys.Count; i++)
                    {
                        EditorGUILayout.TextField(section.Keys[i], section.Values[i]);
                    }

                    EditorGUILayout.Space();
                }

                EditorGUILayout.Separator();
            }
        }
    }
}