using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManageraudio : MonoBehaviour
{
    // ������ҽ� ������Ʈ �߰�
    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int i;

    // ���� �����ϰ� �ִ� BGMIndex
    // �̺�Ʈ �Լ� Start, Update ���ǹ�

    void Start()
    {
        for (i = 0; i < bgm.Length; i++)
        {
            PlayBGM(i);
            Debug.Log($"����뷡: {bgm[i]}");
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
