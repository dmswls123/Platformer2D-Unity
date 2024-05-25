using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    void Start()
    {
        // 생성할 프리팹, 생성할 위치(Vector), 오브젝트의 Rotation

        //Instantiate(prefab); // 프리팹의 위치는 기본 위치, 회전 값으로 생성됨
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); //quternion.identiy => prefab이 가지고있는 각도로 생성하라
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))   //조건에 따라서 프리팹이 생성되는 것
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefab, spawnPosition.position, Quaternion.identity);
    }
}
