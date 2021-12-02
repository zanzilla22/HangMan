using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyRegister : MonoBehaviour
{
    public List<char> usedKeys = new List<char>();
    public wordCheck wordChecker;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void registerKey(char[] key)
    {
        usedKeys.Add(key[0]);
        wordChecker.CheckLetter(key[0]);
    }
}
