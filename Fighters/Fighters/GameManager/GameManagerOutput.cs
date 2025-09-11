using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.GameManager
{
    public class GameManagerOutput
    {
        public static void ShowFighters( IReadOnlyList<IFighter> fighters )
        {
            Console.WriteLine( "Список бойцов:" );

            for ( int i = 0; i != fighters.Count; i++ )
            {
                Console.WriteLine( $"{i + 1}. {fighters[ i ].Name}" );
            }
        }

        public static void PrintExceptionMessage( string e )
        {
            Console.WriteLine( e );
        }

        public static void PrintFighterNotFound( string fighterName )
        {
            Console.WriteLine( $"Боец {fighterName} не найден!" );
        }

        public static void PrintFighterRemoved( string fighterName )
        {
            Console.WriteLine( $"Боец {fighterName} удален!" );
        }

        public static void PrintEnterRemovedFighterOrCancel()
        {
            Console.Write( $"Введите имя бойца которого нужно удалить или нажмите \"Esc\" для отмены: " );
        }

        public static void PrintEnterCommand()
        {
            Console.Write( "\nВведите команду: " );
        }

        public static void PrintCommandNotEmpty()
        {
            Console.WriteLine( "Команда не может быть пустой строкой!" );
        }

        public static void PrintBadCommand()
        {
            Console.WriteLine( $"Команда не поддерживается!" );
        }

        public static void PrintEnterFighterName()
        {
            Console.Write( "Введите имя бойца: " );
        }

        public static void PrintNameNotEmpty()
        {
            Console.WriteLine( "Имя не может быть пустым!" );
        }

        public static void PrintEnterWeaponName()
        {
            Console.Write( "Введите название оружия(на английском): " );
        }

        public static void PrintBadWeaponName()
        {
            Console.WriteLine( "Неверное название оружия!" );
        }

        public static void PrintEnterArmorName()
        {
            Console.Write( "Введите название брони(на английском): " );
        }

        public static void PrintBadArmorName()
        {
            Console.WriteLine( "Неверное название брони!" );
        }

        public static void PrintEnterRaceName()
        {
            Console.Write( "Введите название расы(на английском): " );
        }

        public static void PrintBadRaceName()
        {
            Console.WriteLine( "Неверное название расы!" );
        }

        public static void PrintEnterFighterType()
        {
            Console.Write( "Введите название класса(на английском): " );
        }

        public static void PrintBadFighterType()
        {
            Console.WriteLine( "Неверное название типа бойца!" );
        }

        public static void PrintArmorMenu()
        {
            Console.WriteLine( $"\nВыберите броню: {Armor.NoArmor.ToString()} - без брони(по умолчанию)\n" +
                $"{' ',16}{Armor.Leather.ToString()} - кожаная\n" +
                $"{' ',16}{Armor.Gold.ToString()} - золотая\n" +
                $"{' ',16}{Armor.Iron.ToString()} - железная\n" +
                $"{' ',16}{Armor.Diamond.ToString()} - алмазная\n" );
        }

        public static void PrintWeaponMenu()
        {
            Console.WriteLine( $"\nВыберите оружие: {Weapon.Fists.ToString()} - кулаки(по умолчанию)\n" +
                $"{' ',17}{Weapon.Sword.ToString()} - меч\n" +
                $"{' ',17}{Weapon.LongSword.ToString()} - длинный меч\n" );
        }

        public static void PrintRaceMenu()
        {
            Console.WriteLine( $"\nВыберите расу: {Race.Human.ToString()} - человек(по умолчанию)\n" +
                $"{' ',15}{Race.Orc.ToString()} - орк\n" );
        }

        public static void PrintFighterTypeMenu()
        {
            Console.WriteLine( $"\nВыберите класс бойца: {FighterType.Knight.ToString()} - Рыцарь(по умолчанию)\n" +
                $"{' ',22}{FighterType.Assasin.ToString()} - Ассасин\n" );
        }

        public static void PrintCommandMenu()
        {
            Console.WriteLine( $"\nСписок команд: {Command.StartFight.ToString()} - Запустить сражение " +
                $"\n{' ',15}{Command.AddFighter.ToString()} - Добавить бойца" +
                $"\n{' ',15}{Command.ShowFighters.ToString()}  - Показать бойцов" +
                $"\n{' ',15}{Command.RemoveFighter.ToString()}  - Удалить бойца" +
                $"\n{' ',15}{Command.Quit.ToString()} - Выйти из игры\n" );
        }

        public static void PrintGreetingMessage()
        {
            const string Drawing = @"
                ###   =
               #####  ==
               #O#O#  ==
               ##0##  ===
                 #    ===
               #####  ===
              ####### ===          
             ######### |
            ##  ###  ##|
            ##  ###   ##    FIGHTER GAME!
            ## #####  ##
             #######   |
               #####   | 
                ###    | 
               ## ##   | 
              ##   ##  | 
             ##     ## | 
            **       **|";

            Console.WriteLine( Drawing );
        }

        public static void PrintFightLogs( FightLog logs )
        {
            Console.WriteLine( $"{logs.DamagerName} нанес оружием {logs.WeaponName} {logs.DefencerName} {logs.Damage} урона, оставив {logs.CurrentHealth} здоровья" );
        }

        public static void PrintWinner( IFighter? winner )
        {
            Console.WriteLine( winner == null ? "\nНичья!!!\n" : $"\nПобедитель: {winner.Name}!!!\n" );
        }

        public static void PrintDied( string name )
        {
            Console.WriteLine( $"Боец {name} мёртв!" );
        }

        public static void PrintNobodyDied()
        {
            Console.WriteLine( "Никто не умер!" );
        }

        public static void PrintQuitMessage()
        {
            const string quitMessage = @"
                88                                  
                88                                  
                88                                  
                88,dPPYba,  8b       d8  ,adPPYba,  
                88P'    ""8a `8b     d8' a8P_____88  
                88       d8  `8b   d8'  8PP""""""""  
                88b,   ,a8""   `8b,d8'   ""8b,   ,aa  
                8Y""Ybbd8""'      Y88'     `""Ybbd8""'  
                                d8'                 
                               d8'                  
                ";

            Console.WriteLine( quitMessage );
        }
    }
}