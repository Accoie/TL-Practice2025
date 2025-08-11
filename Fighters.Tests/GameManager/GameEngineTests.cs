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
    private readonly Mock<IFighter> _strongFighterMock;
    private readonly Mock<IFighter> _emptyNameFighterMock;
    private IReadOnlyList<BaseFighter> _weakFighters;
    private IReadOnlyList<BaseFighter> _weakFightersWithBestArmor;

    public GameEngineTests()
    {
        _strongFighterMock = CreateFighterMock( "Df", 333, 50 );
        _emptyNameFighterMock = CreateFighterMock( "", 333, 50 );
        _weakFighters = new List<BaseFighter>
        {
            new BaseFighter("Weak1", new Leather(), new Fists(), new Human()),
            new BaseFighter("Weak2", new Leather(), new Fists(), new Human()),
            new BaseFighter("Weak3", new Leather(), new Fists(), new Human())
        };

        _weakFightersWithBestArmor = new List<BaseFighter>
        {
            new BaseFighter("Weak1", new Diamond(), new Fists(), new Human()),
            new BaseFighter("Weak2", new Diamond(), new Fists(), new Human()),
            new BaseFighter("Weak3", new Diamond(), new Fists(), new Human()),
            new BaseFighter("Weak4", new Diamond(), new Fists(), new Human()),
            new BaseFighter("Weak5", new Diamond(), new Fists(), new Human()),
        };
    }

    public static Mock<IFighter> CreateFighterMock(
        string name,
        int maxHealth,
        int damage
         )
    {
        int health = maxHealth;

        Mock<IFighter> fighter = new();

        fighter.Setup( f => f.Name ).Returns( name );
        fighter.Setup( f => f.Race ).Returns( Mock.Of<IRace>() );
        fighter.Setup( f => f.Armor ).Returns( Mock.Of<IArmor>() );
        fighter.Setup( f => f.Weapon ).Returns( Mock.Of<IWeapon>() );
        fighter.Setup( f => f.MaxHealth ).Returns( maxHealth );

        fighter.Setup( f => f.Health ).Returns( () => health );

        fighter.Setup( f => f.CalculateDamage() ).Returns( damage );

        fighter.Setup( f => f.IsCanWin( It.IsAny<IFighter>() ) ).Returns( true );

        fighter.Setup( f => f.Fight( It.IsAny<IFighter>() ) )
            .Callback<IFighter>( target => target.TakeDamage( damage ) )
            .Returns( damage );

        fighter.Setup( f => f.ResetHealth() ).Callback( () => health = maxHealth );

        fighter.Setup( f => f.TakeDamage( It.IsAny<int>() ) )
            .Callback<int>( damage => health -= damage );

        return fighter;
    }

    [Test]
    public void AddFighter_With_Empty_Name()
    {
        GameEngine game = new GameEngine();

        Assert.Throws<ArgumentException>( () => game.AddFighter( _emptyNameFighterMock.Object ) );
    }

    [Test]
    public void RemoveFighter_Fighter_Not_Exist()
    {
        IFighter fighter = new BaseFighter( "Weak1", new Diamond(), new Fists(), new Human() );

        GameEngine game = new GameEngine();

        game.AddFighter( fighter );

        Assert.Throws<ArgumentException>( () => game.RemoveFighter( "sdfasd" ) );
    }

    [Test]
    public void RemoveFighter_FighterName_Is_Empty()
    {
        IFighter fighter = new BaseFighter( "Weak1", new Diamond(), new Fists(), new Human() );

        GameEngine game = new GameEngine();
        game.AddFighter( fighter );

        Assert.Throws<ArgumentException>( () => game.RemoveFighter( "" ) );
    }

    [Test]
    public void Play_Only_One_Fighter_Exception_Thrown()
    {
        GameEngine game = new GameEngine();

        game.AddFighter( _strongFighterMock.Object );

        Assert.Throws<Exception>( () => game.StartFight() );
    }

    [Test]
    public void StartFight_TwoFighters_Strong_WillWin()
    {
        Mock<IFighter> weakFighter = CreateFighterMock( "Dfsd", 100, 10 );

        GameEngine engine = new GameEngine();

        engine.AddFighter( _strongFighterMock.Object );
        engine.AddFighter( weakFighter.Object );

        IFighter? winner = engine.StartFight();

        Assert.That( winner.Name, Is.EqualTo( _strongFighterMock.Object.Name ) );
    }

    [Test]
    public void Play_OneStrongThreeWeak_FirstFighterWins()
    {
        GameEngine game = new GameEngine();

        game.AddFighter( _strongFighterMock.Object );

        foreach ( var fighter in _weakFighters )
        {
            game.AddFighter( fighter );
        }

        IFighter? winner = game.StartFight();

        Assert.That( winner.Name, Is.EqualTo( _strongFighterMock.Name ) );
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