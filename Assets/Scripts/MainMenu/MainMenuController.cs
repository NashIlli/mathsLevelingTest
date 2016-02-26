using Assets.Scripts.App;
using System;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{

    public class MainMenuController : MonoBehaviour
    {
        private static MainMenuController mainMenuController;

        public MenuView menuView;
        public GamePreview gamePreview;

        void Awake()
        {
            if (mainMenuController == null) mainMenuController = this;
            else if (mainMenuController != this) Destroy(gameObject);
        }

        internal void PlayGame(int game)
        {
            ViewController.GetController().PlayGame(game);
        }

        internal void ShowMenu()
        {
            menuView.gameObject.SetActive(true);
        }     

        internal void ShowPreviewGame(int game)
        {
            AppController.GetController().SetCurrentGame(game);
            gamePreview.gameObject.SetActive(true);

        }

        public static MainMenuController GetController()
        {
            return mainMenuController;
        }
    }
}