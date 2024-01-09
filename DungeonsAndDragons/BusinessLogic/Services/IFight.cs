using Models;

namespace BusinessLogic.Services;

public interface IFight
{
	Result GetFightResult(Monster monster, Player player);
}
