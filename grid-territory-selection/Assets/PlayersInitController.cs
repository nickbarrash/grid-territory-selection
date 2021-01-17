using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInitController : MonoBehaviour
{
    public GameObject playerSettingsPrefab;

    int PLAYER_Y_OFFSET = 50;
    int MAX_PLAYERS = 8;

    List<GameObject> players = new List<GameObject>();

    void Start()
    {
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
        foreach(GameObject player in players) {
            if (!player.GetComponent<PlayerSettingsController>().IsValid()) {
                return false;
            }
        }
        return true;
    }
}
