using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Layer : MonoBehaviour {


        public delegate void OnBlockDestroy(int score);
        public static event OnBlockDestroy onBlockDestroy;
        public RecourceBlock[] blocks;

        private int value;
        private float layerStrength;

        public void Start() {
            GenerateBlock();
        }

        public void GetDestroyed() {
            value = 0;
            if (onBlockDestroy != null) {
                foreach (RecourceBlock block in blocks) {
                    value += RecourceSettings.GetWaarden(block.recourceType);
                }
                onBlockDestroy(value);
            }
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 4.5f, this.gameObject.transform.position.z);
            GenerateBlock();
        }

        public void GenerateBlock() {
            foreach(RecourceBlock block in blocks) {
                block.recourceType = (Recource)(UnityEngine.Random.Range(0, System.Enum.GetNames(typeof(Recource)).Length));
                block.SetSprite(RecourceSettings.GetSprite(block.recourceType));
                layerStrength += RecourceSettings.GetStrength(block.recourceType);
            }
        }

        public void OnTriggerStay2D(Collider2D collision) {
            if(collision.gameObject.tag == "Player") {
                print("YES");
                layerStrength -= collision.gameObject.GetComponent<Drill>().damageCalculation();
            }
            if(layerStrength <= 0) {
                GetDestroyed();
            }
        }
    }
}
