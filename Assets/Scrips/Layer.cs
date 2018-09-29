using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Layer : MonoBehaviour {


        public delegate void OnBlockDestroy(int score);
        public static event OnBlockDestroy onBlockDestroy;
        public RecourceBlock[] blocks;

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
                block.recourceType = GenerateNewRecource();
            }
        }

        public Recource GenerateNewRecource() {
            var rnd = new System.Random();
            return (Recource)rnd.Next(Recource.GetNames(typeof(Recource)).Length);
        }
    }
}
