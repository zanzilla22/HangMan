using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public string username = "ThisFuckingGuy";
    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
    char[] secondary = {'h', 'y', 'x', 'z', 'w', 'q', 'v'};
    [HideInInspector]
    public int score = 0;

    public TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore(char letter, int mult)
    {
        bool consonant = true;
        for (int i = 0; i < vowels.Length; i++)
        {
            if(vowels[i] == letter)
            {
                score += 50 * mult;
                consonant = false;
            }
        }
        for (int i = 0; i < secondary.Length; i++)
        {
            if (secondary[i] == letter)
            {
                score += 100 * mult;
                consonant = false;
            }
        }
        if(consonant)
        {
            score += 75 * mult;
        }
        scoreText.text = score.ToString();
    }
}
