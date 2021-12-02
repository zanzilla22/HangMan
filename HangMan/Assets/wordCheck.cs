using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class wordCheck : MonoBehaviour
{
    public hangman hangman;
    public wordBank bank;
    public string chosenWord;
    List<char> valChars = new List<char>();

    public TextMeshProUGUI text;
    void Start()
    {
        string[] lines = File.ReadAllLines("customfiles/" + bank.filePath + ".txt");
        chosenWord = lines[UnityEngine.Random.Range(0, lines.Length - 1)];

        List<char> blankedTextChar = new List<char>();
        char[] chosenWordChars = chosenWord.ToCharArray();
        for (int i = 0; i < chosenWord.Length; i++)
        {
            if (chosenWordChars[i] == ' ' && !(i > chosenWord.Length - 2))
            {
                blankedTextChar.Add('-');
                valChars.Add('-');
            }
            else if (chosenWordChars[i] != ' ')
            {
                blankedTextChar.Add('_');
                blankedTextChar.Add('_');
                valChars.Add('_');
            }
            blankedTextChar.Add(' ');
        }
        string blankedText = new String(blankedTextChar.ToArray());
        text.text = blankedText;
    }

    public void CheckLetter(char letter)
    {
        bool hasChar = false;
        char[] chosenWordChars = chosenWord.ToUpper().ToCharArray();
        List<char> modBlankChars = new List<char>();
        
        for (int i = 0; i < chosenWordChars.Length; i++)
        {
            //if (valChars[i] != '_')
                //return;
            if (letter == chosenWordChars[i])
            {
                Debug.Log("char in here");
                modBlankChars.Add(letter);
                hasChar = true;
            } else
            {
                modBlankChars.Add('_');
                modBlankChars.Add('_');
            }
            modBlankChars.Add(' ');
        }

        if(!hasChar)
        {
            hangman.AddPart();
        } else
        {
            string blankedText = new String(modBlankChars.ToArray());
            text.text = blankedText;
        }
    }
}
