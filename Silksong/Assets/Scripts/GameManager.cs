using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<GameManager>();

            if (instance != null)
                return instance;

            GameObject sceneControllerGameObject = new GameObject("GameManager");
            instance = sceneControllerGameObject.AddComponent<GameManager>();

            return instance;
        }
    }//����

    protected static GameManager instance;


    public GameObject player;
    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        creatPlayer();
        GameObjectTeleporter.playerEnterScene(SceneEntrance.EntranceTag.A);
    }

    /// <summary>
    /// ������Ϸ����ʱ�������
    /// </summary>
    public void creatPlayer()
    {
        Instantiate(player);
    }
}
