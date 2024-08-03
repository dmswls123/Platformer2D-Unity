using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patterns;

    // 시작할 패턴 번호
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
        currentPattern = patterns[patternIndex]; // patterns 배열에 담겨있는 게임오브젝트로 패턴을 관리함
        currentPattern.SetActive(true);

        patternIndex++;

        if(patternIndex >= patterns.Length)
        {
            patternIndex = 0;
        }

    }
    
}
