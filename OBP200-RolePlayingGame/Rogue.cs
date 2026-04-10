namespace OBP200_RolePlayingGame;

public class Rogue : BaseCharacterClass
{
    public override string ClassName => "Rogue";
    public override double FleeChance => 0.5;
    private static readonly Random _Rng = new Random();
    private const double ChanceToHitSpecial = 0.5;
    public override int LevelUpHpBonus => 5;
    public override int LevelUpAtkBonus => 3;
    public override int LevelUpDefBonus => 1;
    private const double CritChance = 0.2;
    private const int CritBonusDamage = 4;
    private const int NoCritBonus = 0;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        int critBonus = _Rng.NextDouble() < CritChance ? CritBonusDamage : NoCritBonus;
        return GetBaseDamage(playerAtk, enemyDef) + critBonus;
    }

    public override int PerformSpecialAttack(Player player, int enemyDef, bool vsBoss)
    {
        if(_Rng.NextDouble() < ChanceToHitSpecial)
        {
            Console.WriteLine($"{player.Name} utför en lyckad Backstab!");
            int damage = Math.Max(4, player.Attack + 6);
            if (vsBoss) damage = (int)Math.Round(damage * 0.8);
            return damage;
        }
        else
        {
            Console.WriteLine("Backstab misslyckades!");
            return 1;
        }
    }
}