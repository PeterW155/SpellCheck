using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;
using UnityEngine.U2D.IK;
using Unity.Collections.LowLevel.Unsafe;

public class SpellingCheck : MonoBehaviour
{
    // Start is called before the first frame update
    string[] lines;
    public TMP_Text playerInput;
    public TMP_InputField inputField;
    public DisplayLibraries displayLibraries;
    public List<string> library = new List<string>();
    public List<string> libraries = new List<string>();


    void Awake()
    {
        libraries = FindLibraries();

        //playerInput.text = "<color=red>hello</color>";
    }

    public List<string> FindLibraries()
    {
        /*List<string> librariesHold = new List<string>();

        string[] files = Directory.GetFiles("Assets/SpellLibraries", ".");
        //Debug.Log(files.Length);
        foreach (string file in files)
        {
            if (file.EndsWith(".txt"))
            {
                int index = file.IndexOf("\\");

                string holdfile = file.Substring(index + 1, file.Length - 1 - index);
                librariesHold.Add(holdfile);
            }
            
        }*/
        return Directory.GetFiles("Assets/SpellLibraries", "*.txt", SearchOption.TopDirectoryOnly).Select(file => file.Substring(file.LastIndexOf("\\") + 1)).ToList();


        //return librariesHold;
    }

    public List<string> GetLibraries()
    {
        return libraries;
    }

    public void SetLibrary(string lib)
    {
        //LoadLibrary("Assets/SpellLibraries/" + lib);
    }

    public void LoadLibrary()
    {
        string lib = displayLibraries.GetLibrary();
        lib = "Assets/SpellLibraries/" + lib;
        FileInfo source = new FileInfo(lib);
        StreamReader reader = source.OpenText();
        string line = reader.ReadLine();
        library.Clear();

        while (line != null)
        {
            this.library.Add(line);
            line = reader.ReadLine();
        }
        
    }


    public void ReadLines()
    {
        lines = playerInput.text.Split("\n");


        /*if (SpellCheck(lines[0]))
        {
            Debug.Log("No Problem");
            playerInput.fontStyle = FontStyles.Normal;
            playerInput.color = Color.black;
        }
        else
        {
            Debug.Log("An Error");
            playerInput.fontStyle = FontStyles.Bold;
            playerInput.color = Color.red;
        }*/
        RunLines();
    }

    public bool SpellCheck(string text)
    {
        Debug.Log("Spell Checking Line Now");
        string[] Tempword = text.Split(" ");
        foreach (string word in Tempword)
            {
            if (!library.Contains(word.ToLower()) && word.Length > 0)
            {
                Debug.Log(word);
                return false;
            }
        }
        

        return true;
    }

    public string CheckLine(string line)
    {
        /*if (line.Contains("<color=red></color>"))
            line = line.Replace("<color=red></color>", "");*/
        line = line.Trim();
        line = line.Trim('\n');

        string[] words = line.Split(" ");

        string outputLine = "";

        foreach (string word in words)
        {
            if(word.Equals(" ") || word.Equals("") || word == null || word.Length < 1)
                continue;

            if (word.Contains("<color=red>"))
            {
                //Debug.Log(word + " is now REMOVED");
                string rawWord = "REMOVED";
                rawWord = word.Replace("</color>", "");
                rawWord = rawWord.Replace("<color=red>", "");
                if (library.Contains(rawWord.ToLower()))
                {
                    outputLine += rawWord + " ";
                }
                else
                {
                    outputLine += word + " ";
                }
            }
            else if (word.Length > 0)
            { 
                if (library.Contains(word.ToLower()))
                {
                    outputLine += word + " ";
                }
                else
                {
                    outputLine += "<color=red>" + word + "</color> ";
                }
            }
            /*if (library.Contains(word.ToLower()))
            {
                hold += word + " ";
            }
            else
            {
                hold += "<color=red>" + word + "</color> ";
            }*/
        }
        outputLine = outputLine.Substring(0, outputLine.Length);
        return outputLine;
    }

    public void RunLines()
    {
        string[] textLines = playerInput.text.Split('\n');
        Debug.Log("Run lines started");
        //Debug.Log(textLines[0]);
        inputField.text = "";

        foreach (string line in textLines)
        {
            /*if (SpellCheck(words))
            {
                inputField.text += words+"\n";
            }
            else
            {
                inputField.text += "<color=red>"+words+"</color>\n";
            }*/
            inputField.text += CheckLine(line) + "\n";
        }

        /*List<string> finalLines = new List<string>();

        foreach (string words in textLines)
        {
            string line;
            if (!SpellCheck(words))
            {
                line = "<color=red>" + words + "<\\color>";
            }
            else
            {
                line = words;
            }
            finalLines.Add(line);
        }

        playerText.text = "";
        foreach (string line in finalLines)
        {
            playerText.text += line;
        }*/
        Debug.Log("Run lines ended");
    }
}
