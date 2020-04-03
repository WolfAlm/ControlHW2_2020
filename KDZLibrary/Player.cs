namespace KDZLibrary
{
    public class Player
    {
        /// <summary>
        /// На вход мы получаем готовую команду из 11 футболистов и будем оперировать ими для
        /// дальнейших действий и вывода информаций.
        /// </summary>
        /// <param name="name">Имя игрока.</param>
        /// <param name="team">Команда из футболистов.</param>
        public Player(string name, Footballer[] team)
        {
            Name = name;
            Team = team;
        }

        /// <summary>
        /// Мы для удобства создали пустой конструктор, чтобы было удобно инициализировать.
        /// </summary>
        public Player()
        {
        }

        /// <summary>
        /// Футбольная команда, где будем создавать 11 футболистов.
        /// </summary>
        public Footballer[] Team { get; set; }

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Будет сравнение характеристики между футболистами.
        /// </summary>
        /// <param name="attackFootballer">Атакующий футболист.</param>
        /// <param name="defendFootballer">Обороняющийся футболист.</param>
        /// <returns>Возвращает true, если атакующий выиграл.</returns>
        public bool Fight(Footballer attackFootballer, Footballer defendFootballer)
        {
            return attackFootballer.Stats > defendFootballer.Stats;
        }

        /// <summary>
        /// Счетчик голов у игрока.
        /// </summary>
        public uint Point { get; set; } = 0;
    }
}
