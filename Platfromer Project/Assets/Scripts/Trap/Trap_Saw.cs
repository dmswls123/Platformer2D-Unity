using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;   // ��Ϲ����� �̵��� ��ġ�� ������ ����
    public float speed = 5f;
    public int moveIndex = 0;
    public bool OnGoingForward = true;
    private void Start()
    {
        anim = GetComponent<Animator>(); // �ִϸ��̼� �ʱ�ȭ
        isWorking = true;
    }

    private void Update()  // ��ǻ�� ���� ������ �޴´�.
    {
        anim.SetBool("isWorking", isWorking);
        MoveTrap();
    }

    private void MoveTrap()
    {
        // ��������� 0.0016��
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed*Time.deltaTime); // ��� ��ǻ�Ϳ��� �Ȱ��� �������� �����̰� �ϱ� ���ؼ� /Time.deltaTime�� ����� ��.

        // ���ǹ� - ������ ��ǥ�� �������� �����ߴ���?
        if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
        }
        
        // ���� ��ǥ ������ ������ moveInde=0���� �ض�.
        if(movePositions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
        
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}