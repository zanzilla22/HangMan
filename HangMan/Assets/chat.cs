using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;     
public class chat : MonoBehaviour
{
    
    public List<GameObject> messages = new List<GameObject>();
    public GameObject messagePrefab;
    public GameObject messageHolder;
    public player player;
    public GameObject inputField;
    int offset = 0;
    void Awake()
    {
        inputField.GetComponent<TMP_InputField>().characterLimit = 45;
    }
    public void SendAMessage()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            messages[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(28.5f, messages[i].GetComponent<RectTransform>().anchoredPosition.y + 60 + offset, 0);
        }
        //(messages[i].GetComponent<message>().bodyText.text.Length > 22 ? 40 : 40) rip beatyful code
        GameObject newMessage = Instantiate(messagePrefab);
        newMessage.transform.SetParent(messageHolder.transform, false);
        //if (newMessage.GetComponent<message>().bodyText.text.Length > 22 || (messages.Count > 0 ? messages[messages.Count].GetComponent<message>().bodyText.text.Length > 22 : false))
        //{
        //    for (int i = 0; i < messages.Count; i++)
        //    {
        //        messages[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(28.5f, messages[i].GetComponent<RectTransform>().anchoredPosition.y + 20, 0);
        //        //offset += 20;
        //    }
        //}
        messages.Add(newMessage);
        newMessage.GetComponent<message>().SetMessage(inputField.GetComponent<TMP_InputField>().text, player.username);
        Debug.Log("Message Sent");
        inputField.GetComponent<TMP_InputField>().text = "";
    }
}
