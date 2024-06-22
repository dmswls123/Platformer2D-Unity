using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // 오디오소스 컴포넌트 추가
    public AudioSource[] sfx;
    public AudioSource[] bgm;  //Length

    // 현재 실행하고 있는 BGMIndex
    public int bgmIndex = 0;
    public int sfxIndex = 0;
    //이벤트 함수 Start, Update 조건문

    private void Awake()
    {
        if (Instance== null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //Debug.Log(bgm.Length);
        //PlayBGM(bgmIndex);
        //PlayRandomBGM();
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            PlayRandomBGM();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayRandomSFX();
        }*/
    }

    public void PlayBGM(int bgmIndex) //bgmIndex에 해당하는 BGM 실행하는 함수
    {
        bgm[bgmIndex].Play();
    }
    public void PlaySFX(int sfxIndex) //sfx.Lenth 큰 수 받으면 배열초과 에러가 발생한다.
    {
        if (sfxIndex < sfx.Length)
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
        }
    }


    public void StopBGM() // 현재 실행 중인 BGM을 멈추는 함수
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    
    private void StopSFX()
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].Stop();
        }
    }
    public void PlayRandomBGM()
    {
        StopBGM();
        // bgmIndex가 랜덤한 값을 가지고, 그 값을 실행하면 됨
        int randomIndex = Random.Range(0, bgm.Length);
        PlayBGM(randomIndex);
    }
    public void PlayRandomSFX()
    {
        StopSFX();
        // sfxIndex가 랜덤한 값을 가지고, 그 값을 실행하면 됨
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }
}
