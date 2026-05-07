namespace OBP200_RolePlayingGame;

public class Mage : BaseCharacterClass
{
    public override string ClassName => "Mage";
    public override double FleeChance => 0.35;
    public override int LevelUpHpBonus => 4;
    public override int LevelUpAtkBonus => 4;
    public override int LevelUpDefBonus => 1;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        return GetBaseDamage(playerAtk, enemyDef) + 2;
    }

    public override int PerformSpecialAttack(Player player, int enemyDef, bool vsBoss)
    {
        if (player.Gold >= 3)
        {
            Console.WriteLine($"Mage kastar Fireball!");
            player.SpendGold(3);
            int damage = (int)Math.Max(3, player.Attack + 5 - (enemyDef / 2));
            if (vsBoss) damage = (int)Math.Round(damage * 0.8);
            return damage;
        }
        else
        {
            Console.WriteLine($"Inte tillräckligt med guld för att kasta Fireball (kostar 3).");
            return 0;
        }
    }
}