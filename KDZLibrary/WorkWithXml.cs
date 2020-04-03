using System;
using System.Collections.Generic;
using System.Xml;

namespace KDZLibrary
{
    public class WorkWithXml
    {
        /// <summary>
        /// Мы записываем команду футболистов игрока в XML, поэтому мы создаем каждый раз элементы 
        /// со всеми статами футболиста.
        /// </summary>
        /// <param name="player">Чью команду будем записывать.</param>
        /// <param name="xDoc">Документ, куда будем записывать.</param>
        static void WriteTeamToXml(Player player, XmlWriter xDoc)
        {
            // Еще один дочерний корневой элемент: <Player2>
            xDoc.WriteStartElement($"{player.Name}");
            for (int i = 0; i < 11; i++)
            {
                // Еще один дочерний корневой элемент: <Footballer>
                xDoc.WriteStartElement("Footballer");
                // Определяем все атрибуты для футболиста.
                xDoc.WriteAttributeString("Name", player.Team[i].Name);
                xDoc.WriteAttributeString("Height_cm", player.Team[i].Height_cm.ToString());
                xDoc.WriteAttributeString("Weight_kg", player.Team[i].Weight_kg.ToString());
                xDoc.WriteAttributeString("Overall", player.Team[i].Overall.ToString());
                xDoc.WriteAttributeString("Potential", player.Team[i].Potential.ToString());
                // Закрываем тег для корневого элемента </Footballer>
                xDoc.WriteEndElement();
            }
            xDoc.WriteEndElement();
        }

        /// <summary>
        /// В этом методе мы будем делать автосохранения каждого раунда со всей нужной информацией,
        /// а особенно, команды игроков, какой раунд, какое логирование.
        /// </summary>
        /// <param name="firstPlayer">Первый игрок.</param>
        /// <param name="secondPlayer">Второй игрок.</param>
        /// <param name="round">Раунд.</param>
        /// <param name="log">Логирование.</param>
        static public void AutoSaveToXml(Player firstPlayer, Player secondPlayer, uint round, string log)
        {
            // Настройки записи в файл. Indent - отступы.
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            // Мы создаем файл c настройками, которые мы сделали.
            XmlWriter xDoc = XmlWriter.Create("saveGame.xml", xmlSettings);

            // Начинаем с создания заголовка, а именно: <?xml version="1.0" encoding="utf-8"?> 
            xDoc.WriteStartDocument();
            // Теперь создаем корневой элемент: <saveGame>
            xDoc.WriteStartElement("saveGame");
            // Записываем команды футболистов.
            WriteTeamToXml(firstPlayer, xDoc);
            WriteTeamToXml(secondPlayer, xDoc);

            // Записываем информацию о игре.
            xDoc.WriteStartElement("InfoGame");
            xDoc.WriteAttributeString("pointPlayer1", firstPlayer.Point.ToString());
            xDoc.WriteAttributeString("pointPlayer2", secondPlayer.Point.ToString());
            xDoc.WriteAttributeString("round", round.ToString());
            xDoc.WriteAttributeString("log", log);
            xDoc.WriteEndElement();

            // Закрываем уже все теги и завершаем любую работу.
            xDoc.WriteEndElement();
            xDoc.WriteEndDocument();
            xDoc.Close();
        }

        /// <summary>
        /// Создание команды из футболистов путем чтения с .xml.
        /// </summary>
        /// <param name="saveGame">Коллекция узлов, с которого мы будем считывать элементы.</param>
        /// <param name="index">По какому индексу считывать.</param>
        /// <returns>Возвращает команду из 11 футболистов.</returns>
        static Footballer[] CreateTeamFromXml(XmlNodeList saveGame, int index)
        {
            // Создаем тиму пидорасов.
            Footballer[] footballers = new Footballer[11];
            int step = 0;

            // Будем вытаскивать по одному узлу и обрабатывать их.
            XmlNode playerXML = saveGame[index];

            // Проверяем на количество футболистов, но это заодно и проверяет на корректность
            // названия элементов.
            if (playerXML.SelectNodes("Footballer").Count != 11)
            {
                throw new Utilites.ErrorException("Пидарасов(ой, футболистов) подозрительно слишком" +
                    " мало... Ломаете, да?");
            }

            // Создаем базу, где будем производить сверку с именами атрибутентов.
            string[] nameAttributesTest = { "Name", "Height_cm", "Weight_kg", "Overall", "Potential" };

            // Теперь мы заходим в каждый узел футболиста внутри игрока. А это
            // именно Footballer...
            foreach (XmlElement footballerXML in playerXML)
            {
                List<string> attributes = new List<string>();
                int testStep = 0;
                // Так как у узла Footballer очень много атрибутов, вроде name, height_cm и
                // так далее, следовательно, мы их будем получать именно циклом.
                // Attributes -- это коллекция атрибутов, а мы будем по одному вытаскивать.
                foreach (XmlAttribute parametrsFootballer in footballerXML.Attributes)
                {
                    if (nameAttributesTest[testStep] == parametrsFootballer.Name)
                    {
                        attributes.Add(parametrsFootballer.Value);
                        testStep++;
                    }
                    else
                    {
                        throw new Utilites.ErrorException("Имена аттрибутов не соотвествуют нужным " +
                            "наименований. Ну хватит уже ломать ХМЛ, ты же этого" +
                            "не хочешь, наверняка... 28 раз ломал код, таблицу, игру, ты действовал " +
                            "наверняка?");
                    }
                }

                try
                {
                    // Создаем футболиста с его параметрами.
                    footballers[step] = (new Footballer(attributes[0], uint.Parse(attributes[1]),
                        uint.Parse(attributes[2]), uint.Parse(attributes[3]), uint.Parse(attributes[4])));
                }
                catch (FormatException)
                {
                    throw new Utilites.ErrorException("Вводишь строковое представление там, где" +
                        "не нужно, да? Ну не выйдет.");
                }
                catch (ArgumentNullException)
                {
                    throw new Utilites.ErrorException("Ой, уже теперь просто пустые пространства" +
                        "или вообще ничего не передаешь? Опять не выйдет.");
                }

                step++;
            }

            return footballers;
        }

