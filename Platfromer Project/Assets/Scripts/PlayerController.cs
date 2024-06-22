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
    [Header("플레이어 입력")]
    public float moveSpeed = 5f;  // 캐릭터의 이동 속도 변수
    public float JumpForce = 5f; // 캐릭터 점프
    private float moveInput; // 플레이어의 방향 및 인풋 데이터 저장 변수

    //public Transform startTransform; // 캐릭터가 시작할 위치를 저장하는 변수
    public Rigidbody2D rigidbody2D;  // 물리(강체) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded; // 땅위에 있는 상태인지 확인하는 불 변수 , true: 캐릭터 점프 할 수 있게 false: 점프 못하게
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    [Header("Flip")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = false;
    private int facingDirection = 1;

    [SerializeField] ParticleController particleController;

    public Animator animator;
    private bool isMove;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // 현재 내 위치 <= 새로운 x,y 저장하는 데이터 타입(현재 x좌표, 10 y좌표)
        //transform.position = new Vector2(transform.position.x, 10);

        InitializePlayerStatus();


    }

    void InitializePlayerStatus() // 최초 설정으로 변경해준다는 설정
    {

        // 현재 내 위치를 startTransform으로 변경
        //transform.position = startTransform.position;
        // 땅에 떨어지는 속도 설정
        rigidbody2D.velocity = Vector2.zero;
        // 왼쪽 보고 떨어져도 다시 처음 설정할때 오른쪽 바라보게
        facingRight = true;
        spriteRenderer.flipX = false;
        // 위에를 다 함으로써 기본 세팅값으로 돌아옴
    }

    // Update is called once per frame
    // 1프레임마다 한번 호출된다. 1프레임마다 호출된다는 뜻인 듯(반복 실행)
    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();
        FallDownCheck();
    }

    private void FallDownCheck()
    {
        // y의 높이가 특정 지점보다 낮을 때 낙사한 것으로 간주한다. => 충돌 체크 대체
        if (transform.position.y < -11)
        {
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : 현재 rigidbody 속도를 알려주는 것 속도가 0이면 움직이지 않는 상태, 0이 아니면 움직이고 있는 상태
        isMove = rigidbody2D.velocity.x != 0; 
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat 함수에 의해서 y최대일 때 1로 변환..  y 최소일 때 -1로 변환
        // 점프 키를 누르면 순간적으로 y 높이 증가, 중력에 의해서 점점 y의 속도가 -까지 내려감
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);  
    }

    /// <summary>
    /// 점프를 할 때 땅인지 아닌지 체크하는 기능 -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer); // 광선을 쏴서 ~머시기

        particleController.isGround = isGrounded;
    }
    /// <summary>
    ///  // 플레이어의 입력 값을 받아와야 함. a,d 키보드 좌 우 키를 눌렀을 때 -1 ~ 1 반환하는 클래스

    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioManager.Instance.PlaySFX(8);
            particleController.PlayParticle();
        }

        moveInput = Input.GetAxis("Horizontal"); // 수평에 있는 축 데이터 값을 받아오는 것
       
        JumpButton();
    }

    private void HandleFlip()
    {
        // 오른쪽 방향으로 바라보고 있을 때
        if(facingRight && moveInput < 0)
        {
            Flip();
        }
        // 왼쪽 방향으로 바라보고 있을 때
        else if(!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * - 1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y); // 방향키로 움직이는 것
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // 키가 눌러져있고, 땅위에 있을 때
        {
            // 점프: Y position _ rigidbody Y velocity를 점프 파워만큼 올려주면 됨
            Jump();
            
        }
    }

    private void Jump()
    {
        // 점프 사운드 출력
        // SFX 배열에 등록된 효과음 출력 숫자 2는 jmp1에 해당함.
        AudioManager.Instance.PlaySFX(2);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        particleController.PlayJumpParticle();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }

}
