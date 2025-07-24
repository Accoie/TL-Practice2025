using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ConsolePrinter( string productName, int productCount, string address )
    {
        public void PrintApplyMessage()
        {
            DateTime dateNow = DateTime.Now;
            DateTime deliveryDate = dateNow.AddDays( 3 );

            Console.WriteLine( $"Ваш заказ {productName} в количестве {productCount} оформлен! Ожидайте доставку по адресу {address} к {deliveryDate.ToString( "d.MM.yyyy" )}" );
        }
        static public void PrintMenu()
        {
            Console.WriteLine( "Меню: Оформить заказ(1)" );
            Console.WriteLine( "      Выход(2)" );
        }
    }
}
