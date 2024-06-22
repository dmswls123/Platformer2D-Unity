using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManageraudio : MonoBehaviour
{
    // 오디오소스 컴포넌트 추가
    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int i;

    // 현재 실행하고 있는 BGMIndex
    // 이벤트 함수 Start, Update 조건문

    void Start()
    {
        for (i = 0; i < bgm.Length; i++)
        {
            PlayBGM(i);
            Debug.Log($"현재노래: {bgm[i]}");
        }
    }

    void Update()
    {
        
    }

    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();
    }

}
