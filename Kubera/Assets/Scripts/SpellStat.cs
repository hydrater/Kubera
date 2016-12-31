using UnityEngine;
using System.Collections;

public class SpellStat : MonoBehaviour {
	public double damage;
	public char type, element, effect;
	public float duration, speed;
	public Material mat;

	public GameObject childMaterial;

	public SpellStat()
	{
		
	}

	void Start()
	{
		//childMaterial.GetComponent<Renderer>().material = mat;
	}

}
