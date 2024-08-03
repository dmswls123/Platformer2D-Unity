using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern05 : MonoBehaviour
{
    public Transform startPos;       // ���� ����� ��ġ
    public int bulletCount;          // ź���� ����
    public float bulletSpeed;        // ź���� �ӵ�
    public GameObject bulletPrefab;  // ź�� ������

    private int MaxBulletCount;      // ���� ���Ḧ �ľ��ϱ� ���� ����

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
    IEnumerator SpawEnemy()  // �ڷ�ƾ ���
    {
        int count = 0;
        
        yield return new WaitForSeconds(1f);  // ���Ͻ������� �� ���½ð� 1��

        while (count < MaxBulletCount)
        {
            CircleEmit();
            count++;
            yield return new WaitForSeconds(1f);
        }

        PlayerController player = gameObject.GetComponent<PlayerController>();

        if (player.currentHp > 0) // ������ ���� ���ᰡ �ȵ�
        {
            GameManager.instance.gameClear = true;
            GameManager.instance.GameClear();
        }
        
    }

    void CircleEmit()
    {
        float angle = 360 / (float)bulletCount;  // 30��, 12��

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, startPos.position, Quaternion.identity);

            float bulletAngle = angle * i; // 12��, 24��, 36��...
            float x = Mathf.Cos(bulletAngle * Mathf.PI / 180);
            float y = Mathf.Sin(bulletAngle * Mathf.PI / 180);

            // ������ ���� �������� �þ� ������ vector2 ���� ���ϴ� ����
            bullet.GetComponent<MovementTransform2D>().MoveSpeed(bulletSpeed);
            bullet.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x,y));
        }
    }
}
