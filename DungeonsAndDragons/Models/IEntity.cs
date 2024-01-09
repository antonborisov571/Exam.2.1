﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models;

public interface IEntity
{
	public string Name { get; set; }
	public int HitPoints { get; set; }
	public int AttackModifier { get; set; }
	public int AttackPerRound { get; set; }
	public string Damage { get; set; }
	public int DamageModifier { get; set; }
	public int ArmorClass { get; set; }
}
