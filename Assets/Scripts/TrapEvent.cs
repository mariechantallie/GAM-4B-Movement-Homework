using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Trap Event", menuName = "Events/TrapEvent")]
public class TrapEvent : ScriptableObject
{
    public Action<TrapData> OnTrapTrigger;
    public void TrapTriggered(TrapData data)
    {
        OnTrapTrigger?.Invoke(data);
    }
}
