using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffLayer : MonoBehaviour
{
   [SerializeField] float multiplier = 0.0f;//相对移动速率 近景应为负数 相机向左 近景相对更快向右移动
    [SerializeField] bool horizontalOnly = true;

    private Transform cameraTransform;

    public Vector3 absCameraPos;
    private Vector3 startPos;

    void Start()
    {
        SetupStartPositions();
    }

    void SetupStartPositions()
    {
        cameraTransform = Camera.main.transform;
        startPos = transform.position;
    }

    void LateUpdate()
    {
        UpdateParallaxPosition();
    }

    void UpdateParallaxPosition()
    {
        var position = startPos;
        position.x += multiplier * (cameraTransform.position.x - absCameraPos.x);

        if (!horizontalOnly)
        {
            position.y += multiplier * (cameraTransform.position.y - absCameraPos.y);//目前相机-初始相机=相机的位移 相对运动 近快远慢
        }

        transform.position = position;//
    }

}
