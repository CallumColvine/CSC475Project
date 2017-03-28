using UnityEngine;
using System.Collections;
using System.Linq;

public class fftOnInput : MonoBehaviour {

    int range = 35;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float[] spectrum = new float[8192];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        // This is the largest magnitude in the array
        float maxValue = spectrum.Max();
        int maxNoteIndex = spectrum.ToList().IndexOf(maxValue);
        float maxNote = maxNoteIndex * 2.692f;

        Debug.Log(maxNote);

        float E4 = 304.196f;
        float B3 = 226.128f;
        float G3 = 180.364f;

        float E4TopRange = E4 + range;
        float E4BottomRange = E4 - range;
        float B3TopRange = B3 + range;
        float B3BottomRange = B3 - range;
        float G3TopRange = G3 + range;
        float G3BottomRange = G3 - range;

        GameObject[] Notes;
        Notes = GameObject.FindGameObjectsWithTag("Notes");

        GameObject n0 = Notes[0];
        GameObject n1 = Notes[0];
        GameObject n2 = Notes[0];

        for (int i=0; i< Notes.Length; i++)
        {
            if (Notes[i].name.Equals("n0"))
            {
                n0 = Notes[i];
            }
            if (Notes[i].name.Equals("n1"))
            {
                n1 = Notes[i];
            }
            if (Notes[i].name.Equals("n2"))
            {
                n2 = Notes[i];
            }
        }

        if (E4BottomRange <= maxNote && maxNote <= E4TopRange ){
            Debug.Log("ITS E4");
            n0.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);
        }
        else
        {
            n0.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
        if (B3BottomRange <= maxNote && maxNote <= B3TopRange){
            Debug.Log("ITS B3");
            n1.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);
        }
        else
        {
            n1.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
        if (G3BottomRange <= maxNote && maxNote <= G3TopRange){
            Debug.Log("ITS G3");
            n2.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);
        }
        else
        {
            n2.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }

        //float E4In = spectrum[14] + spectrum[15] + spectrum[16];
        //float B3In = spectrum[10] + spectrum[11] + spectrum[12];
        //float G3In = spectrum[8] + spectrum[9] + spectrum[10];



    }
}
