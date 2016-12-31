using UnityEngine;
using System.Collections;

public class SpellStat : MonoBehaviour {
	public double damage;
	public char type, element, effect;
	public float duration, speed, size;
	public Material mat, _mat;
	public GameObject[] childMaterial, _childMaterial;


	public SpellStat()
	{
		
	}

	void Start()
	{
//		foreach (GameObject i in childMaterial)
//			i.GetComponent<Renderer>().material = mat;
//
//		foreach (GameObject i in _childMaterial)
//			i.GetComponent<ParticleSystem>().startSize *= size;
	}

}
