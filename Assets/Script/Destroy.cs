using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Photon.MonoBehaviour {

    public GameObject food;
    
    void Start () {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {


        if (photonView.isMine)
        {
            
            if (col.tag == "tail")
            {
                Debug.Log("here");
                for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<GameControll>().snakeTail.Count; i++)
                {
                    PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<GameControll>().snakeTail[i]);
                }
            }
            if (col.tag == "eat")
            {

                Physics2D.IgnoreCollision(food.GetComponent<Collider2D>(), GetComponent<Collider2D>());


            }

        }

    }

}
