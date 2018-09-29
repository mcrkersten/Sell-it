using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Layer : MonoBehaviour {


        public delegate void OnBlockDestroy(int score);
        public static event OnBlockDestroy onBlockDestroy;
        public RecourceBlock[] blocks;
        private System.Random rnd = new System.Random();

        private int value;

        public void Start() {
            GenerateBlock();
        }

        public void GetDestroyed() {
            
            if (onBlockDestroy != null) {
                foreach (RecourceBlock block in blocks) {
                    value += RecourceSettings.GetWaarden(block.recourceType);
                }
                onBlockDestroy(value);
            }
        }

        public void GenerateBlock() {
            foreach(RecourceBlock block in blocks) {
                block.recourceType = GenerateNewRecourceLayer();
                block.setSprite(RecourceSettings.GetSprite(block.recourceType));
            }
        }

        public Recource GenerateNewRecourceLayer() {
            return (Recource)rnd.Next(Recource.GetNames(typeof(Recource)).Length);
        }
    }
}
