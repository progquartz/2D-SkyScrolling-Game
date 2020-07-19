using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [SerializeField]
    private Text score_text;
    private int score;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverUi()
    {

    }
}
