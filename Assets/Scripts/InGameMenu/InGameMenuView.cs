using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.App;
using Assets.Scripts.Sound;
using System;

public class InGameMenuView : MonoBehaviour {

    public Text mainMenuLabel, instructionsLabel, restartGameLabel, backToGameLabel;

    public void OnInstructionsClic(){
        PlayClickSound();
        ViewController.GetController().HideInGameMenu();
        ViewController.GetController().ShowInstructions();    
    }

    public void OnClicBackToGame()
    {
        PlayClickSound();
        ViewController.GetController().HideInGameMenu();

    }

    private void PlayClickSound()
    {
        SoundController.GetController().PlayClickSound();
    }
}
