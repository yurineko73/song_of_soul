using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// 
/// ��hpdamable�Ļ����� �����ܻ����޵л���
/// </summary>���ߣ����
public class InvulnerableDamable : HpDamable
{
    public bool invulnerableAfterDamage = true;//���˺��޵�
    public float invulnerabilityDuration = 3f;//�޵�ʱ��
    protected float inulnerabilityTimer;

    public override void takeDamage(DamagerBase damager)
    {
        base.takeDamage(damager);
        if(invulnerableAfterDamage)
        {
            enableInvulnerability();
        }
    }



    public void enableInvulnerability(bool ignoreTimer = false)//�����޵�
    {
        invulnerable = true;
        //technically don't ignore timer, just set it to an insanly big number. Allow to avoid to add more test & special case.
        inulnerabilityTimer = ignoreTimer ? float.MaxValue : invulnerabilityDuration;
    }

    void Update()
    {
        if (invulnerable)
        {
            inulnerabilityTimer -= Time.deltaTime;

            if (inulnerabilityTimer <= 0f)
            {
                invulnerable = false;
                GetComponent<CapsuleCollider2D>().enabled = false;//���¼���һ��collider �������޵�ʱ����trigger�� �����޵й���ontriggerEnter������
                GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }


}
