using UnityEngine;
using UnityEngine.UI;

public class LocalisationHandler : MonoBehaviour
{
    [SerializeField] private Button _localisationButton;
    [SerializeField] private LocalisationView[] _locView;

    private bool _languageRus;
    [SerializeField] private int _languageIndex;

    private void Awake()
    {
        _languageIndex = (GameDataHolder.GetLanguageIndex());
    }
    private void Start()
    {
        _localisationButton.onClick.AddListener(Change);
        SetLanguage();
    }

    private void Change()
    {
        ChangeIndexLanguage();
        GameDataHolder.SetLanguageIndex(_languageIndex);
        for (int i = 0; i < _locView.Length; i++)
        {
            _locView[i].ChangeLanguage(_languageIndex);
        }
        print(_languageIndex);
    }
    private void SetLanguage()
    {
        _languageRus = _languageIndex == 1 ? true : false;
        for (int i = 0; i < _locView.Length; i++)
        {
            _locView[i].ChangeLanguage(_languageIndex);
        }
    }
    private void ChangeIndexLanguage()
    {
        _languageRus = !_languageRus;
        _languageIndex = _languageRus == false ? 0 : 1;
    }
}