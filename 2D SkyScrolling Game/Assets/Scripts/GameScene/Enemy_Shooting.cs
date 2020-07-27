using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    private bool is_player_locked;
    [SerializeField]
    private bool is_enemy_shooting;
    [SerializeField]
    private int shoot_cnt;

    private void Awake()
    {
        is_player_locked = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("안나오냐");
            is_player_locked = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            is_player_locked = false;
        }
    }

    private void LookAt(Vector2 targetPos)
    {
        Vector2 dif_vec = new Vector2(transform.position.x - targetPos.x, transform.position.y - targetPos.y);
        if(transform.position.y > targetPos.y)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan(dif_vec.x / dif_vec.y) * 180 / Mathf.PI + 180));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Abs(Mathf.Atan(dif_vec.x / dif_vec.y) * 180 / Mathf.PI)));
        }
        
    }

    private void Update()
    {
        if(shoot_cnt >= 40)
        {
            is_enemy_shooting = true;
            shoot_cnt = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position + new Vector3(-Game_Manager.instance.game_speed, 0, 0);
        if (is_player_locked && !is_enemy_shooting)
        {
            LookAt(target.transform.position);
            shoot_cnt++;
        }
    }

    public void Replacer(float _spike_distance_between, float _middle_position)
    {
        this.transform.position = new Vector3(1950, 540 + _middle_position, 0);
        is_enemy_shooting = false;
        is_player_locked = false;
        shoot_cnt = 0;
        this.transform.GetChild(0).GetComponent<LockDown>().Reset();
    }
}
