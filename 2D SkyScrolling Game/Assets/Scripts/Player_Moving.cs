using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moving : MonoBehaviour
{
    private float playerMovingRate;
    private char keyInput;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, playerMovingRate * 10));
        //this.transform.position += new Vector3(this.transform.position.x, this.transform.position.y + playerMovingRate, this.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        player_move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "spike")
        {
            Destroy(this.gameObject);
            Game_Manager.instance.is_player_dead = true;
            UI_Manager.instance.GameOverUi();
        }
    }

    private void player_move()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                if (playerMovingRate > 0)
                {
                    playerMovingRate -= 10.0f;
                }
                else
                {
                    playerMovingRate -= 7.0f;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up");
                if (playerMovingRate < 0)
                {
                    playerMovingRate += 10.0f;
                }
                else
                {
                    playerMovingRate += 7.0f;
                }
            }
        }

        if (playerMovingRate > 20)
        {
            playerMovingRate = 20;
        }
        else if (playerMovingRate < -20)
        {
            playerMovingRate = -20;
        }
    }
}
