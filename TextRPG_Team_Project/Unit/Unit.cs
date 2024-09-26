namespace TextRPG_Team_Project
{
    public interface IUnit
    {
        string Name { get; }
        int Level { get; }
        int Health { get; }
        int MaxHealth { get; }
        float Attack { get; }
        int Defense { get; }
        int Gold { get; }
        bool IsDead { get; }

        void TakeDamage(float damage);
    }
}
