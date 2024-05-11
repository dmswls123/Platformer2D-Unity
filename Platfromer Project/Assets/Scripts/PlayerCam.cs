using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ������ �������� ����

    Vector3 offset;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ���� -> A - B: B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ��
        transform.position = playerTransform.position + offset;
        // �÷��̾ ������ ����
        offset = transform.position - playerTransform.position;
    }
}