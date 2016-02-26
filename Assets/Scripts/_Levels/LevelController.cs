using Assets.Scripts.App;
using Assets.Scripts.Metrics;
using UnityEngine;

namespace Assets.Scripts._Levels
{

    public abstract class LevelController : MonoBehaviour
    {
        public abstract void NextChallenge();
        public abstract void InitGame();
        public abstract AudioClip GetInstructions();

        internal void LogRightAnswer(int activity)
        {
            MetricsController.GetController().GetCurrentTest().LogRightAnswer(activity);
        }
        internal void LogWrongAnswer(int activity)
        {
            MetricsController.GetController().GetCurrentTest().LogWrongAnswer(activity);
        }
        internal void LogHint(int activity)
        {
            MetricsController.GetController().GetCurrentTest().LogHint(activity);
        }
    }
}
