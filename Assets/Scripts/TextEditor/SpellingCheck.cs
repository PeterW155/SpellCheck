using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SpellingCheck : MonoBehaviour
{
    // Start is called before the first frame update
    string[] lines;
    public TMP_Text playerInput;
    public TMP_InputField inputField;
    public string[] holdWords;

    void Start()
    {
        holdWords = new string[] { "hello", "boo", "test", "trash" };
        //playerInput.text = "<color=red>hello</color>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadLines()
    {
        Debug.Log(holdWords[0]);
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
            if (!holdWords.Contains(word.ToLower()) && word.Length > 0)
            {
                Debug.Log(word);
                return false;
            }
        }
        

        return true;
    }

    public string CheckLine(string line)
    {
        string[] Tempword = line.Split(" ");
        string hold = "";

        foreach (string word in Tempword)
        {
            if (holdWords.Contains(word.ToLower()))
            {
                hold += word + " ";
            }
            else
            {
                hold += "<color=red>"+word+"</color> ";
            }
        }

        return hold;
    }

    public void RunLines()
    {
        string[] textLines = playerInput.text.Split('\n');
        Debug.Log("Run lines started");
        Debug.Log(textLines[0]);
        inputField.text = "";

        foreach (string words in textLines)
        {
            /*if (SpellCheck(words))
            {
                inputField.text += words+"\n";
            }
            else
            {
                inputField.text += "<color=red>"+words+"</color>\n";
            }*/
            inputField.text += CheckLine(words) + "\n";
        }


        //inputField.text += "<color=blue>bitch</color>";
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
