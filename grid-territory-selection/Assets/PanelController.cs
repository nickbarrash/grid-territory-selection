using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject selectionPanel;

    enum PANELS {
        SETTINGS,
        SELECTION
    }

    private Dictionary<PANELS, GameObject> panelMap;

    private void Awake() {
        panelMap = new Dictionary<PANELS, GameObject>();

        panelMap.Add(PANELS.SETTINGS, settingsPanel);
        panelMap.Add(PANELS.SELECTION, selectionPanel);
    }

    private void Start() {
        switchToSettings();
    }

    public void switchToSettings() {
        switchPanel(PANELS.SETTINGS);
    }

    public void switchToSelection() {
        switchPanel(PANELS.SELECTION);
    }

    void switchPanel(PANELS newPanel) {
        foreach (GameObject panel in panelMap.Values) {
            panel.SetActive(false);
        }

        panelMap[newPanel].SetActive(true);
    }
}
