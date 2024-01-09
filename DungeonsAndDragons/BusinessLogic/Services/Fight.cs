using Models;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic.Services;

public class Fight : IFight
{
	private readonly Random rnd = new Random();

	public Result GetFightResult(Monster monster, Player player)
	{
		var result = new Result() { Rounds = new List<Round>()};

		while (monster.HitPoints > 0 && player.HitPoints > 0)
		{
			if (player.HitPoints > 0)
			{
				result.Rounds.Add(GetRoundResult(monster, player, true));
			}

			if (monster.HitPoints > 0)
			{
				result.Rounds.Add(GetRoundResult(monster, player, false));
			}
		}
		result.Winner = player.HitPoints > 0 ? player.Name : monster.Name;
		return result;
	}

	private Round GetRoundResult(IEntity monster, IEntity player, bool attackPlayer)
    {
        var attacker = player;
        var defender = monster;
        if (!attackPlayer)
        {
            (attacker, defender) = (defender, attacker);
        }

        var round = InitRound(attacker, defender);

        var throws = int.Parse(attacker.Damage.Split('d')[0]);
        var dice = int.Parse(attacker.Damage.Split('d')[1]);
        round.AttackModifier = attacker.AttackModifier;

        for (var i = 0; i < attacker.AttackPerRound && defender.HitPoints > 0; i++)
        {
            var hitRoll = rnd.Next(1, 21);
            round.DiceRoll[i] = hitRoll;
            round.DefenderHp[i] = defender.HitPoints;
            if (hitRoll == 1 || round.DiceRoll[i] + attacker.AttackModifier < defender.ArmorClass)
            {
                round.Strike[i] = "Промах";
                continue;
            }

            if (hitRoll == 20)
            {
                round.Strike[i] = "Критическое попадание";
            }
            else
            {
                round.Strike[i] = "Попадание";
            }

            for (var _ = 0; _ < throws; _++)
            {
                round.Damage[i] += rnd.Next(1, dice + 1);
            }

            if (hitRoll == 20)
            {
                round.Damage[i] += attacker.DamageModifier;
                round.Damage[i] *= 2;
            }

            defender.HitPoints -= Math.Min(defender.HitPoints, round.Damage[i]);
            round.DefenderHp[i] = defender.HitPoints;
            if (defender.HitPoints == 0) break;
        }

        return round;
    }

    private Round InitRound(IEntity attacker, IEntity defender)
    {
        var round = new Round();
        round.Attacker = attacker.Name;
        round.Defender = defender.Name;
        round.DiceRoll = new int[attacker.AttackPerRound];
        round.Damage = new int[attacker.AttackPerRound];
        round.DefenderHp = new int[attacker.AttackPerRound];
        round.Strike = new string[attacker.AttackPerRound];
        return round;
    }
}
