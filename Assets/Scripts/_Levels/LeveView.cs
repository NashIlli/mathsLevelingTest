using Assets.Scripts.App;
using Assets.Scripts.Sound;
using UnityEngine;

namespace Assets.Scripts._Levels
{

    public abstract class LevelView : MonoBehaviour
    {
        public abstract void OnClickHint();

        public void OnClickMenuBtn(){
            PlaySoundClick();
            AppController.GetController().ShowInGameMenu();
        }

        internal void PlaySoundClick()
        {
            SoundController.GetController().PlayClickSound();
        }
       
    }
}
