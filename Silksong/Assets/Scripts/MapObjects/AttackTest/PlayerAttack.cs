using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// ��ʱ������ҵ���ͨ������������ ����������
/// </summary>���ߣ����
public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public float atkCostTime;//���ι�������ʱ��
    public bool isAttacking;

    public GameObject atkTrigger;

    private float atkCostTimeCounter;
   // private PlayerController PlayerController;
    void Start()
    {
        //PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.C))//������
        {
            GameObject blt = Instantiate(bullet);
            Vector3 bltPostion = transform.position;
            if (transform.localScale.x==1)//����������
            {
                bltPostion.x-= 0.5f;
                blt.GetComponent<Bullet>().facingRight = -1;
                blt.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                bltPostion.x += 0.5f;
                blt.GetComponent<Bullet>().facingRight = 1;
            }
            blt.transform.position = bltPostion;
        }*/


        if (Input.GetKeyDown(KeyCode.X) && isAttacking==false)//��ͨ���� 
        {
            isAttacking = true;
            atkCostTimeCounter = atkCostTime;
            atkTrigger.SetActive(true);
        }

        if(isAttacking)
        {
            atkCostTimeCounter -= Time.deltaTime;
            if(atkCostTimeCounter<=0)
            {
                atkTrigger.SetActive(false);
                isAttacking = false;
            }
        }

    }
}
