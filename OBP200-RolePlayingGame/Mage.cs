namespace OBP200_RolePlayingGame;

public class Mage : BaseCharacterClass
{
    public override string ClassName => "Mage";
    public override double FleeChance => 0.35;
    public override int SpecialAttackGoldCost => 3;
    public override int SpecialAttackHealthCost => 0;
    public override int LevelUpHpBonus => 4;
    public override int LevelUpAtkBonus => 4;
    public override int LevelUpDefBonus => 1;

    public override int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        return GetBaseDamage(playerAtk, enemyDef) + 2;
    }

    public override int CalculateSpecialAttack(int playerAtk, int enemyDef)
    {
        return Math.Max(3, playerAtk + 5 - (enemyDef / 2));
    }
}