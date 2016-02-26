using Assets.Scripts.App;
using Assets.Scripts.Metrics;
using UnityEngine;

namespace Assets.Scripts.EndGame
{

    public class EndGame : MonoBehaviour
    {
        void OnEnable()
        {
            MetricsController.GetController().GameEnd();
        }

        public void OnClickNewTest()
        {
            ViewController.GetController().LoadCover();
        }
    }
}