using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Manager : MonoBehaviour {
        public RecourceSettings settings;
        public int currentLayer;

        private static Manager instance;
        private int score;
        

        public static Manager Instance
        { // static instance of the gameManager
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
        }
    }
}