namespace OBP200_RolePlayingGame;

public class Mage : ICharacterClass
{
    public string ClassName => "Mage";
    public double FleeChance => 0.35;
    public int SpecialAttackGoldCost => 3;
    public int SpecialAttackHealthCost => 0;

    public int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        int baseDmg = Math.Max(1, playerAtk - (enemyDef / 2));
        return baseDmg += 2;
    }

    public int CalculateSpecialAttack(int playerAtk, int enemyDef)
    {
        return Math.Max(3, playerAtk + 5 - (enemyDef / 2));
    }
}