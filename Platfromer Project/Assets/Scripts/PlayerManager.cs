using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab; 
    [SerializeField] public Transform spawnTransform; // Check Point, Save Point 시작 위치 변경해주는 기능

    private PlayerController playerController;     //playerController에서 빠진 컴포넌트들을 추가해줘야 함
    [SerializeField] public PlayerCam playerCam;   // playerCam 클래스에 접근. RespawnPlayer에서 playerCam 접근할 수 있게 코드 작성
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
        // 만약 player 변수가 null이면 respawn해라.
    }
    private void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);

        playerController=player.GetComponent<PlayerController>(); //다른 코드에 접근하는 방법
        playerCam.playerTransform = player.transform;
        playerCam.SetOffset();
    }
}
