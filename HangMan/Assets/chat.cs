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
    public void SendAMessage()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            messages[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(28.5f, messages[i].GetComponent<RectTransform>().anchoredPosition.y +60, 0);
        }
        GameObject newMessage = Instantiate(messagePrefab);
        newMessage.transform.parent = messageHolder.transform;
        Debug.Log("Message Sent");
        inputField.GetComponent<TMP_InputField>().text = "";
    }
    public void LL()
    {

    }
}
