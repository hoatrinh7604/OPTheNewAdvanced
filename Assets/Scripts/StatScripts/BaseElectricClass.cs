using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseElectricClass : BaseClass {

	public BaseElectricClass(){
		Id = 4;
		Name = "Enel";
		Level = 1;
		CurrentEx = 100;
		Health = 30;
		Energy = 30;
		Armor = 30;
		Strength = 40;
		Speed = 35;
		Critical = 500;
		Points = 5;

		Bounty = 0;
		Biography = "\t Enel là người của tộc sinh sống ở trên mặt trăng. Anh có khả năng tạo và điều khiển tia sét...";
		//Regeneration = 0;
	}
}
