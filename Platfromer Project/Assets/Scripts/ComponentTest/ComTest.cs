using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{
    // Awake -> OnEnable -> Start 순서로 실행됐음(제일 초반에 할 때)
    // 코드의 흐름
    //-------------------------초기화 함수 실습-----------------------------------
    // 한번만 실행됨
    public GameObject TestObject;
    // NullReference에러: 변수에 데이터가 없어서 발생하는 에러다. 해결하기 위해서 데이터 초기화(초기화는 제일 처음 실행되는 함수에 초기화 해야됨)
    // 생성(초기화) 이벤트 함수에 데이터 변수를 할당하는 작업
    private void Awake()
    {
        Debug.Log("Awake 실행");
        TestObject = new GameObject(); // 초기화 하는 작업임
        
    }

    private void Start()
    {
        Debug.Log("Start 실행");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 실행");
    }

    //-------------업데이트 함수실습-------------------------------------------------------------------
    // 업데이트는 계속 실행됨 (갱신이기 때문), 반복실행이라고 생각하셈

    private void FixedUpdate() // 고정된 시간에 따라 호출
    {
        Debug.Log("FixedUpdate 실행");
    }
    private void Update() // 화면에 이미지를 생성(Frame) 단위마다 호출
    {
        Debug.Log("Update 실행");
    }

    private void LateUpdate() // Update함수 직후에 실행되는 함수
    {
        Debug.Log("LateUpdate 실행");
    }
}
