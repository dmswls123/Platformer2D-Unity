using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patterns;

    // ������ ���� ��ȣ
    [Header("Current Pattern Info")]
    public int patternIndex = 0;
    public GameObject currentPattern;

    bool patternStart = true;

    void PatternStart()
    {
        ChangePattern();
        patternStart = false;
    }

    private void Awake()
    {
        foreach (var pattern in patterns)
        {
            pattern.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        
        if(patternStart == true && MainController.instance.isGameStart)
        {
            PatternStart();
        }

        if (MainController.instance.isGameStart && currentPattern.activeSelf == false)
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
