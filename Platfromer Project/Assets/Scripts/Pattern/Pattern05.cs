using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern05 : MonoBehaviour
{
    public Transform startPos;       // 원을 방사할 위치
    public int bulletCount;          // 탄만의 갯수
    public float bulletSpeed;        // 탄막의 속도
    public GameObject bulletPrefab;  // 탄막 프리팹

    private int MaxBulletCount;      // 패턴 종료를 파악하기 위한 변수

    private void Awake()
    {
        MaxBulletCount = bulletCount;
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(SpawEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawEnemy());
    }
    IEnumerator SpawEnemy()  // 코루틴 사용
    {
        int count = 0;
        
        yield return new WaitForSeconds(1f);  // 패턴시작했을 때 쉬는시간 1초

        while (count < MaxBulletCount)
        {
            CircleEmit();
            count++;
            yield return new WaitForSeconds(1f);
        }

        PlayerController player = gameObject.GetComponent<PlayerController>();

        if (player.currentHp > 0) // 오류남 게임 종료가 안됨
        {
            GameManager.instance.gameClear = true;
            GameManager.instance.GameClear();
        }
        
    }

    void CircleEmit()
    {
        float angle = 360 / (float)bulletCount;  // 30개, 12도

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, startPos.position, Quaternion.identity);

            float bulletAngle = angle * i; // 12도, 24도, 36도...
            float x = Mathf.Cos(bulletAngle * Mathf.PI / 180);
            float y = Mathf.Sin(bulletAngle * Mathf.PI / 180);

            // 각도로 부터 원점에서 시야 각도의 vector2 값을 구하는 공식
            bullet.GetComponent<MovementTransform2D>().MoveSpeed(bulletSpeed);
            bullet.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x,y));
        }
    }
}
