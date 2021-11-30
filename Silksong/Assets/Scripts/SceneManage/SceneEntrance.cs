using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������
/// </summary>
public class SceneEntrance : MonoBehaviour
{
    public bool EntranceFaceLeft;
    public enum EntranceTag//�������,������������
    {
        A, B, C, D, E, F, G,
    }

    public EntranceTag destinationTag;

    public static SceneEntrance GetDestination(EntranceTag EntranceTag)
    {

        SceneEntrance[] entrances = FindObjectsOfType<SceneEntrance>();
        for (int i = 0; i < entrances.Length; i++)
        {
            if (entrances[i].destinationTag == EntranceTag)
                return entrances[i];
        }
        Debug.Log("No entrance was found with the " + EntranceTag + " tag.");
        return null;//������û����� ˵����������ҵ���Ϸ���� 
    }
}
