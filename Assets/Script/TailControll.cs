using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailControll : Photon.MonoBehaviour
{

    
    public GameObject head;
    private List<GameObject> snake = new List<GameObject>();
    private Rigidbody2D rb;
    public int speedTrans=10;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    void Start() {
        if (photonView.isMine) { 
            snake = GameObject.FindGameObjectWithTag("Player").GetComponent<GameControll>().snakeTail;
    }
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {



        if (photonView.isMine && col.tag == "top")
        {
            for (int i = 0; i < snake.Count; i++)
            {
                PhotonNetwork.Destroy(snake[i]);
            }

        }
        else 
        {
            
        }



    }
    void FixedUpdate()
    {

        //rb.AddForce(snake[snake.IndexOf(this.gameObject)-1].transform.position);
        // Debug.Log("tail="+ (snake[snake.IndexOf(this.gameObject) - 1].transform.position));
        /*transform.position = Vector2.Lerp(transform.position, snake[snake.IndexOf(this.gameObject) - 1].transform.position,
            speedTrans * Time.fixedDeltaTime);*/
        // rb.MovePosition(snake[snake.IndexOf(this.gameObject) - 1].transform.position);
        /* rb.position = Vector2.Lerp(transform.position, snake[snake.IndexOf(this.gameObject) - 1].transform.position,
              speedTrans * Time.fixedDeltaTime);*/
       // Debug.Log(snake.IndexOf(this.gameObject) - 1);
        if (photonView.isMine)
        {
            rb.position = Vector2.Lerp(transform.position, snake[snake.IndexOf(this.gameObject) - 1].transform.position,
              speedTrans * Time.fixedDeltaTime);
        }
           //rb.MovePosition(snake[snake.IndexOf(this.gameObject) - 1].transform.position);
        
    }
}
