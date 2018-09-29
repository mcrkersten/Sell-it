using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Drill : MonoBehaviour {
        private int score;

        // Use this for initialization
        void Start() {
            Layer.onBlockDestroy += Score;
        }

        // Update is called once per frame
        void Score(int addScore) {
            score += addScore;
        }
    }
}