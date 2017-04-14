using UnityEngine;
using System.Collections;

public class MoveBar : MonoBehaviour {

    public float moveIncrement = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 curPos = transform.localPosition;
        curPos[0] += moveIncrement;
        transform.localPosition = curPos;
	}
}
