using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayersInitController playerSettings;
    SelectionController selectionController;

    public void Awake() {
        playerSettings = FindObjectOfType<PlayersInitController>();
        selectionController = FindObjectOfType<SelectionController>();
    }

    public void StartGame() {
        selectionController.setPlayers(playerSettings.getPlayers());
    }
}
