using CarClassLibrary;

Store store = new Store();

Console.Out.WriteLine("Welcome to the car shop! First you must create some cars and put them into the inventory. " +
    "Then you may add cars to the cart. Finally, you may checkout, which will calculate your total bill.");

int action = ChooseAction();

while (action != 0)
{
    switch (action)
    {
        case 1:
            Console.WriteLine("Enter the make of the car: ");
            string make = Console.ReadLine();
            Console.WriteLine("Enter the model of the car: ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter the year of the car: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of the car: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Car car = new Car(make, model, year, price);
            store.CarList.Add(car);
            break;
        case 2:
            PrintStoreInventory();
            Console.WriteLine("Enter the index of the car you would like to add to the car: ");
            int index = int.Parse(Console.ReadLine());
            store.ShoppingList.Add(store.CarList[index]);
            break;
        case 3:
            decimal total = store.Checkout();
            PrintShoppingList();
            Console.WriteLine("Your total is: " + total);
            break;
        case 4:
            FileIO fileIO = new FileIO(store);
            fileIO.SaveInventory();
            break;
        case 5:
            FileIO fileIO2 = new FileIO(store);
            store.CarList = fileIO2.LoadStore();
            break;
        default:
            Console.WriteLine("Invalid choise");
            break;
    }
    PrintStoreInventory();
    action = ChooseAction();
}

int ChooseAction()
{
    int choice = 0;
    Console.WriteLine("Choose an action: (0) Quit (1) Create Car (2) Add car to the cart (3) Checkout (4) Save inventory to a text file (5) Load inventory from text file.");
    choice = int.Parse(Console.ReadLine());
    return choice;
}

void PrintStoreInventory()
{
    Console.WriteLine("Inventory: ");
    for (int i = 0; i < store.CarList.Count; i++)
    {
        Console.WriteLine(i + ": " + store.CarList[i]);
    }
}

void PrintShoppingList()
{
    Console.WriteLine("Shopping List: ");
    for (int i = 0; i < store.ShoppingList.Count; i++)
    {
        Console.WriteLine(i + ": " + store.ShoppingList[i]);
    }
}
