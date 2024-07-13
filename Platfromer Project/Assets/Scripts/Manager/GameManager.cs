using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱���
    public static GameManager instance; //GameManager.instance
    public int difficulty; // 0: ����, 1:�븻, 2:�ϵ� �� �����Ұ���
    public float score; 

    private void Update()
    {
        score += Time.deltaTime * (difficulty+1);
        if (Input.GetKeyDown(KeyCode.S)) // Ű������ s������ �� true // gameOver.. �÷��̾ �׾��� ��
        {
            if(score > PlayerPrefs.GetFloat(GameData.BestScore)) // ��������, bestscore �������� Ŭ���� ����
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }
    }

    private void Awake()
    {
        if(instance == null) //�ν��Ͻ��� ���ٸ�?
        {
            instance = this; //���Ӹ޴����� �־��ִ� ��
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey(GameData.GameDifficulty)) //Haskey"Ű��"������ false, true
            difficulty = PlayerPrefs.GetInt(GameData.GameDifficulty);

    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
        {
            case 0: name = "����";
                break;
            case 1: name = "����";
                break;
            case 2: name = "�����";
                break;
            default: name = $"Ű: {difficulty} �������� �ʴ� Ű ���Դϴ�.";
                break;
        }
        return $"������ ���̵�: {name}";
    }

    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty); // GameDifficulty �̸�����, difficulty����(������ ����) ����
        
    }


}
