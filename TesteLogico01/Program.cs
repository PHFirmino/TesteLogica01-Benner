namespace TesteLogico01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();
            bool startOne = true;

            while (startOne)
            {
                try
                {
                    Console.WriteLine("Enter a number, which will indicate the number of elements in the set:");
                    string valueReceived = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(valueReceived))
                    {
                        throw new FormatException("Input cannot be empty.");
                    }

                    network = new Network(Convert.ToInt32(valueReceived));
                    startOne = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (MessageException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            network.showList();

            bool decisionOne = true;
            bool decisionTwo = false;
            bool decisionThree = false;

            string responseOne = "0";

            while (decisionOne)
            {

                while(responseOne != "1" && responseOne != "2" && responseOne != "3")
                {
                    Console.WriteLine("Do you want to check connection [1] or do you want to create connection [2] or want to leave [3]:");
                    responseOne = Console.ReadLine();
                }

                switch(responseOne)
                {
                    case "1":
                        responseOne = "0";
                        decisionTwo = true;
                        break;
                    case "2":
                        responseOne = "0";
                        decisionThree = true;
                        break;
                    default:
                        decisionOne = false;
                        break;
                }

                bool startTwo = true;

                while (decisionTwo)
                {
                    while (startTwo)
                    {
                        try
                        {
                            Console.WriteLine("Enter the first connection value:");
                            string valueFirst = Console.ReadLine();

                            Console.WriteLine("Enter the second connection value:");
                            string valueSecond = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(valueFirst) && string.IsNullOrWhiteSpace(valueSecond))
                            {
                                throw new FormatException("Input cannot be empty.");
                            }

                            Console.WriteLine($"Do you have a connection? {network.query(Convert.ToInt32(valueFirst), Convert.ToInt32(valueSecond))}");
                            startTwo = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (MessageException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    network.showListFirst();
                    network.showListSecond();

                    network.clearListFirstAndListSecond();

                    string response = "";

                    while (response != "y" && response != "n")
                    {
                        Console.WriteLine("Do you want to continue [Y/N]:");
                        response = Console.ReadLine().ToLower();

                        if (response == "n")
                        {
                            decisionTwo = false;
                        }

                        startTwo = true;
                    }
                }

                bool startThree = true;

                while (decisionThree)
                {
                    while (startThree)
                    {
                        try
                        {
                            Console.WriteLine("Enter the first value:");
                            string valueFirst = Console.ReadLine();

                            Console.WriteLine("Enter the second value:");
                            string valueSecond = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(valueFirst) && string.IsNullOrWhiteSpace(valueSecond))
                            {
                                throw new FormatException("Input cannot be empty.");
                            }

                            network.connect(Convert.ToInt32(valueFirst), Convert.ToInt32(valueSecond));
                            startThree = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (MessageException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    network.showListPairs();

                    string response = "";

                    while (response != "y" && response != "n")
                    {
                        Console.WriteLine("Do you want to continue [Y/N]:");
                        response = Console.ReadLine().ToLower();

                        if (response == "n")
                        {
                            decisionThree = false;
                        }

                        startThree = true;
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
