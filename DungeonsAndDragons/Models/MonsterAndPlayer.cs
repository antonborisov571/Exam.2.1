namespace Models;

public class MonsterAndPlayer
{
	public Monster Monster { get; set; }
	public Player Player { get; set; }

	public MonsterAndPlayer(Monster monster, Player player)
	{
		Monster = monster;
		Player = player;
	}
}
