using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern02 : MonoBehaviour
{
    public GameObject enemyPrefab;

    // �� ���� ��ȯ�� ���ΰ�?
    public int spawCount = 1;
    // �� �ʸ� �ֱ�� ������ ���ΰ�?
    public float spawCycle = 0.5f;

    private void Start()
    {
        StartCoroutine(SpawEnemy());
        //InvokeRepeating(nameof(CreateEnemyInstance), spawCycle, 1);
        //CreateEnemyInstance();
    }

    private void Update()
    {

    }

    IEnumerator SpawEnemy()  // �ڷ�ƾ ���
    {
        // ������ ���۵Ǳ� ���� ���带 �߰��� �� ����
        // ���� �˸�
        yield return new WaitForSeconds(1f);  // ���Ͻ������� �� ���½ð� 1��
        int repeatTime = 50;

        for (int i = 0; i <= repeatTime; i++)
        {
            CreateEnemyInstance(spawCount);
            yield return new WaitForSeconds(spawCycle);
        }

        gameObject.SetActive(false);

        //MainController.instance.GameSuccess();

    }
    private void CreateEnemyInstance(int count)
    {
        for (int i = 0; i < spawCount; i++)
        {
            float randomValue = Random.Range(-16, 16);
            Vector3 spawPosition = new Vector3(randomValue, 9, 0);
            Instantiate(enemyPrefab, spawPosition, Quaternion.identity);
        }
    }
}
