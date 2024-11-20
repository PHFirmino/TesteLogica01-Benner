using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogico01
{
    internal class Network
    {
        private int numbersOfElementsInSet;
        private List<int> list = new List<int>();
        private List<Pairs> pairs = new List<Pairs>();

        private List<int> listFirst = new List<int>();
        private List<int> listSecond = new List<int>();
        public Network()
        {
        }

        public Network(int numbersOfElementsInSetReceived)
        {
            if(numbersOfElementsInSetReceived <= 0)
            {
                throw new MessageException("The value must be greater than zero.");
            }
            else
            {
                numbersOfElementsInSet = numbersOfElementsInSetReceived;

                fillArray(numbersOfElementsInSet);
            }
        }

        public void connect(int valueFirst, int valueSecond)
        {
            if(valueFirst <= 0 && valueSecond <= 0)
            {
                throw new MessageException("The values must be greater than zero.");
            }
            else if(valueFirst.Equals(valueSecond))
            {
                throw new MessageException("The values cannot be the same.");
            }
            else
            {
                if (!list.Contains(valueFirst) || !list.Contains(valueSecond))
                {
                    throw new MessageException("Check the values of one of the numbers not in the list");
                }
                else
                {
                    Pairs values = new Pairs
                    {
                        PairOne = valueFirst,
                        PairTwo = valueSecond
                    };

                    pairs.Add(values);
                }
            }
        }
        public bool query(int valueFirst, int valueSecond)
        {
            if (valueFirst <= 0 && valueSecond <= 0)
            {
                throw new MessageException("The values must be greater than zero.");
            }
            else
            {
                foreach (Pairs item in pairs)
                {
                    if (valueFirst == item.PairOne)
                    {
                        connectionFirstValue(item.PairTwo, valueFirst);
                    }

                    if (valueFirst == item.PairTwo)
                    {
                        connectionFirstValue(item.PairTwo, valueFirst);
                    }
                }

                foreach (Pairs item in pairs)
                {
                    if (valueSecond == item.PairOne)
                    {
                        connectionSecondValue(item.PairOne, valueSecond);
                    }

                    if (valueSecond == item.PairTwo)
                    {
                        connectionSecondValue(item.PairOne, valueSecond);
                    }
                }

                if (listFirst.Contains(valueSecond) && listSecond.Contains(valueFirst))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        private void connectionFirstValue(int item, int valueFirst)
        {
            foreach (Pairs connection in pairs)
            {
                if (connection.PairOne == item && !listFirst.Contains(connection.PairTwo))
                {
                    if (valueFirst != connection.PairTwo)
                    {
                        listFirst.Add(connection.PairTwo);
                    }

                    connectionFirstValue(connection.PairTwo, valueFirst); 
                }
                if (connection.PairTwo == item && !listFirst.Contains(connection.PairOne))
                {
                    if(valueFirst != connection.PairOne)
                    {
                        listFirst.Add(connection.PairOne);
                    }

                    connectionFirstValue(connection.PairOne, valueFirst);
                }
            }
        }
        private void connectionSecondValue(int item, int valueSecond)
        {
            foreach (Pairs connection in pairs)
            {
                if (connection.PairOne == item && !listSecond.Contains(connection.PairTwo))
                {
                    if (valueSecond != connection.PairTwo)
                    {
                        listSecond.Add(connection.PairTwo);
                    }

                    connectionSecondValue(connection.PairTwo, valueSecond);
                }
                if (connection.PairTwo == item && !listSecond.Contains(connection.PairOne))
                {
                    if (valueSecond != connection.PairOne)
                    {
                        listSecond.Add(connection.PairOne);
                    }

                    connectionSecondValue(connection.PairOne, valueSecond);
                }
            }
        }
        private void fillArray(int valor)
        {
            for (int i = 0; i < valor; i++)
            {
               list.Add(i+1);
            }
        }
        public void showList()
        {
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }

        public void showListPairs()
        {
            foreach (var item in pairs)
            {
                Console.Write($" [{item.PairOne}, {item.PairTwo}] ");
            }

            Console.WriteLine();
        }
        public void showListFirst()
        {
            Console.WriteLine("First number set:");
            foreach (var item in listFirst)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }
        public void showListSecond()
        {
            Console.WriteLine("Second number set:");
            foreach (var item in listSecond)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }
        public void clearListFirstAndListSecond()
        {
            listFirst.Clear();
            listSecond.Clear();
        }
    }
}
