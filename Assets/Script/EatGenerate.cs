using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGenerate : Photon.MonoBehaviour {
    public GameObject eat;
    public int time=4;
    public List<GameObject> snakeEat = new List<GameObject>();
    private Vector2 pos = new Vector2();
    private bool flag = true;
    // Use this for initialization
    void Start () {
		

	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag && PhotonNetwork.isMasterClient )
        {
            StartCoroutine(Example());
            flag = false;
        }
        



    }
IEnumerator Example()
{

    yield return new WaitForSeconds(time);
        flag = true;
        pos = new Vector2(Random.Range(-8.14f, 8.08f), Random.Range(-4.08f, 4.29f));
        snakeEat.Add(PhotonNetwork.Instantiate("Eat", pos, Quaternion.identity, 0) as GameObject);
    }
}

