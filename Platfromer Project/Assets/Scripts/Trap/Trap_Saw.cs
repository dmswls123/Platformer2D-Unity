using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;   // 톱니바퀴가 이동할 위치를 저장할 변수
    public float speed = 5f;
    public int moveIndex = 0;
    public bool OnGoingForward = true;
    public bool IsTrapOn=true;
    public float stoptime=1f;
    private void Start()
    {
        anim = GetComponent<Animator>(); // 애니메이션 초기화
        isWorking = true;
    }

    private void Update()  // 컴퓨터 성능 영향을 받는다.
    {
        anim.SetBool("isWorking", isWorking);

        //코루틴은 업데이트문에 넣으면 안됨
        //IsTrapOn에 따라 MoveTrap을 실행
        if (IsTrapOn==true) 
        { 
            MoveTrap();
        }
    }

    IEnumerator CoMoveTrap()
    {
        IsTrapOn = false;
        yield return new WaitForSeconds(stoptime);
        IsTrapOn = true;
    }

    private void MoveTrap()
    {
        // 평균적으로 0.0016값
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed*Time.deltaTime); // 모든 컴퓨터에서 똑같은 조건으로 움직이게 하기 위해서 /Time.deltaTime을 해줘야 함.

        // 조건문 - 함정이 목표한 지점까지 도착했는지?
        if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
            StartCoroutine(CoMoveTrap());
        }
        
        // 다음 목표 지점이 없으면 moveInde=0으로 해라.
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

        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
