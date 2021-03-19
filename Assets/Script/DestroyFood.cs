using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFood : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PhotonNetwork.isMasterClient && col.tag=="Player")
        {
           // PhotonNetwork.Destroy(this.gameObject);
            photonView.RPC("networkShare", PhotonTargets.All, this.GetComponent<PhotonView>().viewID.ToString());
        }

    }

    [PunRPC]
    void networkShare(string text)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if(this.GetComponent<PhotonView>().viewID.ToString() == text)
            PhotonNetwork.Destroy(this.gameObject);
        }

    }


}
