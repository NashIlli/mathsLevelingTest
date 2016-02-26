using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts._Levels.MathsGame
{

    public class Activity
    {
        private string name;
        private string instructionAudio;
        private string instructionText;
        private string[] options;
        private int correct;
        private string img;
        private string hintImg;
        private int index;

        public Activity(string name, string instructionAudio, string instructionText, string[] options, int correct, string img, string hintImg, int index)
        {
            this.name = name;
            this.instructionAudio = instructionAudio;
            this.instructionText = instructionText;
            this.options = options;
            this.correct = correct;
            this.img = img;
            this.hintImg = hintImg;
            this.index = index;
        } 

        public string GetName()
        {
            return name;
        }

        public string GetInstructionAudio()
        {
            return instructionAudio;
        }

        public string GetInstructionText()
        {
            return instructionText;
        }

        internal bool CheckAnswer(string selectedOption)
        {
            return selectedOption == options[correct];
        }

        public string[] GetOptions()
        {
            return options;
        }

        public int GetCorrect()
        {
            return correct;
        }

        public string GetImg()
        {
            return img;
        }

        public string GetHintImg()
        {
            return hintImg;
        }

        internal int GetIndex()
        {
            return index;
        }
    }
}