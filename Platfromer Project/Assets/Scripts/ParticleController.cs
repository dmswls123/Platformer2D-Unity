using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movemenParticle;
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] ParticleSystem my_PS;
    [SerializeField] ParticleSystem self_SP;

    // �÷��̾��� �ӵ��� ���� ��ƼŬ�� �����ϴ� ���� ����
    [SerializeField] int occurAfterVelocity;
    // ������ ���� �ֱ�
    [SerializeField] float dustFormationTIme;

    [SerializeField] Rigidbody2D playerRb;
    float counter; // ���� ���� �ֱ⸦ üũ ���� �ð�����
    public bool isGround; // �÷��̾��� ���� ���¸� üũ�ϱ� ���� ����

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
