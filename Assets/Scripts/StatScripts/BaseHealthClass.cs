using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthClass : BaseClass {

	public BaseHealthClass(){
		Id = 1;
		Name = "Luffy";
		Level = 1;
		CurrentEx = 100;
		Health = 30;
		Energy = 10;
		Armor = 20;
		Strength = 20;
		Speed = 30;
		Critical = 500;
		Points = 5;

		Bounty = 0;
		Biography = "\t Monkey D.Luffy là một con người có suy nghĩ đơn giản và yêu thích sự tự do. Cậu ra biển với mong muốn trở thành vua hải tặc - con người tự do nhất của biển...";
		//Regeneration = 0;
	}
}
