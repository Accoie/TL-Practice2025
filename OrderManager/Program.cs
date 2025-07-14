using OrderManager;

Operation? operation = Operation.MakeOrder;

while ( operation != Operation.Exit )
{
    PrintMenu();
    operation = ReadOperation();
    try
    {
        HandleOperation( operation );
    }
    catch ( OrderManager.InvalidOperationException e )
    {
        Console.WriteLine( e.Message );
    }
}

static void HandleOperation( Operation? operation )
{
    switch ( operation )
    {
        case Operation.MakeOrder:
            MakeOrder();
            break;
        case Operation.Exit:
            Console.WriteLine( "До свидания!" );
            break;
        default:
            throw new OrderManager.InvalidOperationException( "Операция не поддерживается" );
    }
}

static void MakeOrder()
{
    try
    {
        string productName = ReadProductName();
        int countProduct = ReadCountProduct();
        string clientName = ReadClientName();
        string address = ReadAddress();

        PrintApplyMessage( productName, countProduct, clientName, address );
    }
    catch ( FormatException e )
    {
        Console.WriteLine( e.Message );
    }
}

static void PrintApplyMessage( string productName, int productCount, string clientName, string address )
{
    DateTime dateNow = DateTime.Now;
    var deliveryDate = dateNow.AddDays( 3 );

    Console.WriteLine( $"Ваш заказ {productName} в количестве {productCount} оформлен! Ожидайте доставку по адресу {address} к {deliveryDate.ToString( "d.MM.yyyy" )}" );
}

static Operation? ReadOperation()
{
    Console.Write( "Введите код операции: " );

    string operationStr = Console.ReadLine() ?? "";
    bool isParsed = Enum.TryParse( operationStr, out Operation operation );

    return isParsed ? operation : null;
}

static void PrintMenu()
{
    Console.WriteLine( "Меню: Оформить заказ(1)" );
    Console.WriteLine( "      Выход(2)" );
}

static string ReadProductName()
{
    Console.Write( "Введите название товара: " );

    string productName = Console.ReadLine() ?? "";
    if ( productName == "" )
    {
        throw new FormatException( "Название товара не может быть пустым" );
    }

    return productName;
}

static int ReadCountProduct()
{
    Console.Write( "Сколько желаете заказать?: " );

    string countProductStr = Console.ReadLine() ?? "";

    bool isCountProductParsed = int.TryParse( countProductStr, out int countProduct );
    if ( !isCountProductParsed )
    {
        throw new FormatException( "Пожалуйста, введите целое число." );
    }

    if ( countProduct <= 0 )
    {
        throw new FormatException( "Количество не может меньше 1" );
    }

    return countProduct;
}

static string ReadClientName()
{
    Console.Write( "Как вас зовут?: " );

    string clientName = Console.ReadLine() ?? "";
    if ( clientName == "" )
    {
        throw new FormatException( "Имя не может быть пустым" );
    }

    return clientName;
}

static string ReadAddress()
{
    Console.Write( "Куда привезти заказ?: " );

    string address = Console.ReadLine() ?? "";
    if ( address == "" )
    {
        throw new FormatException( "Адрес не может быть пустым" );
    }

    return address;
}
