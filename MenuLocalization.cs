using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
    /// <summary>
    /// Asset usage example.
    /// </summary>
    public class MenuLocalization : MonoBehaviour
    {
        //public Text BestScore;

        /// <summary>
        /// Called on app start.
        /// </summary>
        public void Awake()
        {
            LocalizationManager.Read();

            switch (Application.systemLanguage)
            {
                case SystemLanguage.Japanese:
                    LocalizationManager.Language = "Japanese";
                    break;
                case SystemLanguage.Russian:
                    LocalizationManager.Language = "Russian";
                    break;
                default:
                    LocalizationManager.Language = "English";
                    break;
            }

            // This way you can insert values to localized strings.
            //BestScore.text = LocalizationManager.Localize("Menu.BestScore", PlayerPrefs.GetInt("BestScore"));

            // This way you can subscribe to localization changed event.
            // LocalizationManager.LocalizationChanged += () => BestScore.text = LocalizationManager.Localize("Menu.BestScore", PlayerPrefs.GetInt("BestScore"));
        }
        private void Start()
        {

        }
        /// <summary>
        /// Change localization at runtime
        /// </summary>
        public void SetLocalization(string localization)
        {
            LocalizationManager.Language = localization;
        }
    }
}