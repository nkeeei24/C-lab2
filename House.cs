using System;

namespace Lab2
{
    /// <summary>
    /// Дом с неизменяемым количеством этажей.
    /// </summary>
    public class House
    {
        private readonly int _floors;

        public House(int floors)
        {
            if (floors < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(floors),
                    "В доме должен быть хотя бы один этаж.");
            }

            _floors = floors;
        }

        // Свойство только для чтения: после создания дома этажность изменить нельзя.
        public int Floors
        {
            get
            {
                return _floors;
            }
        }

        public override string ToString()
        {
            return $"дом с {_floors} {GetFloorsWord()}";
        }

        private string GetFloorsWord()
        {
            // "с 1 этажом", "с 21 этажом", но "с 11 этажами".
            bool endsWithOne = _floors % 10 == 1 && _floors % 100 != 11;

            return endsWithOne ? "этажом" : "этажами";
        }
    }
}
