using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DrillTap {
    public class Manager : MonoBehaviour {
        public RecourceSettings settings;
        public int currentLayer;
        public Text scoreText;

        private static Manager instance;
        private int score;

        // static instance of the gameManager
        public static Manager Instance
        { 
            get { return instance; }
        }

        void Awake() {
            Layer.onBlockDestroy += Score;
            instance = this;
            settings.Init();
        }

        // Update is called once per frame
        void Score(int addScore) {
            score += addScore;
            scoreText.text = "COINS: " + score.ToString();
        }
    }
}