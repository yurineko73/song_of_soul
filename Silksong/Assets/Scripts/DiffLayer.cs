using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffLayer : MonoBehaviour
{
   [SerializeField] float multiplier = 0.0f;//����ƶ����� ����ӦΪ���� ������� ������Ը��������ƶ�
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
            position.y += multiplier * (cameraTransform.position.y - absCameraPos.y);//Ŀǰ���-��ʼ���=�����λ�� ����˶� ����Զ��
        }

        transform.position = position;//
    }

}
