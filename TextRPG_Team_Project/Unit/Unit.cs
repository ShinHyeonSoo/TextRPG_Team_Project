namespace TextRPG_Team_Project
{
    public interface IUnit
    {
        string Name { get; }
        int Level { get; }
        int Health { get; }
        int Attack { get; }
        int Defense { get; }
        bool IsDead { get; }

        void TakeDamage(int damage);
    }
}
