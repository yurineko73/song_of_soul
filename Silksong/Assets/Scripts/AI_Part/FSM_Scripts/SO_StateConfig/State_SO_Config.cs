using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Reflection;

/// <summary>
/// ScriptableObject״̬���ã��ɲο�Enemy_State_SO_Config�����÷�ʽ
/// </summary>
/// <typeparam name="T1">StateEnum</typeparam>
/// <typeparam name="T2">TriggerEnum</typeparam>
/// <typeparam name="T3">StateBase</typeparam>
/// <typeparam name="T4">TriggerBase</typeparam>
public class State_SO_Config<T1, T2, T3, T4> : ScriptableObject
{
    [HideInInspector]
    [SerializeReference]
    public T1 lastStateID;
    [HideInInspector]
    [SerializeReference]
    public T2 lastTriggerID;
    public string StateName;
    [Header("----------------------State Config Area------------------------")]
    public T1 StateType;
    [SerializeReference]
    public T3 stateConfig;
    [Header("----------------------Trigger Config Area----------------------")]
    [Space(20)]
    public T2 TriggerType;
    [SerializeReference]
    public T4 triggerConfig;
    [Header("-----------------------Triggers List Area----------------------")]
    [Space(20)]
    [SerializeReference]
    public List<System.Object> triggerList;
    [NonSerialized]
    public Type triggerType;
    [NonSerialized]
    public Type stateType;


    private void Awake()
    {
        if (stateConfig == null && triggerConfig == null)
        {
            
            lastStateID = StateType;
            stateType = Type.GetType(StateType.ToString());
            if (stateType != null)
                stateConfig = (T3)Activator.CreateInstance(stateType);
            else
                Debug.LogError("�Ҳ�������Ӧ��State������ö�������Ƿ�������һ�¡�");


            lastTriggerID = TriggerType;
            triggerType = Type.GetType(TriggerType.ToString());
            if (triggerType != null)
                triggerConfig = (T4)Activator.CreateInstance(triggerType);
            else
                Debug.LogError("�Ҳ�������Ӧ��Trigger������ö�������Ƿ�������һ�¡�");
        }
    }
    
}



/// <summary>
/// �������ߣ�����Enemy_SO ,Inspirte����ˢ��
/// </summary>
[CustomEditor(typeof(Enemy_State_SO_Config))]
public class Enemy_State_SO_Config_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Enemy_State_SO_Config config = target as Enemy_State_SO_Config;
        config.StateName = config.name;
        if (config.lastStateID != config.StateType)
        {
            config.lastStateID = config.StateType;
            config.stateType = Type.GetType(config.StateType.ToString());
            if (config.stateType != null)
            {
                config.stateConfig = Activator.CreateInstance(config.stateType) as EnemyFSMBaseState;
                config.stateConfig.stateType = config.StateType;
            }
            else
                Debug.LogError("�Ҳ�������Ӧ��State������ö�������Ƿ�������һ�¡�");

        }
        if (config.lastTriggerID != config.TriggerType)
        {
            config.lastTriggerID = config.TriggerType;
            config.triggerType = Type.GetType(config.TriggerType.ToString());
            if (config.triggerType != null)
            {
                config.triggerConfig = Activator.CreateInstance(config.triggerType) as EnemyFSMBaseTrigger;
                config.triggerConfig.triggerType = config.TriggerType;
            }
            else
                Debug.LogError("�Ҳ�������Ӧ��Trigger������ö�������Ƿ�������һ�¡�");

        }
        if (GUILayout.Button("Add to List"))
        {
            config.triggerList.Add( ObjectClone.CloneObject(config.triggerConfig));
        }
    }
}

/// <summary>
/// �������ߣ�����NPC_SO ,Inspirte����ˢ��
/// </summary>
[CustomEditor(typeof(NPC_State_SO_Config))]
public class NPC_State_SO_Config_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        NPC_State_SO_Config config = target as NPC_State_SO_Config;
        if (config.lastStateID != config.StateType)
        {
            config.lastStateID = config.StateType;
            config.stateType = Type.GetType(config.StateType.ToString());
            if (config.stateType != null)
            {
                config.stateConfig = Activator.CreateInstance(config.stateType) as NPCFSMBaseState;
                config.stateConfig.stateType = config.StateType;
            }
            else
                Debug.LogError("�Ҳ�������Ӧ��State������ö�������Ƿ�������һ�¡�");

        }
        if (config.lastTriggerID != config.TriggerType)
        {
            config.lastTriggerID = config.TriggerType;
            config.triggerType = Type.GetType(config.TriggerType.ToString());
            if (config.triggerType != null)
            {
                config.triggerConfig = Activator.CreateInstance(config.triggerType) as NPCFSMBaseTrigger;
                config.triggerConfig.triggerType = config.TriggerType;
            }
            else
                Debug.LogError("�Ҳ�������Ӧ��Trigger������ö�������Ƿ�������һ�¡�");

        }
        if (GUILayout.Button("Add to List"))
        {
            config.triggerList.Add(ObjectClone.CloneObject(config.triggerConfig));
        }
    }



}

/// <summary>
/// �������ߣ�����Player_SO ,Inspirte����ˢ��
/// </summary>
/// 

//[CustomEditor(typeof(Player_State_SO_Config))]
//public class Player_State_SO_Config_Editor : Editor
//{

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        Player_State_SO_Config config = target as Player_State_SO_Config;
//        if (config.lastStateID != config.StateType)
//        {
//            config.lastStateID = config.StateType;
//            config.stateType = Type.GetType(config.StateType.ToString());
//            if (config.stateType != null)
//            {
//                config.stateConfig = Activator.CreateInstance(config.stateType) as PlayerFSMBaseState;
//                config.stateConfig.StateType = config.StateType;
//            }
//            else
//                Debug.LogError("�Ҳ�������Ӧ��State������ö�������Ƿ�������һ�¡�");

//        }
//        if (config.lastTriggerID != config.TriggerType)
//        {
//            config.lastTriggerID = config.TriggerType;
//            config.triggerType = Type.GetType(config.TriggerType.ToString());
//            if (config.triggerType != null)
//            {
//                config.triggerConfig = Activator.CreateInstance(config.triggerType) as PlayerFSMBaseTrigger;
//                config.triggerConfig.TriggerType = config.TriggerType;
//            }
//            else
//                Debug.LogError("�Ҳ�������Ӧ��Trigger������ö�������Ƿ�������һ�¡�");

//        }
//        if (GUILayout.Button("Add to List"))
//        {
//            config.triggerList.Add(ObjectClone.CloneObject(config.triggerConfig));
//        }
//    }



//}



/// <summary>
/// ������Inspirteֻ����ʾ�������޸ĵ�����
/// </summary>
public class DisplayOnly:PropertyAttribute{ }
[CustomPropertyDrawer(typeof(DisplayOnly))]
public class DisplayOnlyDraw:PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, true);
        GUI.enabled = true;
    }
}

