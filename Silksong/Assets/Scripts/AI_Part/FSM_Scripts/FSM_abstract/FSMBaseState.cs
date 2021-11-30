using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ״̬���ж�״̬�ĳ���,�����÷��ɲο�Enemy״̬���Ĺ���ģʽ��
/// </summary>
/// <typeparam name="T1">������ö�����ͣ�����ΪStateö�١�</typeparam>
/// <typeparam name="T2">������ö�����ͣ�����ΪTriggerö�١�</typeparam>
[Serializable]
public  class FSMBaseState<T1,T2>
{
    //protected FSMManager<T1,T2> fsmManager;
    [DisplayOnly]
    public  T1 stateType;
    [NonSerialized]
    public List<FSMBaseTrigger<T1,T2>> triggers = new List<FSMBaseTrigger<T1,T2>>();

    public void ClearTriggers()
    {
        triggers.Clear();
    }
    public FSMBaseState()
    {
        //InitState();
    }

    /// <summary>
    /// ״̬��ʼ��
    /// </summary>
    public virtual void InitState(FSMManager<T1,T2> fSMManager) { }



    //public void AddTriggers(T2 triggerType,T1 targetState) 
    //{
    //    //Debug.Log(triggerType);

    //    Type type = Type.GetType(triggerType.ToString());
    //    if (type == null)
    //    {
    //        Debug.LogError(triggerType + "�޷���ӵ�" + stateType + "��triggers�б�");
    //        Debug.LogError("δ�ҵ���Ӧ��Trigger������Trigger�������Ƿ���ö��������һ�¡�");
    //    }
    //    else 
    //    {
    //        triggers.Add(Activator.CreateInstance(type) as FSMBaseTrigger<T1,T2>);
    //        triggers[triggers.Count - 1].targetState = targetState;
    //    }
    //}
    public void AddTriggers(FSMBaseTrigger<T1,T2> trigger)
    {
        triggers.Add(trigger);
    }


    /// <summary>
    /// ����״̬ʱ����
    /// </summary>
    public  virtual void EnterState(FSMManager<T1,T2> fSM_Manager) { }

    /// <summary>
    /// �˳�״̬ʱ����
    /// </summary>
    public virtual void ExitState(FSMManager<T1,T2> fSM_Manager) { }

    /// <summary>
    /// ״̬������ˢ��
    /// </summary>
    public virtual void Act_State(FSMManager<T1,T2> fSM_Manager) { }
    /// <summary>
    /// ����Trigger����ת�����������Ķ�Ӧtrigger��ָ���״̬��
    /// </summary>
    public virtual void TriggerState(FSMManager<T1,T2> fsm_Manager)
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i].IsTriggerReach(fsm_Manager))
            {
               // Debug.Log(fsmManager+"  "+triggers[i]+" "+ triggers[i].GetHashCode());
                fsm_Manager.ChangeState(triggers[i].targetState);
            }
        }
    }
}


public class EnemyFSMBaseState : FSMBaseState<EnemyStates,EnemyTriggers> 
{
    protected EnemyFSMManager fsmManager;
    public string defaultAnimationName;
    //��һЩ�����������ж��η�װ
    //////////////////////////////////////////////////////////////////////////////////////////
    public override void InitState(FSMManager<EnemyStates, EnemyTriggers> fSMManager)
    {
        base.InitState(fSMManager);
        InitState(fSMManager as EnemyFSMManager);
    }
    public virtual void InitState(EnemyFSMManager enemyFSM) { }
    public override void EnterState(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.EnterState(fSM_Manager);

        EnterState(fSM_Manager as EnemyFSMManager);

       
    }
    public virtual void EnterState(EnemyFSMManager enemyFSM) {
        if (enemyFSM.animator != null && defaultAnimationName != string.Empty)
        {   
            enemyFSM.animator.Play(defaultAnimationName, 0);
        }
    }
    public override void Act_State(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.Act_State(fSM_Manager);
        Act_State(fSM_Manager as EnemyFSMManager);
    }
    public virtual void Act_State(EnemyFSMManager enemyFSM) { }
    public override void ExitState(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.ExitState(fSM_Manager);
        ExitState(fSM_Manager as EnemyFSMManager);
    }
    public virtual void ExitState(EnemyFSMManager enemyFSM) { }

    public virtual void TriggerState(EnemySubFSMManager fsm_Manager)
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i].IsTriggerReach(fsm_Manager.fsmManager))
            {
                Debug.Log(triggers[i]+"     "+ triggers[i].targetState);
                fsm_Manager.ChangeState(triggers[i].targetState);
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////
    ///
}
public class NPCFSMBaseState: FSMBaseState<NPCStates, NPCTriggers> 
{

}
public class PlayerFSMBaseState : FSMBaseState<PlayerStates, PlayerTriggers>
{

}
