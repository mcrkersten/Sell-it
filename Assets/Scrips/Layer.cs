using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Layer : MonoBehaviour {


        public delegate void OnBlockDestroy(int score);
        public static event OnBlockDestroy onBlockDestroy;
        public ResourceBlock[] blocks;

        private int value;
        private int blocksBroken;

        public void Start() {
            GenerateBlock();
        }

        public void GetDestroyed() {
            value = 0;
            if (onBlockDestroy != null) {
                foreach (ResourceBlock block in blocks) {
                    value += ResourceSettings.GetValue(block.resourceType);
                }
                onBlockDestroy(value);
            }
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 4.5f, this.gameObject.transform.position.z);
            Manager.Instance.currentLayer += 1;
            GenerateBlock();
        }

        public void GenerateBlock() {
            blocksBroken = 0;
            int layer = Manager.Instance.currentLayer;
            foreach (ResourceBlock block in blocks) {
                block.GenerateBlock(layer);
            }
        }

        public void OnTriggerStay2D(Collider2D collision) {
            if (collision.gameObject.tag == "Player") {
                float damageLeft = blocks[blocksBroken].Break(collision.gameObject.GetComponent<Drill>().damageCalculation() * Time.deltaTime);
                if (damageLeft > 0f) {
                    blocksBroken++;
                    if (blocksBroken >= blocks.Length) {
                        GetDestroyed();
                    } else {
                        blocks[blocksBroken].Break(damageLeft);
                    }
                }
            }
        }
    }
}
