using UnityEngine;
using Assets.Scripts.Sound;
using Assets.Scripts.App;
using UnityEngine.UI;
using Assets.Scripts._Levels;

namespace Assets.Scripts.Instructions
{
    public class GameRules : MonoBehaviour
    {


        [SerializeField]
        private Text description;

        void Start(){
            //description.text = AppController.GetController().GetDescriptionOf(AppController.GetController().GetCurrentGame());
            SoundController.GetController().PlayClip(ViewController.GetController().GetCurrentObject().GetComponent<LevelController>().GetInstructions());
        }

    

        public void OnClickBackToGame()
        {
            ClickSound();
            ViewController.GetController().HideInstructions();
        }

        private void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }
    }
}