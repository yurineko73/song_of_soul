using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// ������˺���damager
/// </summary>
/// 
public class Damager : DamagerBase
{

    protected override void makeDamage(DamageableBase Damageable)
    {
        makeDamageEvent.Invoke(this, Damageable);
    }



}
