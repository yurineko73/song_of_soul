using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// ӵ������ֵ����ط�����damable 
/// </summary>���ߣ����
public class HpDamable :Damable
{
    public int maxHp = 5;//�������ֵ

    public int currentHp;//��ǰhp

    public bool resetHealthOnSceneReload;


    public override void takeDamage(DamagerBase damager)
    {
        if ( currentHp <= 0)
        {
            return;
        }

        base.takeDamage(damager);
        addHp(-damager.getDamage(this));

    }


    public void setHp(int hp)
    {
        currentHp = hp;
        checkHp();
    }

    protected virtual void checkHp()
    {
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (currentHp <= 0)
        {
            die();
        }
    }
    protected void addHp(int number)//���ܵ��˺� number<0
    {
        currentHp += number;
        checkHp();

    }

    protected virtual void die()
    {
        Destroy(gameObject);//δ����
        Debug.Log(gameObject.name+" die");
    }



}
