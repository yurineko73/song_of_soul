using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour//挂在main camera上
{
    public SceneManger sceneManger;
    public GameObject player;
    public float cameraWidth;//相机宽度 由size和当前屏幕比例决定 如size=5.4，分辨率为1920*1080，cameraWidth=5.4*1920/1080=9.6
    private Camera mainCamera;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = player.transform.position - transform.position;//到玩家的方向
        transform.Translate(getFollowDir(playerDir));
    }

    Vector2 getFollowDir(Vector2 playerDir)//如玩家到达场景边界，相机不需要在对应方向移动
    {
        if (player.transform.position.x > sceneManger.SceneHalfWidth - cameraWidth
            || player.transform.position.x < cameraWidth - sceneManger.SceneHalfWidth)
        {
            playerDir.x = 0;
        }
          if (player.transform.position.y > sceneManger.SceneHalfHeight - mainCamera.orthographicSize
            || player.transform.position.y < mainCamera.orthographicSize - sceneManger.SceneHalfHeight)
        {
            playerDir.y = 0;
        }
        return playerDir;
    }
}
