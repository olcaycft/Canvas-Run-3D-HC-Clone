using Game.Scripts.Patterns;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private GameObject startUI;
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject failUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private TextMeshProUGUI totalDiamondTxt;
        [SerializeField] private TextMeshProUGUI totalGoldTxt;
        [SerializeField] private TextMeshProUGUI currentLevelTxt;
        [SerializeField] private TextMeshProUGUI nextLevelTxt;

        //private int inGameDiamond;
        private void Awake()
        {
            startUI.SetActive(true);
            inGameUI.SetActive(true);
            TotalDiamondText();
            TotalGoldText();
            TextCurrentLevel();
        }


        public void StartGame()
        {
            startUI.SetActive(false);
        }

        public void Fail()
        {
            inGameUI.SetActive(false);
            failUI.SetActive(true);
        }

        public void Win()
        {
            inGameUI.SetActive(false);
            winUI.SetActive(true);
        }

        public void TotalDiamondText()
        {
            totalDiamondTxt.text = PlayerPrefs.GetInt("DiamondCount", 0).ToString();
        }

        private void TotalGoldText()
        {
            totalGoldTxt.text=PlayerPrefs.GetInt("GoldCount", 0).ToString();
        }

        private void TextCurrentLevel()
        {
            currentLevelTxt.text = $"{PlayerPrefs.GetInt("Level",1)}";
            nextLevelTxt.text = $"{PlayerPrefs.GetInt("Level",1)+1}";
        }
    }
}