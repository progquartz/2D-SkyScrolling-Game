using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public GameObject playercamerafollower;
    public bool is_player_dead;

    public int playing_score;
    public int best_score;

    public float game_speed;
    private void Awake()
    {
        instance = this;
        is_player_dead = false;
        game_speed = 7.0f;
        playercamerafollower = GameObject.Find("Player");

        best_score = 0;
        try{
            best_score = PlayerPrefs.GetInt("Best Score");
        }
        catch
        {

        }
        
    }

    
    IEnumerator GameSpeedUp()
    {
        while (!is_player_dead)
        {
            playercamerafollower.transform.position += new Vector3(0.01f, 0,0);
            game_speed += 1.0f;
            yield return new WaitForSeconds(2.0f);
        }
    }

    public void Restart()
    {
        //Get current scene name
        string scene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void Start()
    {
        StartCoroutine(GameSpeedUp());
    }

    private void FixedUpdate()
    {
        if (!is_player_dead)
        {
            playing_score += 10;
        }
    }
}
