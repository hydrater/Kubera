using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Prefix")]
public class Prefix : ScriptableObject {
	public Material mat;
	public int baseDamage, baseCost;
	public char element, effect;
}
