namespace OBP200_RolePlayingGame;

public class Player
{
    public ICharacterClass _characterClass;
    public string Name { get; private set; }
    public int HealthPoints { get; private set; }
    public int MaxHealthPoints { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Gold { get; private set; }
    public int Potions { get; private set; }

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
        if (actualDamage < 0)
        {
            actualDamage = 0; //Här väljer jag att göra en kontroll så att damage inte blir negativ
        }

        HealthPoints -= actualDamage;
        
        if (HealthPoints < NoHealthRemaining)
        {
            HealthPoints = NoHealthRemaining; //Här gör jag en kontroll så att en players liv inte blir negativ
        }
    }

    public int GetAttackDamage(int enemyDef)
    {
        int baseDmg = _characterClass.CalculateBaseDamage(Attack, enemyDef);
        return baseDmg + _atkRng.Next(0, 3);
    }

    public int GetSpecialAttackDamage(int enemyDef)
    {
        TakeDamage(_characterClass.SpecialAttackHealthCost);
        return _characterClass.CalculateSpecialAttack(Attack, enemyDef);
    }

    public bool CanAffordSpecialAttack()
    {
        return Gold >= _characterClass.SpecialAttackGoldCost;
    }

    public void SpendGold(int amount)
    {
        if (amount > 0)
        {
            Gold -= amount;
        }
    }
}

