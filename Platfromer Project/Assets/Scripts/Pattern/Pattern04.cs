using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04 : MonoBehaviour
{
    public GameObject warningSign;
    public GameObject enemyPrefab;

    

    // �� ���� ��ȯ�� ���ΰ�?
    public int spawCount = 1;
    // �� �ʸ� �ֱ�� ������ ���ΰ�?
    public float spawCycle = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawEnemy());
        //InvokeRepeating(nameof(CreateEnemyInstance), spawCycle, 1);
        //CreateEnemyInstance();
    }

    private void OnDisable()
    {
        StopCoroutine(SpawEnemy());
    }

    private void Update()
    {

    }

    IEnumerator SpawEnemy()  // �ڷ�ƾ ���
    {
        Vector3 spawnPos = new Vector3(-12, 1.5f, 0);
        GameObject warning =Instantiate(warningSign, spawnPos, Quaternion.identity);
        // ������ ���۵Ǳ� ���� ���带 �߰��� �� ����
        // ���� �˸�
        yield return new WaitForSeconds(1f);  // ���Ͻ������� �� ���½ð� 1��
        int repeatTime = 1;

        for (int i = 0; i < repeatTime; i++)
        {
            CreateEnemyInstance(spawCount);
            yield return new WaitForSeconds(spawCycle);
        }

        Destroy(warning);

        gameObject.SetActive(false);

        
        

    }
    private void CreateEnemyInstance(int count)
    {
        for (int i = 0; i < spawCount; i++)
        {
            Vector3 spawPosition = new Vector3(-12, 6.5f, 0);
            Instantiate(enemyPrefab, spawPosition, Quaternion.identity);
        }
    }
}
