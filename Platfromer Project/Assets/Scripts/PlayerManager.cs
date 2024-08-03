using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab; 
    [SerializeField] public Transform spawnTransform; // Check Point, Save Point ���� ��ġ �������ִ� ���

    private PlayerController playerController;     //playerController���� ���� ������Ʈ���� �߰������ ��
    [SerializeField] public PlayerCam playerCam;   // playerCam Ŭ������ ����. RespawnPlayer���� playerCam ������ �� �ְ� �ڵ� �ۼ�
    //public Transform playerTransform;

    private GameObject player;
    void Start()
    {
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }
        /*if(player != null)
        {
            RespawnPlayer();
        }*/
        // ���� player ������ null�̸� respawn�ض�.
    }
    private void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);

        playerController=player.GetComponent<PlayerController>(); //�ٸ� �ڵ忡 �����ϴ� ���
        playerCam.playerTransform = player.transform;
        playerCam.SetOffset();
    }
}
