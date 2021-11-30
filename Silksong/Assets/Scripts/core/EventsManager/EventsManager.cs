/// <summary>
/// Created by Kimo.               ----2021/08/29    
/// Update�������RemoveEvent����  ---- 2021/08/29
/// Update��
///     1.����˷������εĹ���
///     2.����˷�����֧��������ⷵ��ֵ�ķ���
///                                ---- 2021/08/30
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Created by Kimo.
/// ����ʵ�ֶԳ����ڣ�����ֵΪvoid���ͣ��������¼������ɣ����棬���գ����
/// </summary>
public class EventsManager
{   /*����ģʽ*/
    private static EventsManager instance = new EventsManager();
    public static EventsManager Instance
    {
        get { return instance; }
    }


    /*����ί��*/
    public delegate void voidDelegate();
    public delegate void ArgsDelegate(EventDate eventDate);



    private Dictionary<GameObject, Dictionary<EventType, Dictionary<ArgsDelegate,EventDate>>> argsEventDictionary;
    
    private Dictionary<GameObject, Dictionary<EventType, voidDelegate>> voidEventDictionary;
    private void DefaultFunction() { }
    private EventsManager()
    {
        voidEventDictionary = new Dictionary<GameObject, Dictionary<EventType, voidDelegate>>();

        argsEventDictionary = new Dictionary<GameObject, Dictionary<EventType, Dictionary<ArgsDelegate, EventDate>>>();
    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼��������ĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    public void AddListener(GameObject target, EventType eventType, voidDelegate function)
    {
        if (!(voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType)))
            CreatEvent(target, eventType);
        voidEventDictionary[target][eventType] += function;
    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼��������ĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    /// <param name="Args">��������Ĳ�������һ��ΪEventDate���ͣ����޸�EventDate���������</param>
    public void AddListener(GameObject target, EventType eventType, ArgsDelegate function, EventDate Args)
    {
        if (!(argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType)))
            CreatEvent(target, eventType);
        argsEventDictionary[target][eventType].Add(function, Args);

    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼�����ɾȥĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    public void RemoveListener(GameObject target, EventType eventType, voidDelegate function)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
            voidEventDictionary[target][eventType] -= function;
    }
    public void RemoveListener(GameObject target, EventType eventType, ArgsDelegate function)
    {
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
            if (argsEventDictionary[target][eventType].ContainsKey(function))
                argsEventDictionary[target][eventType].Remove(function);
    }
    /// <summary>
    /// ɾȥĳ�����ĳ�¼���������ע��ķ���
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void RemoveAllListener(GameObject target, EventType eventType)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
        {
            System.Delegate[] delegates = voidEventDictionary[target][eventType].GetInvocationList();
            for (int i = 0; i < delegates.Length; i++)
                voidEventDictionary[target][eventType] -= delegates[i] as voidDelegate;
            voidEventDictionary[target][eventType] = new voidDelegate(DefaultFunction);
        }
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
        {
            argsEventDictionary[target][eventType].Clear();
        }
    }
    /// <summary>
    /// �����ã��Ƴ������������¼���һ���ڳ����л�ʱʹ�á�
    /// </summary>
    public void RemoveAllEvent()
    {
        voidEventDictionary.Clear();
    }
    /// <summary>
    /// �Ƴ�Ŀ�����������¼�
    /// </summary>
    /// <param name="target"></param>
    public void RemoveTargetAllEvent(GameObject target)
    {
        if (voidEventDictionary.ContainsKey(target))
        {
            voidEventDictionary.Remove(target);
        }
    }
    /// <summary>
    /// ����Ŀ������ĳ�¼���������ע��ķ������趨������֮��û���Զ�ɾȥ����ע�᷽������Ҫ�ֶ�ɾȥ
    /// </summary>
    /// <param name="target">Ŀ����� </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void Invoke(GameObject target, EventType eventType)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
        {
            voidEventDictionary[target][eventType].Invoke();
        }
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
        {
           foreach(var value in argsEventDictionary[target][eventType].Keys)
            {
                value.Invoke(argsEventDictionary[target][eventType][value]);
            }
        }
    }
    /// <summary>
    ///Ϊĳ���崴��ĳ���͵��¼�
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void CreatEvent(GameObject target, EventType eventType)
    {
        if (target == null)
        {
            Debug.LogError("Target gameobject is NULL");
            return;
        }
        if (!voidEventDictionary.ContainsKey(target))
            voidEventDictionary.Add(target, new Dictionary<EventType, voidDelegate>());
        if (!voidEventDictionary[target].ContainsKey(eventType))
            voidEventDictionary[target].Add(eventType, new voidDelegate(DefaultFunction));

        if(!argsEventDictionary.ContainsKey(target))
            argsEventDictionary.Add(target, new Dictionary<EventType, Dictionary<ArgsDelegate, EventDate>>());
        if(!argsEventDictionary[target].ContainsKey(eventType))
            argsEventDictionary[target].Add(eventType, new Dictionary<ArgsDelegate, EventDate>());
    }

}



