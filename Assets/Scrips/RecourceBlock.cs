using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class RecourceBlock : MonoBehaviour {
        public Recource recourceType;


        public void setSprite(Sprite sprite) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
