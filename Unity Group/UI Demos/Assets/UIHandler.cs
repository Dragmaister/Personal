using UnityEngine;

public class UIHandler : MonoBehaviour
{
	public void PrintClick ()
	{
		PrintText ("Click");
	}

	public void PrintText (string text)
	{
		Debug.Log (text);
	}
}
