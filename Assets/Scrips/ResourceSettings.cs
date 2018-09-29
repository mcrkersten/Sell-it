using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DrillTap {
    [CreateAssetMenu(menuName = "Resource settings")]
    public class ResourceSettings : ScriptableObject {

        [System.Serializable]
        public struct ResourceSetting {
            public Resource resource;
            public Sprite resourceImage;
            public int resourceValue;
            public Color particleColor;
            public float strength;
        }

        [SerializeField]
        private ResourceSetting[] types;

        public static ResourceSettings instance;

        public void Init() {
            instance = this;
        }

        public static Sprite GetSprite(Resource resourceType) {
            return instance.types.SingleOrDefault(x => x.resource == resourceType).resourceImage;
        }

        public static int GetValue(Resource resourceType) {
            return instance.types.SingleOrDefault(x => x.resource == resourceType).resourceValue;
        }

        public static Color GetParticleColor(Resource resourceType) {
            return instance.types.SingleOrDefault(x => x.resource == resourceType).particleColor;
        }

        public static float GetStrength(Resource resourceType) {
            return instance.types.SingleOrDefault(x => x.resource == resourceType).strength;
        }
    }
}

