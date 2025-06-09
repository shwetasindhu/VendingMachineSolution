namespace VendingMachine
{
class Program
{
static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine();
            bool running = true;

            Console.WriteLine("=== VENDING MACHINE SIMULATOR ===");
            Console.WriteLine("Commands:");
            Console.WriteLine("  insert [penny|nickel|dime|quarter] - Insert a coin");
            Console.WriteLine("  select [cola|chips|candy] - Select a product");
            Console.WriteLine("  display - Check the display");
            Console.WriteLine("  return - Return coins");
            Console.WriteLine("  coinreturn - Check coin return");
            Console.WriteLine("  quit - Exit the program");
            Console.WriteLine();

            while (running)
            {
                Console.WriteLine($"Display: {machine.CheckDisplay()}");
                Console.Write("Enter command: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                 string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "insert":
                        if (parts.Length > 1)
                        {
                            HandleInsertCoin(machine, parts[1]);
                        }
                        else
                        {
                            Console.WriteLine("Please specify coin type: penny, nickel, dime, or quarter");
                        }
                        break;

                    case "select":
                        if (parts.Length > 1)
                        {
                            HandleSelectProduct(machine, parts[1]);
                        }
                        else
                        {
                            Console.WriteLine("Please specify product: cola, chips, or candy");
                        }
                        break;

                    case "display":
                        Console.WriteLine($"Display shows: {machine.CheckDisplay()}");
                        break;

                    case "return":
                        machine.ReturnCoins();
                        break;

                    case "coinreturn":
                        var returnedCoins = machine.GetCoinReturn();
                        if (returnedCoins.Count > 0)
                        {
                            Console.WriteLine("Coins in return:");
                            foreach (var coin in returnedCoins)
                            {
                                Console.WriteLine($"  - {coin}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No coins in return");
                        }
                        break;

                    case "quit":
                    case "exit":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Unknown command. Type 'quit' to exit.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using the vending machine!");
        }

        private static void HandleInsertCoin(VendingMachine machine, string coinName)
        {
            switch (coinName.ToLower())
            {
                case "penny":
                    machine.InsertCoin(CoinType.Penny);
                    break;
                case "nickel":
                    machine.InsertCoin(CoinType.Nickel);
                    break;
                case "dime":
                    machine.InsertCoin(CoinType.Dime);
                    break;
                case "quarter":
                    machine.InsertCoin(CoinType.Quarter);
                    break;
                default:
                    Console.WriteLine("Invalid coin type. Use: penny, nickel, dime, or quarter");
                    break;
            }
        }

        private static void HandleSelectProduct(VendingMachine machine, string productName)
        {
            switch (productName.ToLower())
            {
                case "cola":
                    machine.SelectProduct(ProductType.Cola);
                    break;
                case "chips":
                    machine.SelectProduct(ProductType.Chips);
                    break;
                case "candy":
                    machine.SelectProduct(ProductType.Candy);
                    break;
                default:
                    Console.WriteLine("Invalid product. Use: cola, chips, or candy");
                    break;
            }
        }
}
}