using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System;

namespace Assets.Scripts.Login{

    public class LoginView : MonoBehaviour{

        //todo -> get var from Settings
        public InputField inputText;
        public Text incorrectInput;
        private int challengeSelected;
        public Button ticBtn;   

        void Start()
        {
            challengeSelected = -1;
        }

        // Use this for initialization
        void OnEnable(){
            incorrectInput.gameObject.SetActive(false);
        }

        void Update(){
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)) { CheckEnteredUsername(); }
            else if (Input.GetKeyUp(KeyCode.Escape)) OnClickBack();
        }

        internal int GetChallengeSelected()
        {
            return challengeSelected;
        }

        public void OnClickTicBtn(){
            PlayClickSound();
            CheckEnteredUsername();
            
        }

        public void OnClickToggle(int challenge)
        {
            PlayClickSound();
            challengeSelected = challenge;
        }

        void CheckEnteredUsername(){
            inputText.text = inputText.text.Trim();
            LoginController.GetController().SaveUsername(inputText.text.ToLower());
        }

        internal void ShowIncorrectInputAnimation(){
            ticBtn.interactable = false;
            ticBtn.enabled = false;
            incorrectInput.text = challengeSelected != -1 ? "Por favor, ingresa un nombre válido" : "Por favor, elige un desafío";
            incorrectInput.GetComponent<IncorrectUserAnimation>().ShowIncorrecrUserAnimation();
        }

        public void OnIncorrectInputAnimationEnd(){          
            ticBtn.interactable = true;
            ticBtn.enabled = true;
        }

        public void OnClickBack(){
            PlayClickSound();
            LoginController.GetController().GoBack();
        }

        public void PlayClickSound(){
            SoundController.GetController().PlayClickSound();
        }
    }
}