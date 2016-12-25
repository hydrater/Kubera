using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Classification")]
public class Classification : ScriptableObject {
	public double damageMultiplier, costMultiplier;
	public char Type;
}
