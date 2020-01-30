using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
	public class GameLocalization : MonoBehaviour
	{
      
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
		}
        private void Start()
        {
            
        }
        public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
		}
	}
}