using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound_SpikeSpawn : MonoBehaviour
{
    public static Bound_SpikeSpawn instance;

    public float spike_mid_position;
    public float spike_distance;

    private int slope_step;
    private int slope_cnt;
    private bool is_slope_incline;

    private void Awake()
    {
        instance = this;
        spike_distance = 0;
        spike_mid_position = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "spike")
        {
            if (slope_cnt == 0)
            {
                slope_cnt = Random.Range(5, 13);
                is_slope_incline = (Random.value > 0.5f);

                //slope_step = 0;
                slope_step = is_slope_incline ? Random.Range(10, 30) : -Random.Range(10, 30);
                
                if(spike_mid_position >= 2000)
                {
                    slope_step = -Mathf.Abs(slope_step);
                }
                else if (spike_mid_position <= -2000)
                {
                    slope_step = Mathf.Abs(slope_step);
                }

            }
            if (spike_distance >= -50)
            {
                spike_distance -= 0.3f;
            }
            slope_cnt--;
            spike_mid_position += slope_step;
            collision.gameObject.transform.GetComponentInParent<SpikeSet_Placer>().Replacer(spike_distance, spike_mid_position);
        }

        else if(collision.tag == "coin")
        {
            collision.GetComponent<Coin_Moving>().CoinRespawn();
        }
    }
}
