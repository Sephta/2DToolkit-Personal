using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /* For the basic minimal tooltip system
     * This trigger component uses the unity EventSystem IPointer handlers to determine whether or
     * not the user's mouse is hovering over a gameobject with this trigger component attatched, 
     * and if it is, then it will enable or disable the Tooltip gameobject referenced in the
     * Singleton instance of TooltipHandler.
    */


    // PUBLIC VARS
    [Header("Text Field Info")]
    public string header = "";
    [TextArea(8, 15)] public string content = "";

    // PRIVATE VARS
    private static LTDescr _delay;


    public void OnPointerEnter(PointerEventData eventData)
    {
        _delay = LeanTween.delayedCall (0.5f, () =>
        {
            TooltipHandler.Show(header, content);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(_delay.uniqueId);
        TooltipHandler.Hide();
    }
}
