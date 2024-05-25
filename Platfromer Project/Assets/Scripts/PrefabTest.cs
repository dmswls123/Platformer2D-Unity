using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    void Start()
    {
        // ������ ������, ������ ��ġ(Vector), ������Ʈ�� Rotation

        //Instantiate(prefab); // �������� ��ġ�� �⺻ ��ġ, ȸ�� ������ ������
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); //quternion.identiy => prefab�� �������ִ� ������ �����϶�
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))   //���ǿ� ���� �������� �����Ǵ� ��
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefab, spawnPosition.position, Quaternion.identity);
    }
}
