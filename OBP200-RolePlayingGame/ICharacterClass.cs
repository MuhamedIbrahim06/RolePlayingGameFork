namespace OBP200_RolePlayingGame;

public interface ICharacterClass
{
    string ClassName { get; }
    int CalculateBaseDamage(int playerAtk, int enemyDef);
    int PerformSpecialAttack(Player player, int enemyDef, bool vsBoss);
    double FleeChance { get; }
    int LevelUpHpBonus { get; }
    int LevelUpAtkBonus { get; }
    int LevelUpDefBonus { get; }
}