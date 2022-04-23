using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public void Ua()
    {
        string language = "Ua";
        PlayerPrefs.SetString("language", language);
    }
    public void Pol()
    {
        string language = "Pol";
        PlayerPrefs.SetString("language", language);
    }
    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("language", language);
    }
    public void Ger()
    {
        string language = "Ger";
        PlayerPrefs.SetString("language", language);
    }
}
