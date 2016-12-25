using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

	SpellBlueprint[] spellList = new SpellBlueprint[12];
	
	void addSpell(string[][] spellsToAdd)
	{
		for (int i = 0; i < spellsToAdd.Length; ++i)
		{
			double costMultiplier = 1, damageMultiplier = 1;
			char type;
			if (spellsToAdd[i][0]!=null)
			{
//				double[] temp = classificationReturnMultiplier(spellsToAdd[i][0]);
//				costMultiplier *= temp[0];
//				damageMultiplier *= temp[1];
			}

			//spellsToAdd[i][0]

			//spellList[i] = new spell();
		}
	}

//	void createName(string input)
//	{
//		
//	}
//
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
