using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalisationView : MonoBehaviour
{
    [SerializeField] private string[] _languages;
    [SerializeField] private TMP_Text _text;

    public void ChangeLanguage(int _languageIndex)
    {
        _text.text = _languages[_languageIndex];
    }
}
