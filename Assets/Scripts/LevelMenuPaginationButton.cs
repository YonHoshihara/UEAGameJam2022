using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPaginationButton : MonoBehaviour
{

    public void CallNextPage()
    {
        EventManager.PlaySoundTrigger(GameDefines.Sounds.PressButton);
        EventManager.CallNextLevelMenuPageTrigger();
    }
    
    public void CallLatestPage()
    {
        EventManager.PlaySoundTrigger(GameDefines.Sounds.PressButton);
        EventManager.CallLatestLevelMenuPageTrigger();
    }
}
