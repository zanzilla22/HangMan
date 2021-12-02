using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hangman : MonoBehaviour
{
    public GameObject[] parts;
    public int partLim;
    public int tally;
    void Start()
    {
        Reset();
    }
    public void Reset()
    {
        tally = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].SetActive(false);
        }
    }
    public void AddPart()
    {
        if(tally<=partLim)
        {
            parts[tally].SetActive(true);
            tally++;
        }
    }
}
