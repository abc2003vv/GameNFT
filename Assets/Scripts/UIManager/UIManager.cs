using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _settingsPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenSettingsPanel()
    {
        if (_settingsPanel != null)
            _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        if (_settingsPanel != null)
            _settingsPanel.SetActive(false);
    }
}
