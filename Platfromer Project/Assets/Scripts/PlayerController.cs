using System;
using UnityEditor;
using UnityEngine;

//접근 지정자 public private protected /public으로 다 사용할 수 있다. 
public class PlayerController : MonoBehaviour
{
    //Monob~(상속)가 있기 때문에 밑에 함수 2개를 기본적으로 사용할 수 있다.
    // Start, Update 유니티 이벤트 함수의 같은 이름이 있는지 조사
    // 같은 이름이 있으면? 유니티에서 정해놓은 실행 시간에 그 함수를 실행

    // Start is called before the first frame update
    // 첫 프레임이 불러지기전에 (한번)시작한다.(위에 줄 번역) - 셋팅느낌, 젤 처음에만

    // 움직이기 위해서 필요한 것: 속도, 방향
    [Header("이동")]
    public float moveSpeed=5f;  // 캐릭터의 이동 속도 변수
    public float JumpForce = 5f; // 캐릭터 점프
    private float moveInput; // 플레이어의 방향 및 인풋 데이터 저장 변수

    public Transform startTransform; // 캐릭터가 시작할 위치를 저장하는 변수
    public Rigidbody2D rigidbody2D;  // 물리(강체) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded; // 땅위에 있는 상태인지 확인하는 불 변수 , true: 캐릭터 점프 할 수 있게 false: 점프 못하게
    public float groundDistance = 2f;
    public LayerMask groundLayer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("Hello Unity");
        // 현재 내 위치 <= 새로운 x,y 저장하는 데이터 타입(현재 x좌표, 10 y좌표)
        //transform.position = new Vector2(transform.position.x, 10);

        // 현재 내 위치를 startTransform으로 변경
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1프레임마다 한번 호출된다. 1프레임마다 호출된다는 뜻인 듯(반복 실행)
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer); // 광선을 쏴서 ~머시기
        
        // 플레이어의 입력 값을 받아와야 함
        moveInput = Input.GetAxis("Horizontal"); // 수평에 있는 축 데이터 값을 받아오는 것
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y); // 방향키로 움직이는 것

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true) // 키가 눌러져있고, 땅위에 있을 때
        {
            // 점프: Y position _ rigidbody Y velocity를 점프 파워만큼 올려주면 됨
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }

}
