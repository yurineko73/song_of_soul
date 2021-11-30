using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// ������Ŀ�겻ͬ�˺���damager�Ļ���   ������ˮ,��ҵĹ���
/// </summary>���ߣ����
public class TwoTargetDamager : DamagerBase
{
    public LayerMask hittableLayers2;//��һĿ��
    public int damage2;//����һĿ����˺�


    public override int getDamage(DamageableBase target)//����Ŀ�귵���˺�
    {
        if (hittableLayers2.Contains(target.gameObject))
        {
            return damage2;
        }
        else
        {
            return damage;
        }
    }

    protected override void makeDamage(DamageableBase Damageable)
    {
        makeDamageEvent.Invoke(this, Damageable);
    }

}
