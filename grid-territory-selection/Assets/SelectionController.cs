using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.TMP_Dropdown;

public class SelectionController : MonoBehaviour
{
    TMP_Dropdown playerDropdown;
    GameObject territoryClaimOptions;

    OptionData UNSELECTED_VALUE = new OptionData("CHOOSE PLAYER");

    Image playerColor;

    Player[] players;
    

    // Start is called before the first frame update
    void Awake()
    {
        playerDropdown = transform.Find("PlayerList").GetComponent<TMP_Dropdown>();
        territoryClaimOptions = transform.Find("TerritoryClaim").gameObject;
        playerColor = transform.Find("PlayerColor").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTerritoryClaiming() {
        territoryClaimOptions.SetActive(playerDropdown.value != 0);
    }

    public void SetPlayerColor() {
        if (playerDropdown.value <= 0) {
            playerColor.gameObject.SetActive(false);
        } else {
            playerColor.gameObject.SetActive(true);
            playerColor.color = players[playerDropdown.value - 1].color;
        }
    }

    public void setPlayers(Player[] players) {
        this.players = players;

        playerDropdown.ClearOptions();
        List<OptionData> options = new List<OptionData>();
        options.Add(UNSELECTED_VALUE);
        foreach(Player player in players) {
            options.Add(new OptionData(player.name));
        }
        playerDropdown.AddOptions(options);
        SetTerritoryClaiming();
        SetPlayerColor();
    }
}
