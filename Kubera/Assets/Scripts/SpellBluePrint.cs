using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpellBlueprint {

	public string spellName;
	public Material mat, _mat;
	public double damage, cost;
	public char type, element, effect;
	public float castTime, duration, speed;
	public int size;
	public GameObject projectile;

	public SpellBlueprint(string _name, double _damage, double _cost, float _castTime, 
	int _size, string _projectile, char _element, string _mat1, string _mat2, char _type)
	{
		spellName = _name;
		damage = _damage;
		cost = _cost;
		castTime = _castTime;
		size = _size;
		projectile = Resources.Load(string.Format("SuffixObj/{0}", _projectile)) as GameObject;
		mat = Resources.Load(string.Format("PrefixObj/{0}", _mat1)) as Material;
		_mat = Resources.Load(string.Format("PrefixObj/_{0}", _mat2)) as Material;
		element = _element;
		type = _type;
	}


}
