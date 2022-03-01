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

        [SerializeField] private GameObject levelProgress;
        [SerializeField] private TextMeshProUGUI totalDiamondTxt;
        [SerializeField] private TextMeshProUGUI totalGoldTxt;
        [SerializeField] private TextMeshProUGUI currentLevelInGameTxt;
        [SerializeField] private TextMeshProUGUI nextLevelInGameTxt;
        
        [SerializeField] private TextMeshProUGUI currentLevelFailTxt;
        [SerializeField] private TextMeshProUGUI currentLevelWonTxt;

        private bool isFail, isWon;

        //private int inGameDiamond;
        private void Awake()
        {
            startUI.SetActive(true);
            inGameUI.SetActive(true);
            TotalDiamondText();
            TotalGoldText();
            TextInGameLevel();
        }


        public void StartGame()
        {
            startUI.SetActive(false);
            TextInGameLevel();
        }

        public void Fail()
        {
            inGameUI.SetActive(false);
            levelProgress.SetActive(false);
            failUI.SetActive(true);
            isFail = true;
            TextCurrentLevel();
        }

        public void Win()
        {
            inGameUI.SetActive(false);
            levelProgress.SetActive(false);
            winUI.SetActive(true);
            isWon = true;
            TextCurrentLevel();
        }

        public void TotalDiamondText()
        {
            totalDiamondTxt.text = PlayerPrefs.GetInt("DiamondCount", 0).ToString();
        }

        public void TotalGoldText()
        {
            totalGoldTxt.text=PlayerPrefs.GetInt("GoldCount", 0).ToString();
        }

        private void TextInGameLevel()
        {
            levelProgress.SetActive(true);
            currentLevelInGameTxt.text = $"{PlayerPrefs.GetInt("Level",1)}";
            nextLevelInGameTxt.text = $"{PlayerPrefs.GetInt("Level",1)+1}";
        }

        private void TextCurrentLevel()
        {
            if (isFail)
            {
                currentLevelFailTxt.text = PlayerPrefs.GetInt("Level",1).ToString();
            }
            else if(isWon)
            {
                currentLevelWonTxt.text = PlayerPrefs.GetInt("Level",1).ToString();
            }
            
        }
    }
}