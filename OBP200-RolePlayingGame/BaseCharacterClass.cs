namespace OBP200_RolePlayingGame;

public abstract class BaseCharacterClass : ICharacterClass
{
    public abstract string ClassName { get; }
    public abstract double FleeChance { get; }
    public abstract int SpecialAttackGoldCost { get; }
    public abstract int SpecialAttackHealthCost { get; }
    public abstract int CalculateBaseDamage(int playerAtk, int enemyDef);
    public abstract int CalculateSpecialAttack(int playerAtk, int enemyDef);
    public abstract int LevelUpHpBonus { get; }
    public abstract int LevelUpAtkBonus { get; }
    public abstract int LevelUpDefBonus { get; }
    protected const int MinimumDamage = 1;
    protected const int DefenseDivider = 2;

    protected int GetBaseDamage(int playerAtk, int enemyDef)
    {
        return Math.Max(MinimumDamage, playerAtk - (enemyDef / DefenseDivider));
    }
}