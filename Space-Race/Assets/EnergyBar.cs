using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

	RectTransform rect;
	public Color fullColor;
	public Color emptyColor;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Image>().color = Color.Lerp(fullColor, emptyColor, (10 - rect.rect.width)/10);
	}
}
