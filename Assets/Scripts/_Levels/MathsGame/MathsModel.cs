using UnityEngine;
using System.Collections.Generic;
using System;

namespace Assets.Scripts._Levels.MathsGame
{
    public class MathsModel : LevelModel
    {
        private List<Activity> activities;
        private Activity currentActivity;


        public MathsModel(int quantity)
        {
            activities = new List<Activity>(quantity);
        }

        internal void AddActivity(Activity activity)
        {
            activities.Add(activity);
        }

        internal int GetTotalActivities()
        {
            return 10;
        }

        public override void NextChallenge()
        {
            currentActivity = activities[0];
            activities.RemoveAt(0);   
        }

        public Activity GetCurrentActivity()
        {
            return currentActivity;
        }

        internal bool HasNextActivity()
        {
            return activities.Count > 0;
        }

        internal bool CheckAnswer(string selectedOption)
        {
            return currentActivity.CheckAnswer(selectedOption);
        }

        internal string GetActivityName(int activity)
        {
            return activities[activity].GetName();
        }
    }
}