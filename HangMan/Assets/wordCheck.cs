using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class wordCheck : MonoBehaviour
{
    public roundManagement roundManager;
    public player player;
    public Animator anim;
    public hangman hangman;
    public wordBank bank;
    public string chosenWord;
    public keyRegister keyRegister;
    [HideInInspector]
    public int hangParts = 0;
    List<char> valChars = new List<char>();

    public TextMeshProUGUI text;
    void Start()
    {
        newStart();
    }
    public void newStart()
    {
        valChars = new List<char>();
        hangParts = 0;
        hangman.resetParts();
        anim.SetBool("isShown", true);
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
        List<char> usedKeys = keyRegister.usedKeys;
        for (int i = 0; i < chosenWordChars.Length; i++)
        {
            if(letter == chosenWordChars[i])
            {
                player.AddScore(chosenWordChars[i].ToString().ToLower().ToCharArray()[0], 1);
                hasChar = true;
            }
            for (int k = 0; k < usedKeys.Count; k++)
            {
                if (usedKeys[k] == chosenWordChars[i])
                {
                    Debug.Log("char in here");
                    if(i!=0)
                    {
                        modBlankChars.Add(' ');
                    }
                    modBlankChars.Add(usedKeys[k]);
                    valChars[i] = usedKeys[k];
                }


            }

            if (chosenWordChars[i] != ' ' && valChars[i] == '_')
            {
                modBlankChars.Add('_');
                modBlankChars.Add('_');
                modBlankChars.Add(' ');
            } else if (chosenWordChars[i] == ' ')
            {
                modBlankChars.Add('-');
                modBlankChars.Add(' ');

            }
            //if (valChars[i] != '_')
            //return;

        }

        if(!hasChar)
        {
            hangman.AddPart();
            hangParts++;
            if(hangParts == 6)
            {
                roundManager.Lose(chosenWord);
            }
        } else
        {
            string blankedText = new String(modBlankChars.ToArray());
            text.text = blankedText;
            bool k = false;
            for (int i = 0; i < valChars.Count; i++)
            {
                if(valChars[i] == '_')
                {
                    k = true;
                }
            }
            if(!k)
            {
                roundManager.Win();
            }
        }
    }
}
