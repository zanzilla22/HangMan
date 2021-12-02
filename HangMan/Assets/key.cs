using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class key : MonoBehaviour
{
	public keyRegister keyRegister;
	public void whenClicked()
	{
		Debug.Log(this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text);
		this.GetComponent<Button>().interactable = false;
		keyRegister.registerKey((this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text).ToCharArray());
	}
}
