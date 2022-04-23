using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLang : MonoBehaviour
{
    public string language;
    Text text;

    public string textUa;
    public string textPol;
    public string textEng;
    public string textGer;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        language = PlayerPrefs.GetString("language");
        if(language == "" || language == "Eng")
        {
            text.text = textEng;
        }
        else if(language == "Ua")
        {
            text.text = textUa;
        }
        else if(language == "Pol")
        {
            text.text = textPol;
        }
        else if(language == "Ger")
        {
            text.text = textGer;
        }
    }
}
