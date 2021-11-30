using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableComponent : ContactComponentBase
{
    public bool Invulnerable { get; private set; }
    public float invulnerabilityDuration = 3f;//�޵�ʱ��
    private float m_InvulnerabilityTimer;

    //public override void Initialize(ContactObject contactObject)
    //{
    //    base.Initialize(contactObject);
    //}

    public void BecomeInVulnerable()//�����޵�
    {
        Invulnerable = true;
        m_InvulnerabilityTimer = invulnerabilityDuration;
    }

    void Update()
    {
        if (Invulnerable)
        {
            m_InvulnerabilityTimer -= Time.deltaTime;
            if (m_InvulnerabilityTimer <= 0f)
            {
                Invulnerable = false;
            }
        }
    }
}
