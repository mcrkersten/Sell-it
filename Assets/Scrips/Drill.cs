using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrillTap {
    public class Drill : MonoBehaviour {
        public float baseDamage = 1f;
        public float permanentDamageMultiplier = 1f;
        public float upgradeDamageMultiplier = 1f;

        List<Boost> boosts = new List<Boost>();

        public void StartBoost(float multiplier, float duration) {
            boosts.Add(new Boost(multiplier, duration));
        }

        public float damageCalculation() {
            float calculatedDamage = baseDamage * permanentDamageMultiplier * upgradeDamageMultiplier;
            for (int i = boosts.Count - 1; i >= 0; --i) {
                if (boosts[i].DurationLeft < 0) {
                    boosts.RemoveAt(i);
                } else {
                    calculatedDamage *= boosts[i].Multiplier;
                }
            }
            return calculatedDamage;
        }
    }

    public struct Boost {
        float multiplier;
        float durationUntil;

        public Boost(float multiplier, float duration) {
            this.multiplier = multiplier;
            durationUntil = Time.time + duration;
        }

        public float Multiplier {
            get { return multiplier; }
        }

        public float DurationLeft {
            get { return durationUntil - Time.time; }
        }
    }
}