using UnityEngine;
using System.Collections;

public class CheckCollideFreq : MonoBehaviour {

    public new string name = "E4";
    public float expectedFreq = 329.63f;
    public float actualFreq = 304.96f;
    public float deviationRange = 35;
    protected bool noteHit = false;
    //private fftOnInput musicScirpt;

    //void Start()
    //{
    //    GameObject fret0 = GameObject.Find("Fret0");
    //    fftOnInput musicScript = fret0.GetComponent<fftOnInput>();
    //}

    void colourIfMatching(float curNote)
    {
		Debug.Log ("Current note being played is ");
		Debug.Log (curNote);
        if ((actualFreq - deviationRange) <= curNote && curNote <= (actualFreq + deviationRange))
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);
            noteHit = true;
        }
    }

//	void OnTriggerEnter(Collider col){
//		if (col.gameObject.name == "NoteCollider") {
//			fftOnInput script = col.gameObject.GetComponent (typeof(fftOnInput)) as fftOnInput;
//			Debug.Log ("Current note being played is ");
//			Debug.Log (script.curNote);
//		}
//	}

    void OnTriggerExit(Collider col)
    {
        if (!noteHit)
        {
            GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0);
        }
    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.collider.name);
        //Debug.Log(col.GetComponent<Collider>().name);
        if (col.gameObject.name == "NoteCollider")
        {
            fftOnInput script = col.gameObject.GetComponent(typeof(fftOnInput)) as fftOnInput;
            colourIfMatching(script.curNote);
            //Debug.Log(script.curNote);
        }
        //Destroy(other.gameObject);
    }


    //void OnCollisionEnter(Collision col)
    //{
    //    //Debug.Log("!!! COLLISION HAPPENED !!!");
    //    Debug.Log(col.collider.name);
    //    if (col.gameObject.name == "NoteCollider")
    //    {
    //        // Check if the current note is ours, the bar just hit us
    //        Debug.Log("!!! COLLISION HAPPENED !!!");
    //    }
    //}

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void FixedUpdate () {

    //}

    //   bool checkCollision()
    //   {

    //       return false;
    //}
}
