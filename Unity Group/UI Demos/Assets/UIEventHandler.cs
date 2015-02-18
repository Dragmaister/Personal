using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IDeselectHandler, ISelectHandler
{

	private Canvas canvas;

	public bool PointerUpEnabled = false;
	public bool PointerDownEnabled = false;
	public bool PointerEnterEnabled = false;
	public bool PointerExitEnabled = false;
	public bool PointerClickEnabled = false;
	public bool DraggingEnabled = false;

	public bool WorldSpace = false;

	private bool isHovering = false;

	void Awake ()
	{
		canvas = this.GetComponentInParent<Canvas> ();
	}
	
	public void OnPointerUp (PointerEventData eventData)
	{
		if (!PointerUpEnabled)
			return;
		Debug.Log ("OnPointerUp");
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		if (!PointerDownEnabled)
			return;
		Debug.Log ("OnPointerDown");
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (!PointerEnterEnabled)
			return;
		Debug.Log ("OnPointerEnter");
		isHovering = true;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (!PointerExitEnabled)
			return;
		Debug.Log ("OnPointerExit");
		isHovering = false;
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (!PointerClickEnabled)
			return;
		Debug.Log ("OnClick");
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (!DraggingEnabled)
			return;
		Debug.Log ("Dragging " + this);
		Drag (eventData);
	}

	public void OnSelect (BaseEventData eventData)
	{
		Debug.Log ("Selected " + this);
	}

	public void OnDeselect (BaseEventData eventData)
	{
		Debug.Log ("Deselected " + this);
	}

	void Update ()
	{
		if (isHovering)
			Debug.Log ("Hover...");
	}

	private void Drag (PointerEventData eventData)
	{
		Vector3 position;
		if (WorldSpace)
			position = Camera.main.ScreenToWorldPoint (new Vector3 (eventData.position.x, eventData.position.y, 6f));
		else
			position = eventData.position;

		transform.position = position;
	}

	private float GetCanvasScale ()
	{
		var scale = canvas.GetComponent<RectTransform> ().localScale.x;
		return scale;
	}

	private float GetCanvasRatio ()
	{
		var ratio = canvas.pixelRect.height / canvas.GetComponent<RectTransform> ().rect.height;
		return ratio;
	}
}
