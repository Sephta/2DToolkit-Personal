using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// [ExecuteInEditMode()]
[RequireComponent(typeof(LayoutElement))]
public class Tooltip : MonoBehaviour
{
    // PUBLIC VARS
    [Header("TMPro Fields")]
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;

    [Header("Dependencies")]
    public LayoutElement layoutElement = null;

    [Header("Options")]
    public bool _previewInEditor = false;
    [Range(0, 500)] public int _charWrapLimit = 0;


    // PRIVATE VARS
    [Header("Debug Data")]
    public string _thisWillDisplay = "Debug data for tooltip.";
    [SerializeField, ReadOnly] private Vector2 mousePos = Vector2.zero;

    [SerializeField] private RectTransform _transform = null;


    void Awake()
    {
        if (layoutElement == null && gameObject.GetComponent<LayoutElement>() != null)
            layoutElement = gameObject.GetComponent<LayoutElement>();
        
        if (headerField == null || contentField == null)
            Debug.Log("WARNING. references to headerField or contentField in <Tooltip> are null.");
        
        if (_transform == null)
            _transform = gameObject.GetComponent<RectTransform>();
    }

    // void Start() {}

    void Update()
    {
        if (_previewInEditor)
            CheckFieldLength();

        UpdateDisplayPosition();
    }

    // void FixedUpdate() {}

    
    // HELPER FUNCTIONS ---------------------------------------------------------------------------
    
    // PUBLIC
    public void SetText(string headerText = "", string contentText = "content ...")
    {
        if (string.IsNullOrEmpty(headerText))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = headerText;
        }

        contentField.text = contentText;

        // Resizes the Tooltip box if content overflows beyond _charWrapLimit
        CheckFieldLength();
    }

    // PRIVATE
    private void CheckFieldLength()
    {
        if (headerField == null || contentField == null)
        {
            Debug.Log("ERROR: could not read length of \"headerField\" or \"contentField\" in <Tooltip>.");
            return;
        }

        int headerLen = headerField.text.Length;
        int contentLen = contentField.text.Length;

        if (layoutElement != null)
            layoutElement.enabled = (headerLen > _charWrapLimit || contentLen > _charWrapLimit);
        else
            Debug.Log("ERROR: reference to \"layoutElement\" in <Tooltip> is null.");
    }

    private void UpdateDisplayPosition()
    {
        mousePos = Input.mousePosition;

        float dx = mousePos.x / Screen.width;
        float dy = mousePos.y / Screen.height;

        _transform.pivot = new Vector2(dx, dy);

        transform.position = mousePos;
    }
    // --------------------------------------------------------------------------------------------
}
