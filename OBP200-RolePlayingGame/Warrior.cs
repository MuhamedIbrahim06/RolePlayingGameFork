namespace OBP200_RolePlayingGame;

public class Warrior : BaseCharacterClass
{
    public override string ClassName => "Warrior";
    public override double FleeChance => 0.25;
    public override int SpecialAttackGoldCost => 0;
    public override int SpecialAttackHealthCost => 2;
    public override int LevelUpHpBonus => 6;
    public override int LevelUpAtkBonus => 2;
    public override int LevelUpDefBonus => 2;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        return GetBaseDamage(playerAtk, enemyDef) + 1;
    }

    public override int CalculateSpecialAttack(int playerAtk, int enemyDef)
    { 
        return Math.Max(2, playerAtk + 3 - enemyDef);
    }
    
}