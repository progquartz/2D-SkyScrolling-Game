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

    public Text pause_score;
    public Text pause_bestscore;

    public Text pause_counter;

    public GameObject gameoverui;
    public GameObject pauseui;

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

    public void PauseUi()
    {
        pauseui.gameObject.SetActive(true);
        pause_score.text = "Score:\n" + Game_Manager.instance.playing_score.ToString();
        if (Game_Manager.instance.playing_score > Game_Manager.instance.best_score)
        {
            PlayerPrefs.SetInt("Best Score", Game_Manager.instance.playing_score);
            Game_Manager.instance.best_score = Game_Manager.instance.playing_score;
        }
        pause_bestscore.text = "Best Score:\n" + Game_Manager.instance.best_score.ToString();
        Time.timeScale = 0;
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void ContinueGame()
    {
        Debug.Log("누르고있당께");
        pauseui.gameObject.SetActive(false);
        StartCoroutine(TimeCounter(3));
    }

    IEnumerator TimeCounter(int a)
    {
        int cnt = a;
        while(cnt > 0)
        {
            pause_counter.text = cnt.ToString();
            yield return new WaitForSecondsRealtime(1.0f);
            cnt--;
        }
        pause_counter.text = "";
        Time.timeScale = 1.0f;
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
