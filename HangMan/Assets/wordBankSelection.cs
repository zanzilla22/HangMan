using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordBankSelection : MonoBehaviour
{
    public wordBank wordBank;
    public wordCheck wordCheck;
    public GameObject selectionScreen;
    public GameObject content;
    void Awake()
    {
        if (content)
        {
            content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
    }
    public void SetBank()
    {
        wordCheck.bank = wordBank;
        selectionScreen.SetActive(false);
        wordCheck.newStart();
    }
}
