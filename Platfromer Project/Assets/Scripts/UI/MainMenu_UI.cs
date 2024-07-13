using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        bestScoreText.text = $"�ְ� ����: {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1); //���� ���ÿ� �迭 1�� �ش��ϴ� ���� �ε�
    }

    public void SwitchMenuTo(GameObject uiMenu)
        //��ư�� �����ų �Լ� �̸�(MainMenu_UI�ݰ�, ���ϴ� UI ����)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            //MainMenu ������ �ڽĵ��� ���� ��Ȱ��ȭ ���Ѷ�
        }
        uiMenu.SetActive(true); //��� ������Ʈ�� Ȱ��ȭ ���Ѷ�

    }

    public void SetGamelevel(int level)
    {
        GameManager.instance.difficulty = level;
        GameManager.instance.SaveGameDifficulty();
    }


}