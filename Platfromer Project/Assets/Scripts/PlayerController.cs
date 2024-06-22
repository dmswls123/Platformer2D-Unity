using System;
using UnityEditor;
using UnityEngine;

//���� ������ public private protected /public���� �� ����� �� �ִ�. 
public class PlayerController : MonoBehaviour
{
    //Monob~(���)�� �ֱ� ������ �ؿ� �Լ� 2���� �⺻������ ����� �� �ִ�.
    // Start, Update ����Ƽ �̺�Ʈ �Լ��� ���� �̸��� �ִ��� ����
    // ���� �̸��� ������? ����Ƽ���� ���س��� ���� �ð��� �� �Լ��� ����

    // Start is called before the first frame update
    // ù �������� �ҷ��������� (�ѹ�)�����Ѵ�.(���� �� ����) - ���ô���, �� ó������

    // �����̱� ���ؼ� �ʿ��� ��: �ӵ�, ����
    [Header("�÷��̾� �Է�")]
    public float moveSpeed = 5f;  // ĳ������ �̵� �ӵ� ����
    public float JumpForce = 5f; // ĳ���� ����
    private float moveInput; // �÷��̾��� ���� �� ��ǲ ������ ���� ����

    //public Transform startTransform; // ĳ���Ͱ� ������ ��ġ�� �����ϴ� ����
    public Rigidbody2D rigidbody2D;  // ����(��ü) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded; // ������ �ִ� �������� Ȯ���ϴ� �� ���� , true: ĳ���� ���� �� �� �ְ� false: ���� ���ϰ�
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
        // ���� �� ��ġ <= ���ο� x,y �����ϴ� ������ Ÿ��(���� x��ǥ, 10 y��ǥ)
        //transform.position = new Vector2(transform.position.x, 10);

        InitializePlayerStatus();


    }

    void InitializePlayerStatus() // ���� �������� �������شٴ� ����
    {

        // ���� �� ��ġ�� startTransform���� ����
        //transform.position = startTransform.position;
        // ���� �������� �ӵ� ����
        rigidbody2D.velocity = Vector2.zero;
        // ���� ���� �������� �ٽ� ó�� �����Ҷ� ������ �ٶ󺸰�
        facingRight = true;
        spriteRenderer.flipX = false;
        // ������ �� �����ν� �⺻ ���ð����� ���ƿ�
    }

    // Update is called once per frame
    // 1�����Ӹ��� �ѹ� ȣ��ȴ�. 1�����Ӹ��� ȣ��ȴٴ� ���� ��(�ݺ� ����)
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
        // y�� ���̰� Ư�� �������� ���� �� ������ ������ �����Ѵ�. => �浹 üũ ��ü
        if (transform.position.y < -11)
        {
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : ���� rigidbody �ӵ��� �˷��ִ� �� �ӵ��� 0�̸� �������� �ʴ� ����, 0�� �ƴϸ� �����̰� �ִ� ����
        isMove = rigidbody2D.velocity.x != 0; 
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat �Լ��� ���ؼ� y�ִ��� �� 1�� ��ȯ..  y �ּ��� �� -1�� ��ȯ
        // ���� Ű�� ������ ���������� y ���� ����, �߷¿� ���ؼ� ���� y�� �ӵ��� -���� ������
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);  
    }

    /// <summary>
    /// ������ �� �� ������ �ƴ��� üũ�ϴ� ��� -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer); // ������ ���� ~�ӽñ�

        particleController.isGround = isGrounded;
    }
    /// <summary>
    ///  // �÷��̾��� �Է� ���� �޾ƿ;� ��. a,d Ű���� �� �� Ű�� ������ �� -1 ~ 1 ��ȯ�ϴ� Ŭ����

    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioManager.Instance.PlaySFX(8);
            particleController.PlayParticle();
        }

        moveInput = Input.GetAxis("Horizontal"); // ���� �ִ� �� ������ ���� �޾ƿ��� ��
       
        JumpButton();
    }

    private void HandleFlip()
    {
        // ������ �������� �ٶ󺸰� ���� ��
        if(facingRight && moveInput < 0)
        {
            Flip();
        }
        // ���� �������� �ٶ󺸰� ���� ��
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
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y); // ����Ű�� �����̴� ��
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // Ű�� �������ְ�, ������ ���� ��
        {
            // ����: Y position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� ��
            Jump();
            
        }
    }

    private void Jump()
    {
        // ���� ���� ���
        // SFX �迭�� ��ϵ� ȿ���� ��� ���� 2�� jmp1�� �ش���.
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
