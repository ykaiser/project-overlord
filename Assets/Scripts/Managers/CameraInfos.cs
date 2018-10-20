using UnityEngine;
using System.Collections;

public class CameraInfos : MonoBehaviour {

	public Vector3 pivotOffset = new Vector3(0.2f, 0.7f,  0.0f); // offset of point from player transform (?) ben0bi
	public Vector3 camOffset   = new Vector3(0.0f, 0.7f, -3.4f); // offset of camera from pivotOffset (?) ben0bi
	public Vector3 closeOffset = new Vector3(0.35f, 1.7f, 0.0f); // close offset of camera from pivotOffset (?) ben0bi

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
