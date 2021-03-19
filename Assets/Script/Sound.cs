using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    // Use this for initialization
    private bool sound = true;
	void Start () {
        DontDestroyOnLoad(this);
    }
	
	public void OnSound()
    {

        sound = true;
    }
    public void OffSound()
    {
        sound = false;
    }
}
