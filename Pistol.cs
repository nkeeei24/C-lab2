using System;

namespace Lab2
{
    /// <summary>
    /// Пистолет с ограниченным количеством патронов.
    /// </summary>
    public class Pistol
    {
        private const int DefaultAmmo = 5;

        private int _ammo;

        // Без указания патронов пистолет заряжен пятью патронами.
        public Pistol() : this(DefaultAmmo)
        {
        }

        public Pistol(int ammo)
        {
            Ammo = ammo;
        }

        public int Ammo
        {
            get
            {
                return _ammo;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Количество патронов не может быть отрицательным.");
                }

                _ammo = value;
            }
        }

        public void Shoot()
        {
            if (_ammo > 0)
            {
                Console.WriteLine("Бах!");
                _ammo--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

        public override string ToString()
        {
            return $"Пистолет, патронов: {_ammo}";
        }
    }
}
