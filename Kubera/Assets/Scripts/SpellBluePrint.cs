using UnityEngine;
using System.Collections;

public class SpellBlueprint : MonoBehaviour {

	public string spellName;
	public Material mat;
	public double damage, cost;
	public char type, element, effect;
	public float castTime, duration, speed;
	public int size;
	public GameObject projectile;

	public SpellBlueprint(string _name, double _damage, double _cost, float _castTime, 
	int _size, string _projectile, char _element, string _mat, char _type)
	{
		spellName = _name;
		damage = _damage;
		cost = _cost;
		castTime = _castTime;
		size = _size;
		projectile = Resources.Load(string.Format("SuffixObj/{0}", _projectile)) as GameObject;
		mat = Resources.Load(string.Format("PrefixObj/{0}", _mat)) as Material;
		element = _element;
		type = _type;
	}


}
