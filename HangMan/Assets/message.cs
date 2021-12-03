using UnityEngine;
using TMPro;

public class message : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI userText;
    public void SetMessage(string message, string username)
    {
        bodyText.text = message;
        userText.text = username;
    }
}
