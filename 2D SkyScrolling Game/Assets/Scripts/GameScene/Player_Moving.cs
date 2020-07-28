﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Moving : MonoBehaviour
{
    private float playerMovingRate;
    private char keyInput;

    private bool is_teleport_possible;

    private void Awake()
    {
        is_teleport_possible = true;
    }
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        this.gameObject.transform.position += new Vector3(0, playerMovingRate * 0.3f ,0);
        player_move();
        //rb.AddForce(new Vector2(0, playerMovingRate * 10));
        //this.transform.position += new Vector3(this.transform.position.x, this.transform.position.y + playerMovingRate, this.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spike" || collision.tag == "enemy" || collision.tag == "laser")
        {
            Destroy(this.gameObject);
            Game_Manager.instance.is_player_dead = true;
            UI_Manager.instance.GameOverUi();
        }
        else if (collision.tag == "coin")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Coin_Moving>().CoinRespawn();
            Game_Manager.instance.playing_score += 1000;
            //UI_Manager.instance.CoinGetUpdate();
        }
    }

    private void player_move()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (playerMovingRate > 0)
                {
                    playerMovingRate -= 3.0f;
                }
                else
                {
                    playerMovingRate -= 2.3f;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (playerMovingRate < 0)
                {
                    playerMovingRate += 3.0f;
                }
                else
                {
                    playerMovingRate += 2.3f;
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
                {
                    Teleport(false);
                }
                else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    Teleport(true);
                }
            }
        }

        if (playerMovingRate > 55)
        {
            playerMovingRate = 55;
        }
        else if (playerMovingRate < -55)
        {
            playerMovingRate = -55;
        }
    }

    private void Teleport(bool is_side_up)
    {
        int teleport_distance = 100 + (int)playerMovingRate * 3;
        if (is_side_up && is_teleport_possible)
        {
            this.GetComponent<AudioSource>().Play();
            Debug.Log("moving up!");
            this.gameObject.transform.position += new Vector3(0, 70, 0);
        }
        else if(is_teleport_possible)
        {
            this.GetComponent<AudioSource>().Play();
            Debug.Log("moving down!");
            this.gameObject.transform.position += new Vector3(0, -70, 0);
        }
        StartCoroutine(TeleportCoolTime());
    }

    IEnumerator TeleportCoolTime()
    {
        is_teleport_possible = false;

        yield return new WaitForSeconds(1.0f);
        is_teleport_possible = true;
    }
}

