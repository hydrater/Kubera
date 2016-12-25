using UnityEngine;
using System.Collections;

public class SpellBlueprint : MonoBehaviour {

	readonly string name;
	readonly Material mat;
	readonly int damage, cost;
	readonly char effect, element;
	readonly float castTime, duration, speed;

	public SpellBlueprint(string[] input)
	{
		string name = input[0];
	}
}
