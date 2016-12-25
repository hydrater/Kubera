using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

	SpellBlueprint[] spellList = new SpellBlueprint[12];
	string[,] tempSpell = new string[,]
	{
		{"teo", "test_","test","test"}
	};

	void Start()
	{
		addSpell(tempSpell);
	}

	void addSpell(string[,] spellsToAdd)
	{
		for (int i = 0; i < spellsToAdd.GetLength(0); ++i)
		{
			string name = createName(spellsToAdd[i,0], spellsToAdd[i,1], spellsToAdd[i,2], spellsToAdd[i,3]);

			double costMultiplier = 1, damageMultiplier = 1;
			float castTimeMultiplier = 1;

			if (spellsToAdd[i,0]!=null)
			{
				Classification temp = Resources.Load(string.Format("Classification/{0}", spellsToAdd[i,0])) as Classification;
				costMultiplier *= temp.costMultiplier;
				damageMultiplier *= temp.damageMultiplier;
				castTimeMultiplier *= temp.castTimeMultiplier;
			}

			Material mat;





			//spellList[i] = new spell();
		}
	}

	string createName(string input0, string input1, string input2, string input3)
	{
		string value = string.Format("{0}{1}{2}{3}", input0, input1, input2, input3);
		value = value.Replace("_"," ");
		value = char.ToUpper(value[0]) + value.Substring(1);
		for (int i = 2; i < value.Length; ++i)
		{
			if (value[i] == ' ')
			{
				value = string.Format("{0}{1}{2}", value.Substring(0,i+1), char.ToUpper(value[i+1]), value.Substring(i+2));
				break;
			}
		}

		return value;
	}

//	double[] classificationReturnMultiplier(string ID)
//	{
//		double[] value = new double[2];
//		switch(ID)
//		{
//			case "00":
//			value[0] = 1;
//			value[1] = 1;
//			break;
//
//		}
//
//		return value;
//	}
//
//	char classificationReturnType(string ID)
//	{
//		switch(ID)
//		{
//			case "00":
//			return 'A';
//			break;
//		}
//
//	}
}
