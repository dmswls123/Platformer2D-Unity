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
    public PlayerUi PlayerUI;


    void LoadComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        PlayerUI = FindObjectOfType<PlayerUi>();
    }

    private void Awake()
    {
        LoadComponents();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision은 벌이랑 충돌하는 것들 (매개변수)

        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name}");

            //플레이어의 체력이 떨어지는 로직

            // 체력이 <=0 일 때 게임을 메인 메뉴로 이동할지, 게임을 종료할 지 선택할 수 있는 UI 띄우기
            // 플레이어 체력을 접근해서, 플레이어 체력과 비교

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            player.currentHp = player.currentHp - 1;
            PlayerUI.SliderValueChange((float)player.currentHp/player.maxHp);
            if (player.currentHp<=0)
            {
                MainController.instance.GameOver();
            }
        }
        
    }

    

    
}
