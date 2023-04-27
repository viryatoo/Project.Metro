using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMainPanelView : MonoBehaviour
{
    [SerializeField] private Button BtnAttack;
    [SerializeField] private Button BtnAddArmy;

    public void SetActiveAttackButton(bool value)
    {
        BtnAttack.gameObject.SetActive(value);
    }
    public void SetActiveAddArmyButton(bool value)
    {
        BtnAddArmy.gameObject.SetActive(value);
    }

    public void AddHandlerBtnAttack(UnityAction handler)
    {
        BtnAttack.onClick.AddListener(handler);
    }
    public void AddHandlerBtnAddArmy(UnityAction handler)
    {
        BtnAddArmy.onClick.AddListener(handler);
    }

    public void RemoveHandlerBtnAttack(UnityAction handler)
    {
        BtnAttack.onClick.RemoveListener(handler);
    }
    public void RemoveHandlerBtnAddArmy(UnityAction handler)
    {
        BtnAddArmy.onClick.RemoveListener(handler);
    }

}
