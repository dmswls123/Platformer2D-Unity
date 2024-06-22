using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movemenParticle;
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] ParticleSystem my_PS;
    [SerializeField] ParticleSystem self_SP;

    // 플레이어의 속도에 따라 파티클을 생성하는 제어 조건
    [SerializeField] int occurAfterVelocity;
    // 먼지의 생성 주기
    [SerializeField] float dustFormationTIme;

    [SerializeField] Rigidbody2D playerRb;
    float counter; // 먼지 생성 주기를 체크 위한 시간변수
    public bool isGround; // 플레이어의 점프 상태를 체크하기 위한 변수

    private void Update()
    {
        CheckAfterVelocity();
    }

    public void PlayParticle()
    {
        my_PS.Play();
    }

    public void PlayJumpParticle()
    {
        self_SP.Play();
    }


    private void CheckAfterVelocity()
    {
        counter += Time.deltaTime;
        if (isGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            CheckDustFormationTime();
        }
    }

    private void CheckDustFormationTime()
    {
        if (counter > dustFormationTIme)
        {
            movemenParticle.Play();
            counter = 0;
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            jumpParticle.Play();
            isGround = true;
        }
    }
}
