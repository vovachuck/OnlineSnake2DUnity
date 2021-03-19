using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControll : Photon.MonoBehaviour
{
    public GameObject snake;
    public GameObject tail;
    private GameObject name;
    private string mainName;
    public GameObject spawn;
    private Rigidbody2D rb;
    public float speed = 100.0f;
    private float radius = 0;
    public float position = 1;
    public List<GameObject> snakeTail = new List<GameObject>();
    void Start()
    {
       // snakeTail.Clear();
        snakeTail.Add(this.gameObject);
        mainName=GameObject.Find("Conroller").GetComponent<NewScene>().name;
       
        GameObject.FindGameObjectWithTag("name").GetComponent<Text>().text = mainName;
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (photonView.isMine)
        {
            if (col.tag == "wall")
            {
                
                
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("name"));
                for (int i = 0; i < snakeTail.Count; i++)
                {
                    PhotonNetwork.Destroy(snakeTail[i]);
                }
                PhotonNetwork.DestroyAll();
                PhotonNetwork.Disconnect();
                Application.LoadLevel(2);
            }
            else if (col.tag == "eat" && this.tag == "Player")
            {
                 Debug.Log(col.gameObject.tag);
                // PhotonNetwork.Destroy(col.gameObject);
                snakeTail.Add(PhotonNetwork.Instantiate("Tail",spawn.transform.position, Quaternion.identity, 0) as GameObject);

            }
            else if (col.tag == "tail")
            {
                
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("name"));
                for (int i = 0; i < snakeTail.Count; i++)
                {
                    PhotonNetwork.Destroy(snakeTail[i]);
                }
                PhotonNetwork.DestroyAll();
                PhotonNetwork.Disconnect();
                Application.LoadLevel(2);
            }


        }

            

    }

   

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
        
            rb.AddForce(transform.up * speed);
            GameObject.FindGameObjectWithTag("name").transform.position=this.transform.position;
            if (Input.GetKey(KeyCode.RightArrow))
            {

                rb.rotation = radius - Time.deltaTime * 200;
                /*rb.AddForce(Vector2.right*100);*/
                //rb.MoveRotation(20.0f);
            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //rb.velocity = Quaternion.AngleAxis(10f, Vector2.left);
                rb.rotation = radius + Time.deltaTime * 200;
            }
           /* if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-transform.up * (speed - 10));

            }*/
            
            radius = rb.rotation;
            rb.velocity = Vector2.zero;

        }

    }
}
