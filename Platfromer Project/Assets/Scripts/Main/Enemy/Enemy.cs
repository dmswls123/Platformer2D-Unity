using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    new Rigidbody2D rigidbody2D;
    //public GameObject uiMenu;


    void LoadComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        LoadComponents();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision�� ���̶� �浹�ϴ� �͵� (�Ű�����)

        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name}");

            //�÷��̾��� ü���� �������� ����

            // ü���� <=0 �� �� ������ ���� �޴��� �̵�����, ������ ������ �� ������ �� �ִ� UI ����
            MainController.instance.GameOver();
        }
        
    }

    

    
}
