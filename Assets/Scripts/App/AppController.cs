using UnityEngine;
using Assets.Scripts.Sound;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.App
{
    public class AppController : MonoBehaviour
    {
        private static AppController appController;
        private AppModel appModel;

        void Awake(){
            if (appController == null) appController = this;
            else if (appController != this) Destroy(gameObject);     
            DontDestroyOnLoad(gameObject);
            appModel = new AppModel();
        }

        internal int GetGamesQuantity()
        {
            return 5;
        }    

        internal void PlayCurrentGame()
        {
            ViewController.GetController().StartGame(appModel.GetCurrentGame());
        }

        internal void NextGame()
        {
            appModel.SetCurrentGame(appModel.GetCurrentGame() + 1);
            ViewController.GetController().PlayGame(appModel.GetCurrentGame());
        }

        internal void SetUsername(string username)
        {
            appModel.SetUsername(username);
        }

        internal void SetCurrentGame(int currentGame){
            appModel.SetCurrentGame(currentGame);
        }

        internal int GetCurrentGame(){
            return appModel.GetCurrentGame();
        }

        internal int GetCurrentChallenge()
        {
            return appModel.GetCurretChallenge();
        }

        internal void ShowInGameMenu(){
            ViewController.GetController().ShowInGameMenu();
        }    

        public static AppController GetController()
        {
            return appController;
        }    

        internal void SetChallenge(int challenge) {
            appModel.SetChallenge(challenge);
        }
    }
}
