using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class SettingsManager : MonoBehaviour
    {
        public int languaje = 0; // 0 - Spanish, 1 - English
        
        public void AcceptLanguaje() 
        {
            PlayerPrefs.SetInt("languaje", languaje);
            PlayerPrefs.Save();
        }

        public void ChangeLenguaje()
        {
            languaje = (languaje == 0) ? 1 : 0;
            GetComponentInChildren<TextMeshProUGUI>().text = (languaje == 0) ? "Español" : "English";
        }
    }
}