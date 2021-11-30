using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����������ƶ��Ŀ���
/// </summary>���ߣ����
public class LfitMoveButton :Damable
{
    public bool goUp;//�Ƿ������ϰ�ť ��������
    public Lift lift;

    public override void takeDamage(DamagerBase damager)
    {
        base.takeDamage(damager);

        if(goUp)
        {
            int upFloor = (int)Mathf.Floor(lift.currentFloor) + 1;
            if (upFloor > lift.maxFloor)
                return;
            lift.setTargetFloor(upFloor);
        }
        else
        {
            int downFloor = (int)Mathf.Ceil(lift.currentFloor) - 1;
            if (downFloor <=0)
                return;
            lift.setTargetFloor(downFloor);
        }
    }
}
