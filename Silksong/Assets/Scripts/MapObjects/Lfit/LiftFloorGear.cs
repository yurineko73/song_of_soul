using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ݸ���¥��Ļ���
/// </summary>���ߣ����
public class LiftFloorGear : Damable
{
    public int floor;
    public Lift lift;
    public BoxCollider2D floorCollider;//�õ��ݿ������ڵ������ײ��
    public float floorHeight;//����߶� ���ڶ������
    void Start()
    {
        lift.gears[floor - 1] = this;//��¥��˳�����Ӧ��������

        //����collider���õ���߶�
        float floorDistance = floorCollider.offset.y;
        floorDistance += (floorCollider.size.y / 2);
        floorDistance *= floorCollider.transform.lossyScale.y;
        floorHeight = floorCollider.transform.position.y + floorDistance;
    }
    public override void takeDamage(DamagerBase damager)
    {
        base.takeDamage(damager);

        if (lift.currentFloor == floor)
            return;

        lift.setTargetFloor(floor);
    }

}
