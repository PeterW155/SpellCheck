using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLibraries : MonoBehaviour
{
    public TMP_Dropdown optionsDisplay;
    public List<string> libraries = new List<string>();
    public SpellingCheck spellCheck;

    // Start is called before the first frame update
    void Start()
    {
        spellCheck = FindAnyObjectByType<SpellingCheck>();
        libraries = spellCheck.GetLibraries();
        Debug.Log("Display starts here");

        foreach (string lib in libraries)
        {
            Debug.Log(lib);
        }

        optionsDisplay.AddOptions(libraries);
    }

    public string GetLibrary()
    {
        string lib;
        lib = optionsDisplay.captionText.text;
        Debug.Log("SetLibrary Called");
        return lib;
        //Debug.Log(lib);
        //spellCheck.SetLibrary(lib);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
