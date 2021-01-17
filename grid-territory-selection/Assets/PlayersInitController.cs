using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersInitController : MonoBehaviour {
    public GameObject playerSettingsPrefab;

    int PLAYER_Y_OFFSET = 50;
    int MAX_PLAYERS = 8;

    List<GameObject> players = new List<GameObject>();
    HashSet<string> playerNames = new HashSet<string>();
    PlayerSettingsController playerController;

    void Start() {
        players.Add(transform.Find("PlayerSettings").gameObject);
    }

    public void AddPlayer() {
        if (players.Count < MAX_PLAYERS) {
            GameObject newPlayer = Instantiate(playerSettingsPrefab, transform);
            newPlayer.transform.Translate(Vector3.down * PLAYER_Y_OFFSET * players.Count);
            players.Add(newPlayer);
        }
    }

    public void RemovePlayer() {
        if (players.Count > 1) {
            GameObject lastPlayer = players[players.Count - 1];
            players.RemoveAt(players.Count - 1);
            Destroy(lastPlayer);
        }
    }

    public bool IsValid() {
        playerNames.Clear();
        foreach (GameObject player in players) {
            playerController = player.GetComponent<PlayerSettingsController>();
            if (!playerController.IsValid() || playerNames.Contains(playerController.myName())) {
                return false;
            }
            playerNames.Add(playerController.myName());
        }
        return true;
    }

    public Player[] getPlayers() {
        Player[] finalPlayers = new Player[players.Count];
        for (int i = 0; i < players.Count; i++) {
            PlayerSettingsController playerSettings = players[i].GetComponent<PlayerSettingsController>();
            finalPlayers[i] = new Player(playerSettings.myName(), playerSettings.myColor());
        }
        return finalPlayers;
    }
}

public class Player {
    public Color color;
    public string name;

    public Player(string name, Color color) {
        this.name = name;
        this.color = color;
    }


}
