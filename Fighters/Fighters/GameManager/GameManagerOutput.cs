using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.GameManager
{
    public class FightLog( IFighter damager, IFighter defencer, int damage )
    {
        public string DamagerName => damager.Name;

        public string DefencerName => defencer.Name;

        public int Damage => damage;

        public string WeaponName => damager.Weapon.Name;

        public int HealthCurrent => defencer.GetCurrentHealth();
    }

    public class GameManagerOutput
    {
        public static void ShowFighters( in List<IFighter> fighters )
        {
            Console.WriteLine( "Список бойцов:" );

            int count = 1;

            foreach ( var fighter in fighters )
            {
                Console.WriteLine( $"{count++}. {fighter.Name}" );
            }
        }

        public static void PrintNotEnoughFighter()
        {
            Console.WriteLine( "Не хватает бойцов для удаления(нужен хотя бы 1)" );
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

        public static void PrintCommandNotSupported( string commandStr )
        {
            Console.WriteLine( $"Команда {commandStr} не поддерживается!" );
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
            const string indent = "                ";

            Console.WriteLine( $"Выберите броню: {Armor.noArmor.ToString()} - без брони(по умолчанию)\n" +
                $"{indent}{Armor.leather.ToString()} - кожаная\n" +
                $"{indent}{Armor.gold.ToString()} - золотая\n" +
                $"{indent}{Armor.iron.ToString()} - железная\n" +
                $"{indent}{Armor.diamond.ToString()} - алмазная\n" );
        }

        public static void PrintWeaponMenu()
        {
            const string indent = "                 ";

            Console.WriteLine( $"Выберите оружие: {Weapon.fists.ToString()} - кулаки(по умолчанию)\n" +
                $"{indent}{Weapon.sword.ToString()} - меч\n" +
                $"{indent}{Weapon.longSword.ToString()} - длинный меч" );
        }

        public static void PrintRaceMenu()
        {
            const string indent = "               ";

            Console.WriteLine( $"Выберите расу: {Race.human.ToString()} - человек(по умолчанию)\n" +
                $"{indent}{Race.orc.ToString()} - орк\n" );
        }

        public static void PrintFighterTypeMenu()
        {
            const string indent = "                      ";

            Console.WriteLine( $"Выберите класс бойца: {FighterType.knight.ToString()} - Рыцарь(по умолчанию)\n" +
                $"{indent}{FighterType.assasin.ToString()} - Ассасин\n" );
        }

        public static void PrintCommandMenu()
        {
            const string indent = "               ";

            Console.WriteLine( $"\nСписок команд: {Command.StartFight.ToString()} - Запустить сражение " +
                $"\n{indent}{Command.AddFighter.ToString()} - Добавить бойца" +
                $"\n{indent}{Command.ShowFighters.ToString()}  - Показать бойцов" +
                $"\n{indent}{Command.RemoveFighter.ToString()}  - Удалить бойца" +
                $"\n{indent}{Command.Quit.ToString()} - Выйти из игры\n" );
        }

        public static void PrintNotEnoughFightersForFight()
        {
            Console.WriteLine( "Недостаточно бойцов для битвы (не может быть меньше 2)" );
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
            Console.WriteLine( $"{logs.DamagerName} нанес оружием {logs.WeaponName} {logs.DefencerName} {logs.Damage} урона, оставив {logs.HealthCurrent} здоровья" );
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