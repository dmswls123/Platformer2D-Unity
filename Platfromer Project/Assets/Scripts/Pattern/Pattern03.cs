using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    public GameObject enemyPrefab;

    // 몇 마리 소환할 것인가?
    public int spawCount = 1;
    // 몇 초를 주기로 생성할 것인가?
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

    IEnumerator SpawEnemy()  // 코루틴 사용
    {
        // 패턴이 시작되기 전에 사운드를 추가할 수 있음
        // 전조 알림
        yield return new WaitForSeconds(1f);  // 패턴시작했을 때 쉬는시간 1초
        int repeatTime = 5;

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
            float randomValue = Random.Range(-6, -5);
            Vector3 spawPosition = new Vector3(-16, randomValue, 0);
            Instantiate(enemyPrefab, spawPosition, Quaternion.identity);
        }
    }
}
