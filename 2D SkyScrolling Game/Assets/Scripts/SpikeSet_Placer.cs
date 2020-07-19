using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSet_Placer : MonoBehaviour
{
    private static float spike_normal_distance = 625;

    public GameObject spike_up;
    public GameObject spike_down;

    // Start is called before the first frame update
    void Start()
    {
        spike_up.transform.position = this.transform.position + new Vector3(0, spike_normal_distance, 0);
        spike_down.transform.position = this.transform.position + new Vector3(0, -spike_normal_distance, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position + new Vector3(-5, 0, 0);
    }

    public void Replacer(float _spike_distance_between, float _middle_position)
    {
        this.transform.position = new Vector3(1950, 540 + _middle_position, 0);
        if(_spike_distance_between >= -50)
        {
            this.transform.GetChild(0).transform.position += new Vector3(0, _spike_distance_between, 0);
            this.transform.GetChild(1).transform.position -= new Vector3(0, _spike_distance_between, 0);
        }
    }
}
