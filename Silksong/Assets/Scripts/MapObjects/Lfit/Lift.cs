using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// ����1.0
/// </summary>���ߣ����
public class Lift : MonoBehaviour
{
    public int maxFloor;//��1��ʼ����
    public LiftFloorGear[] gears;//liftΪ�õ��ݵ�liftFloorGear��startʱ�󶨵�������  ���ӵͲ㵽�߲�˳��

    public float currentFloor;//��ǰ�� ��Ϊx.5�����ʾ��x��x+1��֮��
    public int targetFloor;//����Ҫ���Ĳ�
    public int midTargetFloor;//���ڲ��Ŀ���֮����м�� �����ڿ����ƶ��м�¼���ݵ�ǰλ��

    public float targetFloorHeight;//Ŀ�����߶�
    public float midFloorHeight;//�м��ĵ���߶�

    public Transform liftFloorTransform;//���ݵذ��λ�� ����ʹ���ݵذ������߶�һ��

    public float speed;
    private float arriveDistance;//��������Ŀ�ĵؾ���С�ڴ�ֵʱ �ж�����

    private PlayerController player;
    private Rigidbody2D playerRigid;

    private Rigidbody2D rigid;
    private BoxCollider2D floorCollider;//���ݵ������ײ��

    private bool playerIsOnLift=false;//����Ƿ��ڵ����� ����ͬ���ٶ�
    void Awake()
    {
        gears = new LiftFloorGear[maxFloor];
        rigid = GetComponent<Rigidbody2D>();
        floorCollider = GetComponent<BoxCollider2D>();

    }
    void Start()
    {
        GameObject playerobj = GameObject.FindGameObjectWithTag("Player");
        if(player!=null)
        {
            player = playerobj.GetComponent<PlayerController>();
            playerRigid = player.GetComponent<Rigidbody2D>();
        }

        setFloorPosition();
        arriveDistance = speed * Time.fixedDeltaTime;
    }

    private void setFloorPosition()
    {
        float floorDistance= floorCollider.offset.y;
        floorDistance += (floorCollider.size.y / 2);
        floorDistance *= transform.lossyScale.y;
        liftFloorTransform.position = new Vector2(liftFloorTransform.position.x, transform.position.y + floorDistance);
    }

    void FixedUpdate()
    {
        if(rigid.velocity.y!=0)//�������ƶ�
        {
            float distance = liftFloorTransform.position.y - midFloorHeight;
          //  Debug.Log(distance);
            if (Mathf.Abs(distance)< arriveDistance)//�ж�����
            {
               // Debug.Log("lift arrive a floor");
                currentFloor = midTargetFloor;//������ĳһ��
                
                if(midTargetFloor==targetFloor)//����Ŀ�Ĳ�
                {
                    //rigid.MovePosition(new Vector3(transform.position.x, transform.position.y - distance, transform.position.z));
                    //�ϸ�������  �����ҵ���ײ������Բ���Բ��ϸ���� ��Ҳ������       
                    rigid.velocity = Vector2.zero;
                    if (playerIsOnLift)
                    {
                        playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0);
                        //Debug.Log("stop");
                    }
                }
                else//�����ƶ�
                {
                    if (rigid.velocity.y > 0)
                        moveUp();
                    else moveDown();
                }

            }
        }
    }



    /// <summary>
    /// ���ݿ��ؿ��Ƶ��ݵĽӿں���
    /// </summary>
    public void setTargetFloor(int floor)//����ʱ�Ѿ���֤floorһ���Ϸ��Ҳ�����currentfloor
    {

        targetFloor = floor;
        targetFloorHeight = gears[floor - 1].floorHeight;

        float distance = floor - currentFloor;
        float moveSpeed;
        if (distance > 0)
        {
            moveSpeed = speed;       
            moveUp();
        }
        else
        {
            moveSpeed = -speed;
            moveDown();
        }

        rigid.velocity = new Vector2(0, moveSpeed);
       if (playerIsOnLift)
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, moveSpeed);
            //Debug.Log("with");
        }

    }    //Ŀǰ��һ�ι����򵽶������δ������ ������ܻ��Ļ���Ŀ��

    public void moveUp()//����һ��
    {
        midTargetFloor = (int)Mathf.Floor(currentFloor)+1;//����ȡ����+1 ��ʾ��һ�� 
        currentFloor = midTargetFloor - 0.5f;//��ʾ������mid���˶�
        midFloorHeight = gears[midTargetFloor - 1].floorHeight;//��Ӧ¥��ĵ���λ��
    }

    public void moveDown()
    {
        midTargetFloor = (int)Mathf.Ceil(currentFloor) - 1;//����ȡ����-1 ��ʾ��һ�� 
        currentFloor = midTargetFloor + 0.5f;//��ʾ������mid���˶�
        midFloorHeight = gears[midTargetFloor - 1].floorHeight;//��Ӧ¥��ĵ���λ��
    }

    private void OnCollisionEnter2D(Collision2D collision)//Ҳ����ʹ��overlap���ж�����Ƿ��ڵ�����
    {
       /* if(collision.gameObject==player.gameObject && collision.otherCollider is BoxCollider2D)
        {
            playerIsOnLift = true;
        }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

       /* if (collision.gameObject == player.gameObject)
        {
            playerIsOnLift = false;
        }*/
    }
}
