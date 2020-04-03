namespace KDZLibrary
{
    public class CSVParser
    {
        /// <summary>
        /// Проверяет полученный массив на корректность данных, в данном случае нам нужно проверить,
        /// что все столбцы, в которых хранятся данные в цифрах, являются положительным числом и никак
        /// иначе. Если ячейка с данными некорректна, то мы с помощью рандома сгенерируем любое число.
        /// Также, если ячейки, где названия/имена и тд, пустые, то мы генерируем случайно из
        /// готовых маленьких баз.
        /// </summary>
        /// <param name="array">Массив(строка), которого нужно проверить.</param>
        /// <param name="quantityErrors">Количество ошибок.</param>
        /// <returns>Возвращает требуемый массив.</returns>
        public string[] CheckOnCorrect(string[] array, out int quantityErrors)
        {
            quantityErrors = 0;

            // Готовые базы из названий клубов, наций, имен.
            string[] nameClub = {"Manchester City", "FC Barcelona", "Paris Saint-Germain", "Inter",
                "Real Madrid", "Arsenal", "Liverpool", "Tottenham Hotspur"};
            string[] nationality = { "Poland", "Spain", "France", "Argentina", "France", "Brazil",
                "England", "Denmark" };
            string[] name = { "C.Immobile", "A.Lacazette", "M.de Ligt", "G.Donnarumma", "F.de Jong",
                "R.Varane", "Isco", "Roberto Firmino" };

            for (int i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case 0:
                    case 4:
                    case 6:
                    case 7:
                    case 10:
                    case 11:
                        // Если ячейка некорректна, то будет сгенерировано случайное число.
                        if ((array[i] == null) || !(uint.TryParse(array[i], out uint res)))
                        {
                            int randomValue;
                            if (i == 4)
                                randomValue = Utilites.random.Next(18, 35);
                            else if (i == 6)
                                randomValue = Utilites.random.Next(165, 210);
                            else if (i == 7 || i == 10 || i == 11)
                                randomValue = Utilites.random.Next(65, 100);
                            else
                                randomValue = Utilites.random.Next(10000, 40000);

                            array[i] = randomValue.ToString();
                            quantityErrors++;
                        }
                        break;
                    default:
                        // Если ячейки с строковыми представлениями пустые, то будет случайно
                        // выбираться данные из массивов для каждого случая.
                        if ((array[i].Replace(" ", "") == "") || (array[i] == null))
                        {
                            if (i == 2 || i == 3)
                                array[i] = name[Utilites.random.Next(0, 8)];
                            else if (i == 8)
                                array[i] = nationality[Utilites.random.Next(0, 8)];
                            else if (i == 9)
                                array[i] = nameClub[Utilites.random.Next(0, 8)];
                            else
                                array[i] = "-";

                            quantityErrors++;
                        }
                        break;
                }
            }

            return array;
        }
    }
}