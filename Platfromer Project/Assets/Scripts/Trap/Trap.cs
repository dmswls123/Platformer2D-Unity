using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹�ϱ� ���ؼ��� �� ��ü �� �� ��ü�� Rigidbody

// �÷��̾�� �浹�ϸ� �浹���� ������ �̺�Ʈ(�����) �۵��Ѵ�.
public class Trap : MonoBehaviour
{
    // �浹 �̺�Ʈ�� �ۼ��� ��, ��� ������Ʈ�� ������� �ۼ��� ���� ���� ����.
    // ���� ���� �鿡���� ��ȿ����
    // �浹 �̺�Ʈ�� Ư�� ��� �۵��ϵ��� �±�(����ǥ) �޾��ش�. - ���� ������Ʈ �� ���� �±� ����.
    // Tag - ������ �浹 �̺�Ʈ���� ���
    // Layer - �̺�Ʈ�� �۵��� �� Ư�� ��� �з����ִ� ����. �� ������Ʈ�� �������� ���̾ ���� �� �� ����.
    // �׷� ������ ������ �� �� ����Ѵ�.
    // collider 2D�̰� Rigidbody 2D �����Ѵ�. �ʼ�����

    protected bool isWorking = false;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾� �±׸� ���� �ִ°�?
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player�� ������ �ǰ� ���� (collision �浹)");
        }
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Trap�� ������ �ǰ� ���� (Trigger�浹)");
        }
        
    }

}
