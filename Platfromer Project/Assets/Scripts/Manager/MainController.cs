using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    public static MainController instance;
    public GameObject GameOverPanel;
    public GameObject GameSuccessPanel;

    [Header("Score")]
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    private float score;
    public TextMeshProUGUI Level;

    public bool isGameStart=false; // 게임이 시작했는지 안했는지 [3..2..1..]

    [Header("StartCoroutine UI")]
    public TextMeshProUGUI startCountText; //3..2..1..
    public GameObject startUIPanel; // 시작전 배경

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        startCountText.text = "3";
        yield return new WaitForSeconds(1f);
        startCountText.text = "2";
        yield return new WaitForSeconds(1f);
        startCountText.text = "1";
        yield return new WaitForSeconds(1f);
        startCountText.text = "START";
        isGameStart = true;
        yield return new WaitForSeconds(0.3f);
        startUIPanel.SetActive(false);
    }

    private void Update()
    {
        score = GameManager.instance.score;
        updateGUIText();
    }

    private void updateGUIText()
    {
        CurrentScore.text = $"현재점수 : {GameManager.instance.score}";
        Level.text = $"현재레벨: {GameManager.instance.ReturnCurrentDifficulty()}";
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;

    }

    public void GameOver() 
    {
        GameOverPanel.SetActive(true); // 게임 오버일 때 게임 종료 UI 활성화
        // 현재 점수가 최고 점수보다 높을 때 갱신
        if (score > PlayerPrefs.GetFloat(GameData.BestScore)) { 
            PlayerPrefs.SetFloat(GameData.BestScore, score);
            BestScore.text = $"최고점수 : {GameManager.instance.score}";
        }
        else // 현재 점수가 최고 점수보다 낮을 때 기존의 최고 점수를 불러온다
            BestScore.text = $"최고점수 : {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void GameSuccess()
    {
        GameSuccessPanel.SetActive(true);
        BestScore.text = $"최고점수 : {PlayerPrefs.GetFloat(GameData.BestScore)}"; // 점수가 안뜸
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
