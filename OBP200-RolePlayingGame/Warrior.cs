namespace OBP200_RolePlayingGame;

public class Warrior : ICharacterClass
{
    public string ClassName => "Warrior";
    public double FleeChance => 0.25;
    public int SpecialAttackGoldCost => 0;
    public int SpecialAttackHealthCost => 2;

    public int CalculateBaseDamage(int playerAtk, int enemyDef)
    {
        int baseDmg = Math.Max(1, playerAtk - (enemyDef / 2));
        return baseDmg + 1;
    }

    public int CalculateSpecialAttack(int playerAtk, int enemyDef)
    { 
        return Math.Max(2, playerAtk + 3 - enemyDef);
    }
    
}