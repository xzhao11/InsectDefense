using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    string fullText;
	private string current = "";
	public bool isFinished;
	public bool isDoneTyping;
	public float delay = 0.05f;
	void Awake()
	{
		fullText = this.GetComponent<Text>().text;
		this.GetComponent<Text>().text = "";
		isFinished = false;
		StartCoroutine(PlayText());
		//Debug.Log(fullText);
		isDoneTyping = false;
	}

	IEnumerator PlayText()
	{
		//Debug.Log("length " + fullText.Length);
		for (int i = 0; i <= fullText.Length; i++)
		{
			current = fullText.Substring(0, i);
			this.GetComponent<Text>().text = current;
			if (current.Length == fullText.Length)
            {
				isDoneTyping = true;
				this.GetComponent<AudioSource>().Stop();
				var okButton = transform.GetChild(0);
				okButton.gameObject.SetActive(true);
            }
			
			yield return new WaitForSeconds(delay);
		}
	}

	public void OnClose()
    {
		isFinished = true;
		
    }
}
