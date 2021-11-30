using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int maxHp;
    public int maxSoul;
    public int soul;
    public int money;
    /// <summary>
    /// ����buff ������յĹ����ӻ�����
    /// </summary>
    /// <returns></returns>
    public int getAttackGainSoulNumber()
    {
        return Constants.playerAttackGainSoul;
    }
    void Start()
    {
        
    }

    public void AttackGainSoul(DamagerBase damager,DamageableBase damageable)
    {
        if(damageable.playerAttackCanGainSoul)
        {
            addSoul(getAttackGainSoulNumber());
        }
    }

    public void setSoul(int number)
    {
        soul = number;
        checkSoul();
    }

    protected virtual void checkSoul()
    {
        if (soul>maxSoul)
        {
            soul= maxSoul;
        }
        if (soul <= 0)
        {
            soul = 0;
        }
    }
    protected void addSoul(int number)//���ܵ��˺� number<0
    {
        soul += number;
        checkSoul();

    }

}
