using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
///ֻ������һ��������˺� �������� �����������
/// </summary>���ߣ����
public class OneDirectDamable : HpDamable
{
    public bool leftInvulnerable;//��ߵ��˺���Ч ��Ϊfalse���ұߵ��˺���Ч
    public override void takeDamage(DamagerBase damager)
    {

       // hittedEffect();
        damageDirection = damager.transform.position - transform.position;
        if ((leftInvulnerable && damageDirection.x < 0) || (!leftInvulnerable && damageDirection.x>0))
        {
            return;
        }
        base.takeDamage(damager);
        
    }
}
