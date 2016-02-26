using UnityEngine;

namespace Assets.Scripts.Sound{

    public class SoundController : MonoBehaviour{
	    private static SoundController soundController;

	    public AudioClip levelCompleteSound;
	    public AudioClip clickSound;
        [SerializeField]
        private AudioClip rightAnswer;

        [SerializeField]
        private AudioClip wrongAnswer;

        public AudioSource soundSource;

        void Awake(){
            if (soundController == null){
                soundController = this;
            }
            else if (soundController != this){
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
        }       
    
        public void PlayClip(AudioClip customClip){
	        soundSource.clip = customClip;
	        soundSource.Play();
        }

        public void PlayClickSound(){
		    soundSource.clip = clickSound;
		    soundSource.Play();    
        }

        public void PlayLevelCompleteSound(){
		    soundSource.clip = levelCompleteSound;
		    soundSource.Play();
        }    


        public void StopSound(){
            soundSource.Stop();
        }

        public void PlayRightSound()
        {
            soundSource.clip = rightAnswer;
            soundSource.Play();
        }

        public void PlayWrongSound()
        {
            soundSource.clip = wrongAnswer;
            soundSource.Play();
        }

        public static SoundController GetController(){
            return soundController;
        }
    }
}