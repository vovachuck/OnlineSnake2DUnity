using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewScene : Photon.MonoBehaviour
{
    public InputField mainInput;
    public string name=null;
    private bool sound = true;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
    }
	
	public void LoadNewScene()
    {
        name = mainInput.text.ToString();
    Application.LoadLevel(1);
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
    }
    public void OnSound()
    {
        GameObject.Find("SoundOff").active=false;
        GameObject.Find("SoundOn").active = true;
        Debug.Log("dd");
        sound = true;

    }
    public void OffSound()
    {
        GameObject.Find("SoundOn").active = false;
        GameObject.Find("SoundOff").active = true;
        Debug.Log("dd");
        sound = false;
    }
}
