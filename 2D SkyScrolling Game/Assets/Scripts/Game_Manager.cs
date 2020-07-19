using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public bool is_player_dead;

    private void Awake()
    {
        instance = this;
        is_player_dead = false;

    }

    private void Start()
    {
        
    }
}
