using System.Collections;
using System.Collections.Generic;
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

   

    private void Update()
    {
        score = GameManager.instance.score;
        updateGUIText();
    }

    private void updateGUIText()
    {
        CurrentScore.text = $"�������� : {GameManager.instance.score}";
        Level.text = $"���緹��: {GameManager.instance.ReturnCurrentDifficulty()}";
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;

    }

    public void GameOver() 
    {
        GameOverPanel.SetActive(true); // ���� ������ �� ���� ���� UI Ȱ��ȭ
        // ���� ������ �ְ� �������� ���� �� ����
        if (score > PlayerPrefs.GetFloat(GameData.BestScore)) { 
            PlayerPrefs.SetFloat(GameData.BestScore, score);
            BestScore.text = $"�ְ����� : {GameManager.instance.score}";
        }
        else // ���� ������ �ְ� �������� ���� �� ������ �ְ� ������ �ҷ��´�
            BestScore.text = $"�ְ����� : {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void GameSuccess()
    {
        GameSuccessPanel.SetActive(true);
        BestScore.text = $"�ְ����� : {PlayerPrefs.GetFloat(GameData.BestScore)}"; // ������ �ȶ�
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
