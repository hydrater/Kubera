using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Classification")]
public class Classification : ScriptableObject {
	public string objectName = "New MyScriptableObject";
	public double damageMultiplier, costMultiplier;
	public float castTimeMultiplier;
	public Vector3 size;
}
