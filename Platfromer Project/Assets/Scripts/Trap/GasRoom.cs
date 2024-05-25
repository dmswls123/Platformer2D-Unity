using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasRoom : MonoBehaviour
{
    private bool isGasState=false;
    //Player�� �˾ƾ� �� �ʿ伺�� �ְ���. PlayerController <-�ٸ� Ŭ�������� ���� Ŭ������ ��� ������ ���ΰ�?

    public float checkTime = 2f;
    public float Timer = 0;
    private int PlayerHP = 100;    //�ڱ��忡 �� �ִ� ���¶��... �÷��̾��� ü���� 1�� ���� ��Ų��.
    private int Damage = 1;

    public bool isStayOn = true;

    // Debug.Log(���� ��Ȳ ���)
    // Tag�� ����ؼ� Palyer�� �۵�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = true;                                            
            Debug.Log($"�÷��̾ ���� ���� ���� ����: {isGasState}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = false;
            Debug.Log($"�÷��̾ ���� ���� ���� ����: {isGasState}");
        }
    }

    private void Update() // PlayerController�� Update���� �ۼ���Ű�°� ������
    {
        // ���� �ð��� ���� Time.deltaTime
        Timer += Time.deltaTime; //0.016 ��ǻ�͸��� �ٸ���. 1Frame �����ϴ� �ð���
        if (Timer >= checkTime)
        {
            Timer = 0;
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"�÷��̾��� ����ü��: {PlayerHP}"); //{}���� �濡 ���� ���� ���� �ۼ��Ѵ�. ü���� ���̴� ������ ���÷� �ۼ��Ͽ���.
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            Debug.Log($"�÷��̾ ���� �����̹Ƿ� �÷��̾��� ü���� ���� ��Ű�� �ִ�.");
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"�÷��̾��� ����ü��: {PlayerHP}");
        }
    }

   


}
