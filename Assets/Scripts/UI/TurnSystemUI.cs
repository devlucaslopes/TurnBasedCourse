using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TurnNumber;
    [SerializeField] private Button EndTurnButton;
    [SerializeField] private GameObject EnemyTurnVisual;

    private void Start()
    {
        EndTurnButton.onClick.AddListener(() =>
        {
            TurnSystem.Instance.NextTurn();
        });

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        UpdateTurnText();
        UpdateEnemyVisual();
        UpdateEndTurnButtonVisibility();
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateTurnText();
        UpdateEnemyVisual();
        UpdateEndTurnButtonVisibility();
    }

    private void UpdateTurnText()
    {
        TurnNumber.text = "TURN " + TurnSystem.Instance.GetTurnNumber();
    }

    private void UpdateEnemyVisual()
    {
        EnemyTurnVisual.SetActive(!TurnSystem.Instance.IsPlayerTurn());
    }

    private void UpdateEndTurnButtonVisibility()
    {
        EndTurnButton.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    }
}
