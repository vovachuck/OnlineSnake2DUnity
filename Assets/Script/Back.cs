using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    
    void Start () {
		
	}
    public void Restart()
    {
        
        Application.LoadLevel(1);
    }
    public void BackMenu()
    {

        Application.LoadLevel(0);
    }
   
}
