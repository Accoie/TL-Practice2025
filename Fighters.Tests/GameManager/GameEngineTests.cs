using Fighters.GameManager;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Moq;

namespace Fighters.Tests.GameManager;

[TestFixture]
public class GameEngineTests
{
    private readonly Knight _strongFighter;
    private IReadOnlyList<Knight> _weakFighters;
    private IReadOnlyList<Knight> _weakFightersWithBestArmor;

    public GameEngineTests()
    {
        _strongFighter = new Knight( "Strong", new Diamond(), new LongSword(), new Orc() );

        _weakFighters = new List<Knight>
        {
            new Knight("Weak1", new Leather(), new Fists(), new Human()),
            new Knight("Weak2", new Leather(), new Fists(), new Human()),
            new Knight("Weak3", new Leather(), new Fists(), new Human())
        };

        _weakFightersWithBestArmor = new List<Knight>
        {
            new Knight("Weak1", new Diamond(), new Fists(), new Human()),
            new Knight("Weak2", new Diamond(), new Fists(), new Human()),
            new Knight("Weak3", new Diamond(), new Fists(), new Human()),
            new Knight("Weak4", new Diamond(), new Fists(), new Human()),
            new Knight("Weak5", new Diamond(), new Fists(), new Human()),
        };
    }

    [Test]
    public void AddFighter_With_Empty_Name()
    {
        IFighter fighter = new Knight( "", new Diamond(), new Fists(), new Human() );

        GameEngine game = new GameEngine();

        Assert.Throws<ArgumentException>( () => game.AddFighter( fighter ) );
    }

    [Test]
    public void RemoveFighter_Fighter_Not_Exist()
    {
        IFighter fighter = new Knight( "Weak1", new Diamond(), new Fists(), new Human() );

        GameEngine game = new GameEngine();
        game.AddFighter( fighter );

        Assert.Throws<ArgumentException>( () => game.RemoveFighter( "sdfasd" ) );

    }

    [Test]
    public void RemoveFighter_FighterName_Is_Empty()
    {
        IFighter fighter = new Knight( "Weak1", new Diamond(), new Fists(), new Human() );

        GameEngine game = new GameEngine();
        game.AddFighter( fighter );

        Assert.Throws<ArgumentException>( () => game.RemoveFighter( "" ) );

    }
    [Test]
    public void Play_Only_One_Fighter_Will_Win()
    {
        GameEngine game = new GameEngine();

        game.AddFighter( _strongFighter );

        Assert.Throws<Exception>( () => game.StartFight() );
    }
    [Test]
    public void Play_OneStrongThreeWeak_FirstFighterWins()
    {
        GameEngine game = new GameEngine();

        game.AddFighter( _strongFighter );

        foreach ( var fighter in _weakFighters )
        {
            game.AddFighter( fighter );
        }

        IFighter? winner = game.StartFight();

        Assert.That( winner.Name, Is.EqualTo( _strongFighter.Name ) );
    }

    [Test]
    public void Play_TwoWeakFighters_Will_Draw()
    {
        GameEngine game = new GameEngine();

        game.AddFighter( _weakFightersWithBestArmor[ 0 ] );
        game.AddFighter( _weakFightersWithBestArmor[ 1 ] );

        IFighter? winner = game.StartFight();

        Assert.That( winner, Is.Null );
    }

    [Test]
    public void Play_SeveralWeakFighters_Will_Draw()
    {
        GameEngine game = new GameEngine();

        foreach ( var fighter in _weakFightersWithBestArmor )
        {
            game.AddFighter( fighter );
        }

        IFighter? winner = game.StartFight();

        Assert.That( winner, Is.Null );
    }
}