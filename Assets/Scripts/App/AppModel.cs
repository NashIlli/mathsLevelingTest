using System;
using System.Collections.Generic;

namespace Assets.Scripts.App
{
    internal class AppModel
    {
        private int currentGame;
        private int currentChallenge;
        private string username;

        public AppModel(){
            currentGame = -1;
        }

           

        internal int GetCurrentGame(){
            return currentGame;
        }
   

        internal void SetCurrentGame(int currentGame){
            this.currentGame = currentGame;
        }      


        internal void SetUsername(string username)
        {
            this.username = username;
        }

        internal void SetChallenge(int challenge)
        {
            currentChallenge = challenge;
        }

        internal int GetCurretChallenge()
        {
            return currentChallenge;
        }
    }
}