using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class ResourceBlock : MonoBehaviour {
        public Resource resourceType;
        public float strength;

        public void Init(Resource resourceType) {
            this.resourceType = resourceType;
            strength = ResourceSettings.GetStrength(resourceType);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ResourceSettings.GetSprite(resourceType);
        }

        public void GenerateBlock(int layer) {
            int resourceLayer = layer / Manager.Instance.resourceLayerSize;
            if (Random.value < 0.5f) { Init((Resource)Mathf.Clamp(resourceLayer, 0, System.Enum.GetNames(typeof(Resource)).Length - 1)); }
            float layerDepth = (layer % Manager.Instance.resourceLayerSize) / (float)Manager.Instance.resourceLayerSize;
            if (Random.value < layerDepth) {
                Init((Resource)Mathf.Clamp(resourceLayer + 1, 0, System.Enum.GetNames(typeof(Resource)).Length - 1));

            } else {
                Init((Resource)Mathf.Clamp(resourceLayer - 1, 0, System.Enum.GetNames(typeof(Resource)).Length - 1));
            }
        }
    }
}