        /// <summary>
        /// Считывает информацию с .xml для получения всей информации о игроков, раунда и логирования.
        /// 
        /// В этом методе будет вложена вся моя вселенская боль. А именно... проверка
        /// каждого сранного узла, соотвествие каждого атрибута и так далее. В общем, приятного буедт
        /// мало, тут повстретится вероятно так себе код, но у Вас выбора нет, не так ли?) Но
        /// приятным бонусом будет то, что у вас тут чуть ли не целый гайд по поводу того, как
        /// работает каждая строка, для лучшего понимания XML)
        /// </summary>
        /// <param name="firstPlayer">Первый игрок.</param>
        /// <param name="secondPlayer">Второй игрок.</param>
        /// <param name="round">Раунд.</param>
        /// <param name="log">Логирование.</param>
        static public void ReadFromFile(ref Player firstPlayer, ref Player secondPlayer, out uint round, out string log)
        {
            // Создаем новую документацию.
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("saveGame.xml");
            // Корневой элемент это saveGame. Его и будем получать таким образом:
            XmlElement xRoot = xDoc.DocumentElement;

            // Мы создаем список ВСЕХ узлов, а в нашем случае это Player1, Player2, InfoGame.
            XmlNodeList saveGame = xRoot.ChildNodes;
            // Очень нудная проверка...
            string[] testNameBase = { "Player_1", "Player_2", "InfoGame" };
            for (int i = 0; i < 3; i++)
            {
                if (testNameBase[i] != saveGame[i].Name)
                {
                    throw new Utilites.ErrorException("Вы сломали мои бедные узлы! Нельзя так.");
                }
            }

            // Продолжение в методе......
            firstPlayer = new Player("Player_1", CreateTeamFromXml(saveGame, 0));
            secondPlayer = new Player("Player_2", CreateTeamFromXml(saveGame, 1));

            // Теперь рассмотрим узел InfoGame. Ну тут уже все относительно просто.
            // Мы ищем теперь именно по имени аттрибутов. Потом получаем их значения:
            XmlNode infoGameXML = saveGame[2];

            // Создаем опять базу с нужными названиями аттрибутов.
            string[] nameAttributesBase = { "pointPlayer1", "pointPlayer2", "round", "log"};

            for (int i = 0; i < 4; i++)
            {
                if (nameAttributesBase[i] != infoGameXML.Attributes[i].Name)
                {
                    throw new Utilites.ErrorException("Имена аттрибутов не соотвествуют нужным" +
                            "наименований.");
                }
            }

            // Просто не допускаем некорректных значений.
            try
            {
                firstPlayer.Point = uint.Parse(infoGameXML.Attributes.GetNamedItem("pointPlayer1").Value);
                secondPlayer.Point = uint.Parse(infoGameXML.Attributes.GetNamedItem("pointPlayer2").Value);
                round = uint.Parse(infoGameXML.Attributes.GetNamedItem("round").Value);
                if (round >= 30)
                {
                    throw new Utilites.ErrorException("Раунд не может быть равным 30 или больше!");
                }
                log = infoGameXML.Attributes.GetNamedItem("log").Value;
            }
            catch (FormatException)
            {
                throw new Utilites.ErrorException("Вводишь строковое представление там, где" +
                    "не нужно, да? Ну не выйдет.");
            }
            catch (ArgumentNullException)
            {
                throw new Utilites.ErrorException("Ой, уже теперь просто пустые пространства" +
                    "или вообще ничего не передаешь? Опять не выйдет.");
            }
        }
    }
}
