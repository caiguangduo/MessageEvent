using UnityEngine;
using System.Collections;

public class Test01 : MonoBehaviour
{
    private void Start()
    {
        CEventDispatcher.GetInstance().AddEventListener(CEventType.NEXT_BATTALE_START, StartKongXi);
        CEventDispatcher.GetInstance().AddEventListener(CEventType.GAME_WIN, StopKongXi);
        CEventDispatcher.GetInstance().AddEventListener(CEventType.GAME_OVER, StopKongXi);
    }

    private void StartKongXi(CBaseEvent ce)
    {
        Debug.Log("StartKongXi");
    }
    private void StopKongXi(CBaseEvent ce)
    {
        Debug.Log("StopKongXi");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CEventDispatcher.GetInstance().DispatchEvent(new CBaseEvent(CEventType.NEXT_BATTALE_START, this));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            CEventDispatcher.GetInstance().DispatchEvent(new CBaseEvent(CEventType.GAME_OVER, this));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CEventDispatcher.GetInstance().DispatchEvent(new CBaseEvent(CEventType.GAME_WIN, this));
        }
    }
}
