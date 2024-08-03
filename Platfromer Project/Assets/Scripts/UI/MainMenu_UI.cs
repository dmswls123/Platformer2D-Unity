using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestScoreText;

    public void Update()
    {
        levelText.text = GameManager.instance.ReturnCurrentDifficulty();
        currentTimeText.text = GameManager.instance.score.ToString();
        bestScoreText.text = $"최고 점수: {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1); //빌드 셋팅에 배열 1에 해당하는 씬을 로드
    }

    public void SwitchMenuTo(GameObject uiMenu)
        //버튼에 연결시킬 함수 이름(MainMenu_UI닫고, 원하는 UI 연다)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            //MainMenu 하위의 자식들을 전부 비활성화 시켜라
        }
        uiMenu.SetActive(true); //대상 오브젝트를 활성화 시켜라

    }

    public void GameExit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

    }

    public void SetGamelevel(int level)
    {
        GameManager.instance.difficulty = level;
        GameManager.instance.SaveGameDifficulty();
    }


}
