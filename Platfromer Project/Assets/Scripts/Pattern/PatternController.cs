using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patterns;

    // ������ ���� ��ȣ
    [Header("Current Pattern Info")]
    public int patternIndex = 0;
    public GameObject currentPattern;

    void Start()
    {
        foreach(var pattern in patterns)
        {
            pattern.gameObject.SetActive(false);
        }

        ChangePattern();
    }

    private void Update()
    {
        if (currentPattern.activeSelf == false)
        {
            ChangePattern();
        }

        // GamePattern
    }

    public void ChangePattern()
    {
        currentPattern = patterns[patternIndex]; // patterns �迭�� ����ִ� ���ӿ�����Ʈ�� ������ ������
        currentPattern.SetActive(true);

        patternIndex++;

        if(patternIndex >= patterns.Length)
        {
            patternIndex = 0;
        }

    }
    
}
