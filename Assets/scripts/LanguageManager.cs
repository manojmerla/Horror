using UnityEngine;
using TMPro;

public class LanguageToggle : MonoBehaviour
{
    public TextMeshProUGUI playText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI quitText;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI backText;

    private bool isEnglish = true;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isEnglish = !isEnglish;
            UpdateText();
        }
    }

    void UpdateText()
    {
        if (isEnglish)
        {
            playText.text = "Play";
            settingsText.text = "Settings";
            quitText.text = "Quit";
            musicText.text = "Music";
            backText.text = "Back";
        }
        else
        {
            playText.text = "ఆడండి";
            settingsText.text = "సెట్టింగులు";
            quitText.text = "నిష్క్రమించండి";
            musicText.text = "సంగీతం";
            backText.text = "వెనక్కి";
        }
    }
}
