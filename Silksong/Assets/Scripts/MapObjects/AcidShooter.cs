using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ˮ(����)
/// </summary>���ߣ����
public class AcidShooter : MonoBehaviour
{
    public GameObject flyAcid;
    public float shotHeight;
    public float shotCD;

    private float Time;//��ֱ������ʱ���һ��
    private float Velocity;//���׳��ٶ�

    void Start()
    {
        float g = -Physics2D.gravity.y;//g=9.81   shotHeight=g*time^2/2   time*g=velocity
        Time = Mathf.Sqrt(2*shotHeight/g);
        Velocity = Time * g;

        if (shotCD > 0)
        {
            StartCoroutine(shotAcidLoop());
        }
           
        else Debug.Log("shot cd can not <=0");
    }

    private IEnumerator shotAcidLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(shotCD);//��shotcdΪ������Ϸ���
            shotAcid();
        }
    }

    private IEnumerator rotateAcid(Transform acid)
    {
        yield return new WaitForSeconds(Time);
        acid.rotation = Quaternion.Euler( new Vector3(0, 0, 0));
    }
    private void shotAcid()
    {
        GameObject acid = Instantiate(flyAcid);
        acid.transform.position = transform.position;
        acid.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Velocity);
        Destroy(acid, Time * 2);
        StartCoroutine(rotateAcid(acid.transform));
    }
}
