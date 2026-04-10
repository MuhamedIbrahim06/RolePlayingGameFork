namespace OBP200_RolePlayingGame;

public class Player
{
    private ICharacterClass _characterClass;
    public string Name { get; private set; }
    public int HealthPoints { get; private set; }
    public int MaxHealthPoints { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Gold { get; private set; }
    public int Potions { get; private set; }
    protected const int MinDamageVariant = 0;
    protected const int MaxDamageVariant = 3;
    protected const int ZeroDamage = 0;
    const int NoHealthRemaining = 0;
    private static readonly Random _atkRng = new Random();
    
    public Player(ICharacterClass characterclass, string name, int hp, int maxhp, int atk, int def, int gold, int potions)
    {
        _characterClass = characterclass;
        Name = name;
        HealthPoints = hp;
        MaxHealthPoints = maxhp;
        Attack = atk;
        Defense = def;
        Gold = gold;
        Potions = potions;
    }

    public void TakeDamage(int amount)
    {
        int actualDamage = amount - Defense;
        if (actualDamage < ZeroDamage)
        {
            actualDamage = ZeroDamage; 
        }

        HealthPoints -= actualDamage;
        
        if (HealthPoints < NoHealthRemaining)
        {
            HealthPoints = NoHealthRemaining; 
        }
    }

    public int ExecuteBaseAttack(int enemyDef) 
    {
        int baseDmg = _characterClass.CalculateBaseDamage(Attack, enemyDef);
        return baseDmg + _atkRng.Next(MinDamageVariant, MaxDamageVariant);
    }
    public int ExecuteSpecialAttack(int enemyDef, bool isBoss)
    {
        return _characterClass.PerformSpecialAttack(this, enemyDef, isBoss);
    }

    public void SpendGold(int amount)
    {
        if (amount > 0)
        {
            Gold -= amount;
        }
    }
    public void ApplyLevelUp() 
    {
        MaxHealthPoints += _characterClass.LevelUpHpBonus;
        Attack += _characterClass.LevelUpAtkBonus;
        Defense += _characterClass.LevelUpDefBonus;
        HealthPoints = MaxHealthPoints; 
    }
}

