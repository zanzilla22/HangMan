using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Word Bank", menuName = "WordBank")]
public class wordBank : ScriptableObject
{
    public new string name;
    // string filePath = ("WordBankFiles/" + name + ".txt");
    public new string filePath;
}
