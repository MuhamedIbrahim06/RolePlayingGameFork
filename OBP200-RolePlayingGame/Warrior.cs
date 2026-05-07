namespace OBP200_RolePlayingGame;

public class Warrior : BaseCharacterClass
{
    public override string ClassName => "Warrior";
    public override double FleeChance => 0.25;
    public override int LevelUpHpBonus => 6;
    public override int LevelUpAtkBonus => 2;
    public override int LevelUpDefBonus => 2;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        return GetBaseDamage(playerAtk, enemyDef) + 1;
    }

    public override int PerformSpecialAttack(Player player, int enemyDef, bool vsBoss)
    {
        Console.WriteLine($"Warrior använder Heavy Strike!");
        int damage = Math.Max(2, player.Attack + 3 - enemyDef);
        if (vsBoss) damage = (int)Math.Round(damage * 0.8);
        player.ApplyInternalDamage(2);
        return damage;
    }
    
}