using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class roundManagement : MonoBehaviour
{
    int round = 1;
    public keyRegister keyRegister;
    public wordCheck wordCheck;
    public TextMeshProUGUI roundText;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject lossText;
    public IEnumerator RoundReset(int delay)
    {
        yield return new WaitForSeconds(delay);
        round++;
        roundText.text = "Round: " + round;
        wordCheck.newStart();
        keyRegister.resetKeys();
    }
    public void Lose(string correctWord)
    {
        lossText.GetComponent<TextMeshProUGUI>().text = "The correct word/phrase was: " + correctWord;
        LoseScreen.GetComponent<Animator>().SetTrigger("shown");
        StartCoroutine(RoundReset(5));
    }    
    public void Win()
    {
        WinScreen.GetComponent<Animator>().SetTrigger("shown");
        StartCoroutine(RoundReset(5));
    }
    
}
