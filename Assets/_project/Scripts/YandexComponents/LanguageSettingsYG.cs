using UnityEngine;
using YG;

public class LanguageSettingsYG : MonoBehaviour
{
    private const string Rus = "ru";
    private const string Eng = "en";
    private const string Tr = "tr";

    public void ChooseLanguage(string language)
    {
        switch (language)
        {
            case Rus:
                YG2.SwitchLanguage("ru");
                break;
            case Eng:
                YG2.SwitchLanguage("en");
                break;
            case Tr:
                YG2.SwitchLanguage("tr");
                break;
            default:
                break;
        }
    }
}
