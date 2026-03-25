namespace OBP200_RolePlayingGame;

public class Rogue : BaseCharacterClass
{
    public override string ClassName => "Rogue";
    public override double FleeChance => 0.5;
    public override int SpecialAttackGoldCost => 0;
    public override int SpecialAttackHealthCost => 0;
    private static readonly Random _Rng = new Random();
    private const double ChanceToHitSpecial = 0.5;
    public override int LevelUpHpBonus => 5;
    public override int LevelUpAtkBonus => 3;
    public override int LevelUpDefBonus => 1;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        int critBonus = _Rng.NextDouble() < 0.2 ? 4 : 0;
        return GetBaseDamage(playerAtk, enemyDef) + critBonus;
    }

    public override int CalculateSpecialAttack(int playerAtk, int enemyDef)
    {
        if(_Rng.NextDouble() < ChanceToHitSpecial)
        {
            return Math.Max(4, playerAtk + 6);
        }
        else
        {
            return 1;
        }
    }
}