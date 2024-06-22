using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // ������ҽ� ������Ʈ �߰�
    public AudioSource[] sfx;
    public AudioSource[] bgm;  //Length

    // ���� �����ϰ� �ִ� BGMIndex
    public int bgmIndex = 0;
    public int sfxIndex = 0;
    //�̺�Ʈ �Լ� Start, Update ���ǹ�

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

    public void PlayBGM(int bgmIndex) //bgmIndex�� �ش��ϴ� BGM �����ϴ� �Լ�
    {
        bgm[bgmIndex].Play();
    }
    public void PlaySFX(int sfxIndex) //sfx.Lenth ū �� ������ �迭�ʰ� ������ �߻��Ѵ�.
    {
        if (sfxIndex < sfx.Length)
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
        }
    }


    public void StopBGM() // ���� ���� ���� BGM�� ���ߴ� �Լ�
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
        // bgmIndex�� ������ ���� ������, �� ���� �����ϸ� ��
        int randomIndex = Random.Range(0, bgm.Length);
        PlayBGM(randomIndex);
    }
    public void PlayRandomSFX()
    {
        StopSFX();
        // sfxIndex�� ������ ���� ������, �� ���� �����ϸ� ��
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }
}
