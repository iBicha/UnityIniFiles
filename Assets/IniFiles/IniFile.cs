using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace IniFiles
{
    public class IniFile : ScriptableObject
    {
        [Serializable]
        public class IniSection
        {
            public IniSection(string title = null)
            {
                Title = title;
                Keys = new List<string>();
                Values = new List<string>();
            }

            public string Title;
            public List<string> Keys;
            public List<string> Values;
        }

        public IniSection[] Sections;

        public string GetValue(string key, string sectionName = null)
        {
            foreach (var section in Sections)
            {
                if(!string.IsNullOrEmpty(sectionName) && section.Title != sectionName)
                    continue;

                var index = section.Keys.IndexOf(key);
                if (index != -1)
                    return section.Values[index];
            }
            return null;
        }
        
        public static IniFile ParseIniFile(string iniFileContent)
        {
            var sections = new List<IniSection>();
            IniSection currentSection = null;
            using (StringReader stringReader = new StringReader(iniFileContent))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    line = line.Trim();
                    //Comment
                    if (line.StartsWith(";")) continue;
                    //Section
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        var sectionName = line.TrimStart('[').TrimEnd(']');
                        currentSection = new IniSection(sectionName);
                        sections.Add(currentSection);
                        continue;
                    }

                    //Key=Value
                    if (line.Contains("="))
                    {
                        var key = line.Substring(0, line.IndexOf("=", StringComparison.Ordinal));
                        var value = line.Substring(key.Length + 1);

                        if (currentSection == null)
                        {
                            currentSection = new IniSection();
                            sections.Add(currentSection);
                        }
                        currentSection.Keys.Add(key);
                        currentSection.Values.Add(value);
                    }
                }
            }
            
            var ini = CreateInstance<IniFile>();
            ini.Sections = sections.ToArray();
            return ini;
        }
    }
}