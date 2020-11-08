using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipHandler : MonoBehaviour
{
    [Header("Instance Data")]
    public static TooltipHandler _inst;

    public Tooltip _tooltip;

    void Awake()
    {
        // Confirm singleton instance is active
        if (_inst == null)
            _inst = this;
        else if (_inst != this)
            GameObject.Destroy(this);

        if (_inst._tooltip != null)
            Hide();
        else
            Debug.Log("WARNING: reference to \"_tooltip\" in <TooltipHandler> is null.");
    }

    // void Start() {}
    // void Update() {}
    // void FixedUpdate() {}

    public static void Show() { if (_inst._tooltip != null) _inst._tooltip.gameObject.SetActive(true); }
    
    public static void Show(string headerText = "", string contentText = "content ...")
    {
        if (_inst._tooltip != null)
        {
            _inst._tooltip.SetText(headerText, contentText);
            _inst._tooltip.gameObject.SetActive(true);
        }
    }

    public static void Hide()
    {
        if (_inst._tooltip != null)
            _inst._tooltip.gameObject.SetActive(false);
    }
}
