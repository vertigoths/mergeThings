using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private AnimalManager _animalManager;
        [SerializeField] private GameObject startButton;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private GameObject nextLevelPanel;
        [SerializeField] private GameObject restartPanel;
        [SerializeField] private GameObject eventSystem;

        private void Awake()
        {
            _animalManager = FindObjectOfType<AnimalManager>();
        }

        private void Start()
        {
            var currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            levelText.text = "Level " + (currentLevel + 1);
        }

        public void OnStart()
        {
            _animalManager.StartHorde();
            startButton.SetActive(false);
            eventSystem.SetActive(false);
        }

        public void OnWin()
        {
            eventSystem.SetActive(true);
            nextLevelPanel.SetActive(true);
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        }

        public void OnLose()
        {
            eventSystem.SetActive(true);
            restartPanel.SetActive(true);
        }

        public void OpenLevel()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
