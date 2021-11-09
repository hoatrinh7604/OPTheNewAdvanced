using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStrengthClass : BaseClass {

	public BaseStrengthClass(){
		Id = 3;
		Name = "Zoro";
		Level = 1;
		CurrentEx = 100;
		Health = 20;
		Energy = 20;
		Armor = 10;
		Strength = 30;
		Speed = 30;
		Critical = 500;
		Points = 5;

		Bounty = 0;
		Biography = "\t Roronoa Zoro sinh ra ở Nhật Bản, quá khứ của cậu khá buồn khi người bạn thân nhất qua đời. Từ đó cậu nuôi dưỡng ước mơ của cậu và cả người bạn thân là trở thành kiếm sĩ vĩ đại nhất. Cậu luôn mang theo mình 3 thanh kiếm...";
		//Regeneration = 0;
	}
}
