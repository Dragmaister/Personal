using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	void Start()
	{
		var button = transform.FindChild("Button").GetComponent<Button>();

		/*button.onClick.AddListener(() => {
			Debug.Log("...");
			Print();
		});*/
	}

	public void Print()
	{
		Debug.Log("Print");
	}

	public void PrintText(string text)
	{
		Debug.Log(text);
	}

}