/// <summary>
/// Created by Kimo.
/// ����ʵ�ֶԳ����ڣ�����ֵΪT���ͣ��������¼������ɣ����棬���գ����
/// </summary>
public class EventsManager<T>
{   /*����ģʽ*/
    private static EventsManager<T> instance = new EventsManager<T>();
    public static EventsManager<T> Instance
    {
        get { return instance; }
    }


    /*����ί��*/
    public delegate T voidDelegate();
    public delegate T ArgsDelegate(EventDate eventDate);

    private Dictionary<GameObject, Dictionary<EventType, Dictionary<ArgsDelegate, EventDate>>> argsEventDictionary;

    private Dictionary<GameObject, Dictionary<EventType, voidDelegate>> voidEventDictionary;
    private T DefaultFunction() { return default(T); }
    private EventsManager()
    {
        voidEventDictionary = new Dictionary<GameObject, Dictionary<EventType, voidDelegate>>();

        argsEventDictionary = new Dictionary<GameObject, Dictionary<EventType, Dictionary<ArgsDelegate, EventDate>>>();
    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼��������ĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    public void AddListener(GameObject target, EventType eventType, voidDelegate function)
    {
        if (!(voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType)))
            CreatEvent(target, eventType);
        voidEventDictionary[target][eventType] += function;
    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼��������ĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    /// <param name="Args">��������Ĳ�������һ��ΪEventDate���ͣ����޸�EventDate���������</param>
    public void AddListener(GameObject target, EventType eventType, ArgsDelegate function, EventDate Args)
    {
        if (!(argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType)))
            CreatEvent(target, eventType);
        argsEventDictionary[target][eventType].Add(function, Args);

    }
    /// <summary>
    /// Ϊĳ�����ĳ�¼�����ɾȥĳ����
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    /// <param name="function"> Ϊ���¼���ӵķ���</param>
    public void RemoveListener(GameObject target, EventType eventType, voidDelegate function)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
            voidEventDictionary[target][eventType] -= function;
    }
    public void RemoveListener(GameObject target, EventType eventType, ArgsDelegate function)
    {
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
            if (argsEventDictionary[target][eventType].ContainsKey(function))
                argsEventDictionary[target][eventType].Remove(function);
    }
    /// <summary>
    /// ɾȥĳ�����ĳ�¼���������ע��ķ���
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void RemoveAllListener(GameObject target, EventType eventType)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
        {
            System.Delegate[] delegates = voidEventDictionary[target][eventType].GetInvocationList();
            for (int i = 0; i < delegates.Length; i++)
                voidEventDictionary[target][eventType] -= delegates[i] as voidDelegate;
            voidEventDictionary[target][eventType] = new voidDelegate(DefaultFunction);
        }
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
        {
            argsEventDictionary[target][eventType].Clear();
        }
    }
    /// <summary>
    /// �����ã��Ƴ������������¼���һ���ڳ����л�ʱʹ�á�
    /// </summary>
    public void RemoveAllEvent()
    {
        voidEventDictionary.Clear();
    }
    /// <summary>
    /// �Ƴ�Ŀ�����������¼�
    /// </summary>
    /// <param name="target"></param>
    public void RemoveTargetAllEvent(GameObject target)
    {
        if (voidEventDictionary.ContainsKey(target))
        {
            voidEventDictionary.Remove(target);
        }
    }
    /// <summary>
    /// ����ĳ�����ĳ�¼���������ע��ķ������趨������֮��û���Զ�ɾȥ����ע�᷽������Ҫ�ֶ�ɾȥ
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void Invoke(GameObject target, EventType eventType)
    {
        if (voidEventDictionary.ContainsKey(target) && voidEventDictionary[target].ContainsKey(eventType))
        {
            voidEventDictionary[target][eventType].Invoke();
        }
        if (argsEventDictionary.ContainsKey(target) && argsEventDictionary[target].ContainsKey(eventType))
        {
            foreach (var value in argsEventDictionary[target][eventType].Keys)
            {
                value.Invoke(argsEventDictionary[target][eventType][value]);
            }
        }
    }
    /// <summary>
    ///Ϊĳ���崴��ĳ���͵��¼�
    /// </summary>
    /// <param name="target">Ŀ�����һ����this.gameObject </param>
    /// <param name="eventType"> �¼����ͣ�Ҫ��û�о��Լ����</param>
    public void CreatEvent(GameObject target, EventType eventType)
    {
        if (target == null)
        {
            Debug.LogError("Target gameobject is NULL");
            return;
        }
        if (!voidEventDictionary.ContainsKey(target))
            voidEventDictionary.Add(target, new Dictionary<EventType, voidDelegate>());
        if (!voidEventDictionary[target].ContainsKey(eventType))
            voidEventDictionary[target].Add(eventType, new voidDelegate(DefaultFunction));

        if (!argsEventDictionary.ContainsKey(target))
            argsEventDictionary.Add(target, new Dictionary<EventType, Dictionary<ArgsDelegate, EventDate>>());
        if (!argsEventDictionary[target].ContainsKey(eventType))
            argsEventDictionary[target].Add(eventType, new Dictionary<ArgsDelegate, EventDate>());
    }

}
