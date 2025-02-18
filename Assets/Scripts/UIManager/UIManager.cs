using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _playGamePanel;
    [SerializeField] private GameObject _settingsPanel;

    [Header("===Shop Panel===")]
    [SerializeField] private GameObject _shopPanel;
    public GameObject[] _tabs;
    public Image[] _tabBtns;
    public Sprite _inactiveTabBg, _activeTabBg;
    public Vector2 _inactiveTabBtnSize, _activeTabBtnSize;

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
        //if (_shopPanel != null) _shopPanel.transform.localScale = Vector3.zero;
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

    //Shop Panel
    public void OpenShopPanel()
    {
        if (_shopPanel != null)
        {
            _shopPanel.SetActive(true);
            _shopPanel.transform.localScale = Vector3.zero;
            LeanTween.scale(_shopPanel, Vector3.one, 0.3f).setEase(LeanTweenType.easeOutBack);
        }
    }

    public void CloseShopPanel()
    {
        if (_shopPanel != null)
        {
            LeanTween.scale(_shopPanel, Vector3.zero, 0.3f).setEase(LeanTweenType.easeInBack)
                .setOnComplete(() => _shopPanel.SetActive(false));
        }
    }

    //Tab Shop
    public void SwitchToTab(int TabID)
    {
        foreach (GameObject go in _tabs)
        {
            go.SetActive(false);
        }
        _tabs[TabID].SetActive(true);

        foreach (Image im in _tabBtns)
        {
            im.sprite = _inactiveTabBg;
            im.rectTransform.sizeDelta = _inactiveTabBtnSize;
        }
        _tabBtns[TabID].sprite = _activeTabBg;
        _tabBtns[TabID].rectTransform.sizeDelta = _activeTabBtnSize;
    }
}
