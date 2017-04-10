using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	public float increment = 0.01f;
	// Use this for initialization

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 curPos = transform.localPosition;
		curPos[0] += increment;
		transform.localPosition = curPos;
	}
}
