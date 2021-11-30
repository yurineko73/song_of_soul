using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// /���������˺��� ����������������damager ����ˮ  ������δʵ�� 
/// </summary>���ߣ����
public class RebornDamager:TwoTargetDamager
{
    public LayerMask rebornLayer;
    void Start()
    {
    }

    protected  override void makeDamage(DamageableBase damageable)
    {
        base.makeDamage(damageable);
        if(rebornLayer.Contains(damageable.gameObject) && (damageable as HpDamable).currentHp>0 )
        {
            GameObjectTeleporter.playerReborn();
        }
    }
}
