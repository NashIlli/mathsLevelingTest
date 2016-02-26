using UnityEngine;
using Assets.Scripts.App;
using Assets.Scripts.Metrics;

namespace Assets.Scripts.Login
{

    public class LoginController : MonoBehaviour
    {
        private static LoginController loginController;
        public LoginView loginView;


        void Awake(){
            if (loginController == null){
                loginController = this;
            }else if (loginController != this){
                Destroy(gameObject);
            }
        }

        public void SaveUsername(string username){
            if(username != "" && username.Length > 2 && loginView.GetChallengeSelected() != -1)
            {
                AppController.GetController().SetUsername(username);
                AppController.GetController().SetChallenge(loginView.GetChallengeSelected());
                ViewController.GetController().LoadMathsGame();
                MetricsController.GetController().LoadFromDisk(username);

            } else{
                loginView.ShowIncorrectInputAnimation();
            }

        }

        internal void GoBack() {
            ViewController.GetController().LoadCover();
        }

        public static LoginController GetController(){
            return loginController;
        }
    }
}
