using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Manager : MonoBehaviour {
        private static Manager instance;
        public RecourceSettings settings;

        public static Manager Instance
        { // static instance of the gameManager
            get { return instance; }
        }

        void Awake() {
            instance = this;
            settings.Init();
        }
    }
}