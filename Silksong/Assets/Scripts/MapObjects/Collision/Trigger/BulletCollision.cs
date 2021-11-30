using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : Trigger2DBase//�ӵ�����ײ�¼� ���˺��޹�
{

    public float timeBeforeAutodestruct = -1.0f;
    private float timer=0;

    private void Update()
    {
        if (timeBeforeAutodestruct > 0)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforeAutodestruct)
            {
                Destroy(gameObject);
            }
        }
    }

    protected override void enterEvent()
    {
        Destroy(gameObject);
    }


}
