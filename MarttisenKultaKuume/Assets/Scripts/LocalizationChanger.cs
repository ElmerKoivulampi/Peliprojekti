using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationChanger : MonoBehaviour
{
    public void SwapLocalization()
    {
        Locale current = LocalizationSettings.SelectedLocale;
        Locale fi = LocalizationSettings.AvailableLocales.GetLocale("fi");
        if(current == fi)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("en");
        }
        else
        {
            LocalizationSettings.SelectedLocale = fi;
        }
    }
}
