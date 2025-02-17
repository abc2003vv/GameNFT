using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _playGamePanel;
    [SerializeField] private GameObject _settingsPanel;

    private void Awake()
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

    private void Start()
    {
        // Ẩn ban đầu bằng scale 0
        if (_settingsPanel != null) _settingsPanel.transform.localScale = Vector3.zero;
    }

    //Play Game Panel
    public void ClosePlayGamePanel()
    {
        if (_playGamePanel != null)
        {
            LeanTween.scale(_playGamePanel, Vector3.zero, 0.3f).setEase(LeanTweenType.easeInBack)
                .setOnComplete(() => _playGamePanel.SetActive(false));
        }
    }

    //UI Setting
    public void OpenSettingsPanel()
    {
        if (_settingsPanel != null)
        {
            _settingsPanel.SetActive(true);
            _settingsPanel.transform.localScale = Vector3.zero;
            LeanTween.scale(_settingsPanel, Vector3.one, 0.3f).setEase(LeanTweenType.easeOutBack);
        }
    }

    //Settings Panel
    public void CloseSettingsPanel()
    {
        if (_settingsPanel != null)
        {
            LeanTween.scale(_settingsPanel, Vector3.zero, 0.3f).setEase(LeanTweenType.easeInBack)
                .setOnComplete(() => _settingsPanel.SetActive(false));
        }
    }
}
