using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DrillTap {
    [CreateAssetMenu(menuName = "Recource settings")]
    public class RecourceSettings : ScriptableObject {

        [System.Serializable]
        public struct RecourceSetting {
            public Recource recource;
            public Sprite recourceImage;
            public int recourceWaarden;
            public Color particleColor;
            public float strength;
        }

        [SerializeField]
        private RecourceSetting[] types;

        public static RecourceSettings instance;

        public void Init() {
            instance = this;
        }

        public static Sprite GetSprite(Recource recourceType) {
            return instance.types.SingleOrDefault(x => x.recource == recourceType).recourceImage;
        }

        public static int GetWaarden(Recource recourceType) {
            return instance.types.SingleOrDefault(x => x.recource == recourceType).recourceWaarden;
        }

        public static Color GetParticleColor(Recource recourceType) {
            return instance.types.SingleOrDefault(x => x.recource == recourceType).particleColor;
        }

        public static float GetStrength(Recource recourceType) {
            return instance.types.SingleOrDefault(x => x.recource == recourceType).strength;
        }
    }
}

