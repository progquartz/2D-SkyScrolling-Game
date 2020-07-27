using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField]
    private Text score_text;


    public Text gameover_score;
    public Text gameover_bestscore;

    public GameObject gameoverui;

    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!Game_Manager.instance.is_player_dead)
        {
            score_text.text = "Score : " + Game_Manager.instance.playing_score.ToString();
        }
    }

    public void GameOverUi()
    {
        Game_Manager.instance.GetComponent<AudioSource>().Play();
        gameoverui.gameObject.SetActive(true);
        int ending_score = Game_Manager.instance.playing_score;
        gameover_score.text = "Score:\n" + ending_score.ToString();
        if(ending_score > Game_Manager.instance.best_score)
        {
            PlayerPrefs.SetInt("Best Score", ending_score);
            Game_Manager.instance.best_score = ending_score;
        }
        gameover_bestscore.text = "Best Score:\n"+ Game_Manager.instance.best_score.ToString();
    }

    public void CoinGetUpdate()
    {

    }

    public void GameOverRetry()
    {
        Game_Manager.instance.Restart();
    }

    public void GameOverQuit()
    {
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }
}
