using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Stem")]
public class Stem : ScriptableObject {
	public int baseDamage, baseCost;
	public float baseCastTime;
}
