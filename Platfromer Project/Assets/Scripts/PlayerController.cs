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
    [Header("�̵�")]
    public float moveSpeed=5f;  // ĳ������ �̵� �ӵ� ����
    public float JumpForce = 5f; // ĳ���� ����
    private float moveInput; // �÷��̾��� ���� �� ��ǲ ������ ���� ����

    public Transform startTransform; // ĳ���Ͱ� ������ ��ġ�� �����ϴ� ����
    public Rigidbody2D rigidbody2D;  // ����(��ü) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded; // ������ �ִ� �������� Ȯ���ϴ� �� ���� , true: ĳ���� ���� �� �� �ְ� false: ���� ���ϰ�
    public float groundDistance = 2f;
    public LayerMask groundLayer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("Hello Unity");
        // ���� �� ��ġ <= ���ο� x,y �����ϴ� ������ Ÿ��(���� x��ǥ, 10 y��ǥ)
        //transform.position = new Vector2(transform.position.x, 10);

        // ���� �� ��ġ�� startTransform���� ����
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1�����Ӹ��� �ѹ� ȣ��ȴ�. 1�����Ӹ��� ȣ��ȴٴ� ���� ��(�ݺ� ����)
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer); // ������ ���� ~�ӽñ�
        
        // �÷��̾��� �Է� ���� �޾ƿ;� ��
        moveInput = Input.GetAxis("Horizontal"); // ���� �ִ� �� ������ ���� �޾ƿ��� ��
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y); // ����Ű�� �����̴� ��

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true) // Ű�� �������ְ�, ������ ���� ��
        {
            // ����: Y position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ� ��
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }

}
