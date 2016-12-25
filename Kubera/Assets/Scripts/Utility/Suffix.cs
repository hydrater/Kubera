using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Suffix")]
public class Suffix : ScriptableObject {
	public int baseDamage, baseCost, baseCastTime;
	public GameObject Projectile;
	public float speed;
	public char type;

}
