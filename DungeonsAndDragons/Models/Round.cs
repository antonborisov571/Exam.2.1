namespace Models;

public class Round
{
	public string Attacker { get; set; }
	public string Defender { get; set; }
	public int AttackModifier { get; set; }
	public int[] DiceRoll { get; set; }
	public int[] Damage { get; set; }
	public string[] Strike { get; set; }
	public int[] DefenderHp { get; set; }

}
