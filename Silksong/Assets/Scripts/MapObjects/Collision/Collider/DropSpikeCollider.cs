using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///��������������� ֹͣ��ȡ���˺�
/// </summary>���ߣ����
public class DropSpikeCollider :Collider2DBase
{
    public GameObject damager;
    protected override void enterEvent()
    {
        damager.SetActive(false);
    }

}
