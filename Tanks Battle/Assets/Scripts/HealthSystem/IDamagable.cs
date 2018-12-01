namespace Wokarol.HealthSystem
{
    public interface IDamagable
    {
        void Hit(int hitPoints);
        void Heal(int healPoints);
    }
}