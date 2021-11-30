using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ײ���ĳ����� 
/// </summary>���ߣ����
public abstract class Collider2DBase : MonoBehaviour
{
    public LayerMask targetLayer;//������collider��layer
    public bool canWork;
    public bool isOneTime;//�Ƿ�ֻ����һ��

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (canWork && targetLayer.Contains(collision.gameObject) )
        {
            enterEvent();
        }
    }

    protected virtual void enterEvent()
    {

    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (canWork && targetLayer.Contains(collision.gameObject))
        {
            exitEvent();
            if(isOneTime)
            canWork = false;
        }
    }

    protected virtual void exitEvent()
    {

    }

}

