using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Assets.Scripts._Levels.MathsGame
{
    public class MathsView : LevelView
    {
        [SerializeField]
        private List<Toggle> options;
        [SerializeField]
        private Image questionImage;
        [SerializeField]
        private Text titleText;
        [SerializeField]
        private Button ticBtn;
        [SerializeField]
        private Button hintBtn;
        [SerializeField]
        private Image endGame;

        private int selectedOption;

        public override void OnClickHint()
        {
            PlaySoundClick();
            hintBtn.interactable = false;
            MathsController.GetController().RequestHint();
        }

        internal void SetTitle(string value)
        {
            titleText.text = value;
        }

        internal void NextChallenge(Activity activity)
        {
            for (int i = 0; i < options.Count; i++)
            {
                options[i].GetComponentInChildren<Text>().text = activity.GetOptions()[i].ToUpper();
                options[i].enabled = false;
                options[i].isOn = false;
                options[i].enabled = true;
            }
            selectedOption = -1;
            UpdateTicButton();
            if (activity.GetOptions()[0].ToUpper() != "A") { ShuffleOptions(); }
            titleText.text = activity.GetInstructionText();
            questionImage.sprite = Resources.Load<Sprite>(activity.GetImg());
            hintBtn.interactable = true;

        }

        public void OnSelectOption(int option)
        {
            if(options[option].enabled) PlaySoundClick();
            selectedOption = option;
            UpdateTicButton();
        }

        public void OnClickTic()
        {
            MathsController.GetController().CheckAnswer(options[selectedOption].GetComponentInChildren<Text>().text);
        }

        private void ShuffleOptions()
        {
            System.Random rng = new System.Random();
            int n = options.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = options[k].GetComponentInChildren<Text>().text;
                options[k].GetComponentInChildren<Text>().text = options[n].GetComponentInChildren<Text>().text;
                options[n].GetComponentInChildren<Text>().text = value;
            }
        }

        internal void SetImage(string path)
        {
            Debug.Log(path);

            questionImage.sprite = Resources.Load<Sprite>(path);
        }

        private void UpdateTicButton()
        {
            ticBtn.interactable = options[0].transform.parent.GetComponent<ToggleGroup>().AnyTogglesOn();
        }

        internal void EndGame()
        {
            endGame.gameObject.SetActive(true);
        }
    }
}