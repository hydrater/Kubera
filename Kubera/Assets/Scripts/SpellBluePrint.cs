using UnityEngine;
using System.Collections;

public class SpellBlueprint : MonoBehaviour {

	readonly string name;
	readonly Material mat;
	readonly double damage, cost;
	readonly char type, element, effect;
	readonly float castTime, duration, speed;
	readonly int size;
	readonly GameObject projectile;

	public SpellBlueprint(string _name, double _damage, double _cost, float _castTime, 
	int _size, string _projectile, char _element, string _mat, char _type)
	{
		name = _name;
		damage = _damage;
		cost = _cost;
		castTime = _castTime;
		size = _size;
		projectile = Resources.Load(string.Format("SuffixObj/{0}", _projectile)) as GameObject;
		mat = Resources.Load(string.Format("PrefixObj/{0}", _mat)) as Material;
		element = _element;
		type = _type;
	}

	public void executeSpell()
	{
		SpellStat temp = Instantiate(projectile).GetComponent<SpellStat>() as SpellStat;
		temp = new SpellStat();
		//assign into spell stat
	}
}
