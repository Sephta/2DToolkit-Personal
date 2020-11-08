using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [Header("Combo Data")]

    [ReadOnly] public bool canRecieveInput = false;
    [ReadOnly] public bool inputRecieved = false;

    [Header("Instance Data")]
    
    public static ComboManager _instance;
    [SerializeField, ReadOnly] private bool gameStart = false;

    void Awake()
    {
        if (!gameStart)
        {
            _instance = this;
            gameStart = true;
        }

        InputManager();
    }

    public void Attack(bool input)
    {
        if (input)
        {
            if (canRecieveInput)
            {
                inputRecieved = true;
                canRecieveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        canRecieveInput = !canRecieveInput;
    }
}
