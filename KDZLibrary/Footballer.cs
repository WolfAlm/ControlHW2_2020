using System;

namespace KDZLibrary
{
    public class Footballer
    { 
        /// <summary>
        /// Имя футболиста.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Рост в сантиметрах футболиста.
        /// </summary>
        public uint Height_cm {get; protected set;}

        /// <summary>
        /// Вес в килограммах футболиста.
        /// </summary>
        public uint Weight_kg { get; protected set; }

        /// <summary>
        /// Числовой показатель скилла футболиста.
        /// </summary>
        public uint Overall { get; protected set; }

        /// <summary>
        /// Потенциал футболиста, то есть, к чему будет стремиться overall.
        /// </summary>
        public uint Potential { get; protected set; }
        
        /// <summary>
        /// Создаем футболиста с его параметрами.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="height">Рост.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="overall">В целом.</param>
        /// <param name="potential">Потенциал.</param>
        public Footballer(string name, uint height, uint weight, uint overall, uint potential)
        {
            Name = name;
            Height_cm = height;
            Weight_kg = weight;
            Overall = overall;
            Potential = potential;
        }

        /// <summary>
        /// Считаем стату футболиста. (double) чтобы не было преполненеия))))))))))))))))))
        /// </summary>
        public double Stats 
        { 
            get
            {
                return ((((double)Height_cm - (double)Weight_kg) / 10.0) * Overall) / Math.Max((double)Overall - (double)Potential, 1);
            }
        }

        /// <summary>
        /// Метод форматирует всю информацию о футболисте в удобном нам виде.
        /// </summary>
        /// <returns>Возвращает строковое представление информации футболиста.</returns>
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Height_cm: {Height_cm}\n" +
                $"Weight_kg: {Weight_kg}\n" +
                $"Overall: {Overall}\n" +
                $"Potential: {Potential}\n";
        }
    }
}