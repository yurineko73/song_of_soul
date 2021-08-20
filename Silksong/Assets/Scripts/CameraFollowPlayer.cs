using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour//����main camera��
{
    public SceneManger sceneManger;
    public GameObject player;
    public float cameraWidth;//������ ��size�͵�ǰ��Ļ�������� ��size=5.4���ֱ���Ϊ1920*1080��cameraWidth=5.4*1920/1080=9.6
    private Camera mainCamera;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = player.transform.position - transform.position;//����ҵķ���
        transform.Translate(getFollowDir(playerDir));
    }

    Vector2 getFollowDir(Vector2 playerDir)//����ҵ��ﳡ���߽磬�������Ҫ�ڶ�Ӧ�����ƶ�
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
