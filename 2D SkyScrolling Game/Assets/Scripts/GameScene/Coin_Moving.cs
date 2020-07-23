using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position + new Vector3(-Game_Manager.instance.game_speed, 0, 0);
    }

    public void CoinRespawn()
    {
        this.transform.position = new Vector3(1950 + Random.Range(-200, 200), 540 + Bound_SpikeSpawn.instance.spike_mid_position + Random.Range(-200 + Bound_SpikeSpawn.instance.spike_distance ,200 - Bound_SpikeSpawn.instance.spike_distance), 0);
    }    
}
