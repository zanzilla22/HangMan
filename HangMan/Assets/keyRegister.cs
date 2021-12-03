using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyRegister : MonoBehaviour
{
    public List<char> usedKeys = new List<char>();
    public wordCheck wordChecker;
    public GameObject[] keys;
    public void registerKey(char[] key)
    {
        usedKeys.Add(key[0]);
        wordChecker.CheckLetter(key[0]);
    }
    public void resetKeys()
    {
        usedKeys = new List<char>();
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].GetComponent<Button>().interactable = true;
        }
    }
}
