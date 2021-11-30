using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ײ���ĳ����� 
/// </summary>���ߣ����
public abstract class Trigger2DBase : MonoBehaviour
{
    public LayerMask targetLayer;//������trigger��layer
    public bool canWork;
    public bool isOneTime;//�Ƿ�ֻ����һ��

    protected  virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (canWork && targetLayer.Contains(collision.gameObject) )
        {
            enterEvent();
        }
    }

    protected virtual void enterEvent()
    {

    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {

        if (canWork && targetLayer.Contains(collision.gameObject))
        {
            exitEvent();
            if(isOneTime)
            canWork = false;//
        }
    }

    protected  virtual void exitEvent()
    {

    }

}
