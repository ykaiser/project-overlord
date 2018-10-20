using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaSwitch : MonoBehaviour {

	Text text; 
	float f, count = 0;
	Color color;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime * 2f;
		f = Mathf.Sin(count);

		if(f < 0.1f) {
			count += 0.3f;
		}

		color = new Color(text.color.r, text.color.g, text.color.b, f);
		text.color = color;
	}
}
