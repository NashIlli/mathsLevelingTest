using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;
using Assets.Scripts.App;
using Assets.Scripts.Sound;
using Assets.Scripts.Metrics;

namespace Assets.Scripts._Levels.MathsGame
{
    public class MathsController : LevelController
    {
        private static MathsController mathsController;
        private MathsModel mathsModel;
        [SerializeField]
        private MathsView mathsView;

        internal int GetTotalActivities()
        {
            return mathsModel.GetTotalActivities();
        }

        void Awake()
        {
            if (mathsController == null) mathsController = this;
            else if (mathsController != this) Destroy(gameObject);
            InitGame();

        }

        void Start()
        {
            NextChallenge();

        }

        public override AudioClip GetInstructions()
        {
            return null;
        }

        internal void RequestHint()
        {
            LogHint(mathsModel.GetCurrentActivity().GetIndex());
            mathsView.SetImage(mathsModel.GetCurrentActivity().GetHintImg());
        }

        public override void InitGame()
        {
            LoadDataFromJson();
        }

        private void LoadDataFromJson()
        {
            TextAsset JSONstring = Resources.Load("maths") as TextAsset;
            JSONNode data = JSON.Parse(JSONstring.text);
            mathsView.SetTitle(data["title"].Value);
            JSONNode level = data["maths"]["levels"][AppController.GetController().GetCurrentChallenge()];
            mathsModel = new MathsModel(level["exercises"].Count);
            for (int i = 0; i < level["exercises"].Count; i++)
            {
                JSONNode exercise = level["exercises"][i];
                string[] options = new string[exercise["options"].Count];
                for (int j = 0; j < exercise["options"].Count; j++)
                {
                    options[j] = exercise["options"][j];
                }
                mathsModel.AddActivity(new Activity(exercise["name"], exercise["instructionAudio"], exercise["instructionText"], options, exercise["correct"].AsInt, exercise["image"], exercise["hintImg"], i));
            }
        }

        internal string GetActivityName(int activity)
        {
            return mathsModel.GetActivityName(activity);
        }

        internal void CheckAnswer(string selectedOption)
        {
            if (mathsModel.CheckAnswer(selectedOption))
            {
                SoundController.GetController().PlayRightSound();
                LogRightAnswer(mathsModel.GetCurrentActivity().GetIndex());
            } else
            {
                SoundController.GetController().PlayWrongSound();
                LogWrongAnswer(mathsModel.GetCurrentActivity().GetIndex());
            }
            NextChallenge();
        }

        public override void NextChallenge()
        {
            if (mathsModel.HasNextActivity())
            {
                mathsModel.NextChallenge();
                mathsView.NextChallenge(mathsModel.GetCurrentActivity());
            } else
            {
                mathsView.EndGame();
                MetricsController.GetController().GameEnd();
            }
        }

        public static MathsController GetController()
        {
            return mathsController;
        }
    }
}