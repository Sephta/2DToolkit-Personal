using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text _stateText = null;

    // void Awake() {}
    // void Start() {}

    // Update is called once per frame
    void Update()
    {
        ComboManager._instance.Attack(Input.GetMouseButtonDown(0));
    }

    // void FixedUpdate() {}
}
