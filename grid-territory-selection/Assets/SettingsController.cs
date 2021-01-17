using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    Button playButton;
    PlayersInitController playerSettings;

    // Start is called before the first frame update
    void Awake()
    {
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        playerSettings = transform.Find("PlayersSettings").GetComponent<PlayersInitController>();
    }

    private void Start() {
        UpdatePlayButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0) {
            UpdatePlayButton();
        }
    }

    void UpdatePlayButton() {
        playButton.interactable = playerSettings.IsValid();
    }
}
