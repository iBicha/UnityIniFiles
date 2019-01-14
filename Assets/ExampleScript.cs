using System.Collections;
using System.Collections.Generic;
using IniFiles;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{

    public IniFile config;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Reading config from ini: server address is {config.GetValue("server")}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
