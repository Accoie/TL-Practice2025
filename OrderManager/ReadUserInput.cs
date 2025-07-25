using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ReadUserInput
    {
        static public Operation ReadOperation()
        {
            Console.Write( "Введите код операции: " );

            string operationStr = Console.ReadLine() ?? string.Empty;
            bool isParsed = Enum.TryParse( operationStr, out Operation operation );

            if ( !isParsed )
            {
                throw new FormatException( $"Операция с номером {operationStr} не поддерживается" );
            }

            return operation;
        }
        static public string ReadProductName()
        {
            Console.Write( "Введите название товара: " );

            string productName = Console.ReadLine() ?? string.Empty;
            if ( string.IsNullOrEmpty( productName ) )
            {
                throw new FormatException( "Название товара не может быть пустым" );
            }

            return productName;
        }

        static public int ReadCountProduct()
        {
            Console.Write( "Сколько желаете заказать?: " );

            string countProductStr = Console.ReadLine() ?? string.Empty;

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

        static public string ReadClientName()
        {
            Console.Write( "Как вас зовут?: " );

            string clientName = Console.ReadLine() ?? string.Empty;
            if ( string.IsNullOrEmpty( clientName ) )
            {
                throw new FormatException( "Имя не может быть пустым" );
            }

            return clientName;
        }

        static public string ReadAddress()
        {
            Console.Write( "Куда привезти заказ?: " );

            string address = Console.ReadLine() ?? string.Empty;
            if ( string.IsNullOrEmpty( address ) )
            {
                throw new FormatException( "Адрес не может быть пустым" );
            }

            return address;
        }
    }
}
