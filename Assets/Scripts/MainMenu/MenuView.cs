using UnityEngine;
using Assets.Scripts.Sound;
using Assets.Scripts.App;

namespace Assets.Scripts.MainMenu {
    public class MenuView : MonoBehaviour {    

        public void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }

        public void OnClickGame(int game)
        {
            ClickSound();
            MainMenuController.GetController().PlayGame(game);
            AppController.GetController().SetCurrentGame(game);
        }
    }
}
