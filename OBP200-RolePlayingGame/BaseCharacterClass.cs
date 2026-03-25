namespace OBP200_RolePlayingGame;

public abstract class BaseCharacterClass : ICharacterClass
{
    public abstract string ClassName { get; }
    public abstract double FleeChance { get; }
    public abstract int SpecialAttackGoldCost { get; }
    public abstract int SpecialAttackHealthCost { get; }
    public abstract int CalculateBaseDamage(int playerAtk, int enemyDef);
    public abstract int CalculateSpecialAttack(int playerAtk, int enemyDef);

    protected int GetBaseDamage(int playerAtk, int enemyDef)
    {
        return Math.Max(1, playerAtk - (enemyDef / 2));
    }
}