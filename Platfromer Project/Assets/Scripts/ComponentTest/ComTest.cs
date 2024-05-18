using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{
    // Awake -> OnEnable -> Start ������ �������(���� �ʹݿ� �� ��)
    // �ڵ��� �帧
    //-------------------------�ʱ�ȭ �Լ� �ǽ�-----------------------------------
    // �ѹ��� �����
    public GameObject TestObject;
    // NullReference����: ������ �����Ͱ� ��� �߻��ϴ� ������. �ذ��ϱ� ���ؼ� ������ �ʱ�ȭ(�ʱ�ȭ�� ���� ó�� ����Ǵ� �Լ��� �ʱ�ȭ �ؾߵ�)
    // ����(�ʱ�ȭ) �̺�Ʈ �Լ��� ������ ������ �Ҵ��ϴ� �۾�
    private void Awake()
    {
        Debug.Log("Awake ����");
        TestObject = new GameObject(); // �ʱ�ȭ �ϴ� �۾���
        
    }

    private void Start()
    {
        Debug.Log("Start ����");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable ����");
    }

    //-------------������Ʈ �Լ��ǽ�-------------------------------------------------------------------
    // ������Ʈ�� ��� ����� (�����̱� ����), �ݺ������̶�� �����ϼ�

    private void FixedUpdate() // ������ �ð��� ���� ȣ��
    {
        Debug.Log("FixedUpdate ����");
    }
    private void Update() // ȭ�鿡 �̹����� ����(Frame) �������� ȣ��
    {
        Debug.Log("Update ����");
    }

    private void LateUpdate() // Update�Լ� ���Ŀ� ����Ǵ� �Լ�
    {
        Debug.Log("LateUpdate ����");
    }
}
