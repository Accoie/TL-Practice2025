using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;


namespace Fighters.GameManager
{
    using static System.Runtime.InteropServices.JavaScript.JSType;


    public class ConsoleUserInput
    {
        public static IFighter ReadFighterData()
        {
            FighterBuilder _builder = new FighterBuilder();

            string name = ReadFighterName() ?? "Без имени";

            IWeapon weapon = ReadFighterWeapon();

            IArmor armor = ReadFighterArmor();

            IRace race = ReadFighterRace();

            FighterType type = ReadFighterType();

            return _builder
                    .WithName( name )
                    .WithArmor( armor )
                    .WithWeapon( weapon )
                    .WithRace( race )
                    .OfType( type )
                    .Build();
        }

        private static string ReadFighterName()
        {
            string name = string.Empty;

            while ( string.IsNullOrEmpty( name ) )
            {
                Console.Write( "Введите имя бойца: " );
                name = Console.ReadLine() ?? string.Empty;
                if ( string.IsNullOrEmpty( name ) )
                {
                    Console.WriteLine( "Имя не может быть пустым!" );
                }
            }

            return name;
        }
        private static IWeapon ReadFighterWeapon()
        {
            const string indent = "                 ";

            Console.WriteLine( $"Выберите оружие: {Weapon.fists.ToString()} - кулаки(по умолчанию)\n" +
                $"{indent}{Weapon.sword.ToString()} - меч\n" +
                $"{indent}{Weapon.longSword.ToString()} - длинный меч" );

            Weapon weapon = Weapon.fists;

            bool isParsed = false;
            while ( !isParsed )
            {
                Console.Write( "Введите название оружия(на английском): " );
                string weaponStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( weaponStr, ignoreCase: true, out weapon );
                if ( !isParsed )
                {
                    Console.WriteLine( "Неверное название оружия!" );
                }
            }

            return WeaponGetter.WeaponFactory( weapon ); ;
        }

        private static IArmor ReadFighterArmor()
        {
            const string indent = "                ";

            Console.WriteLine( $"Выберите броню: {Armor.noArmor.ToString()} - без брони(по умолчанию)\n" +
                $"{indent}{Armor.leather.ToString()} - кожаная\n" +
                $"{indent}{Armor.gold.ToString()} - золотая\n" +
                $"{indent}{Armor.iron.ToString()} - железная\n" +
                $"{indent}{Armor.diamond.ToString()} - алмазная\n"
                );

            bool isParsed = false;
            Armor armor = Armor.noArmor;

            while ( !isParsed )
            {
                Console.Write( "Введите название брони(на английском): " );
                string armorStr = Console.ReadLine() ?? string.Empty;
                isParsed = Enum.TryParse( armorStr, ignoreCase: true, out armor );
                if ( !isParsed )
                {
                    Console.WriteLine( "Неверное название брони!" );
                }
            }

            return ArmorGetter.ArmorFactory( armor );
        }
        private static IRace ReadFighterRace()
        {
            const string indent = "               ";

            Console.WriteLine( $"Выберите расу: {Race.human.ToString()} - человек(по умолчанию)\n" +
                $"{indent}{Race.orc.ToString()} - орк\n"
                );

            bool isParsed = false;
            Race race = Race.human;
            while ( !isParsed )
            {
                Console.Write( "Введите название расы(на английском): " );
                string raceStr = Console.ReadLine() ?? string.Empty;
                isParsed = Enum.TryParse( raceStr, ignoreCase: true, out race );
                if ( !isParsed )
                {
                    Console.WriteLine( "Неверное название расы!" );
                }
            }

            return RaceGetter.RaceFactory( race );
        }
        private static FighterType ReadFighterType()
        {
            const string indent = "                      ";

            Console.WriteLine( $"Выберите класс бойца: {FighterType.knight.ToString()} - Рыцарь(по умолчанию)\n" +
                $"{indent}{FighterType.assasin.ToString()} - Ассасин\n"
                );
            Console.Write( "Введите название класса(на английском): " );

            FighterType fighter = FighterType.knight;
            bool isParsed = false;

            while ( !isParsed )
            {
                string fighterStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( fighterStr, ignoreCase: true, out fighter );
                if ( !isParsed )
                {
                    Console.WriteLine( "Неверное названия типа бойца!" );
                }
            }

            return fighter;
        }

    }

}
