using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _playGamePanel;
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

    void Start()
    {
        transform.localScale = Vector2.zero;

    }

    //PlayGamePanel
    public void ClosePlayGamePanel()
    {
        if (_playGamePanel != null)
            _playGamePanel.SetActive(false);
    }

    //Setting the play game panel active
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
