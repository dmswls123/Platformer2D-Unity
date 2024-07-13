using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager instance; //GameManager.instance
    public int difficulty; // 0: 이지, 1:노말, 2:하드 로 설정할거임
    public float score; 

    private void Update()
    {
        score += Time.deltaTime * (difficulty+1);
        if (Input.GetKeyDown(KeyCode.S)) // 키보드의 s눌렀을 때 true // gameOver.. 플레이어가 죽었을 때
        {
            if(score > PlayerPrefs.GetFloat(GameData.BestScore)) // 현재점수, bestscore 점수보다 클때만 저장
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }
    }

    private void Awake()
    {
        if(instance == null) //인스턴스가 없다면?
        {
            instance = this; //게임메니저를 넣어주는 것
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey(GameData.GameDifficulty)) //Haskey"키값"없으면 false, true
            difficulty = PlayerPrefs.GetInt(GameData.GameDifficulty);

    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
        {
            case 0: name = "쉬움";
                break;
            case 1: name = "보통";
                break;
            case 2: name = "어려움";
                break;
            default: name = $"키: {difficulty} 존재하지 않는 키 값입니다.";
                break;
        }
        return $"선택한 난이도: {name}";
    }

    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty); // GameDifficulty 이름으로, difficulty변수(정수형 변수) 저장
        
    }


}
