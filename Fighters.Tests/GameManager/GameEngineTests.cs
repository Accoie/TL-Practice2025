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
    private readonly Mock<IFighter> _zeroDamageFighterMock;

    public GameEngineTests()
    {
        _strongFighterMock = CreateFighterMock( "strong", 333, 50 );
        _emptyNameFighterMock = CreateFighterMock( string.Empty, 333, 50 );
        _zeroDamageFighterMock = CreateFighterMock( "zeroDamage", 100, 0 );
    }

    private static void AddWeakFighter( GameEngine engine )
    {
        IFighter fighter = new BaseFighter( "Weak1", new Diamond(), new Fists(), new Human() );
        engine.AddFighter( fighter );
    }

    private static Mock<IFighter> CreateFighterMock( string name,
        int maxHealth,
        int damage )
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
            .Callback<IFighter>( def => def.TakeDamage( damage ) )
            .Returns( damage );

        fighter.Setup( f => f.ResetHealth() ).Callback( () => health = maxHealth );

        fighter.Setup( f => f.TakeDamage( It.IsAny<int>() ) )
            .Callback<int>( damage => health -= damage );

        return fighter;
    }

    [Test]
    public void AddFighter_AddWithEmptyName_ThrowException()
    {
        // Arrange
        GameEngine game = new GameEngine();
        AddWeakFighter( game );

        // Act & Assert
        Assert.Throws<ArgumentException>( () => game.AddFighter( _emptyNameFighterMock.Object ) );
    }

    [Test]
    public void RemoveFighter_RemoveNotExistingFighter_ThrowException()
    {
        // Arrange
        GameEngine game = new GameEngine();
        AddWeakFighter( game );

        // Act & Assert
        Assert.Throws<ArgumentException>( () => game.RemoveFighter( "sdfasd" ) );
    }

    [Test]
    public void RemoveFighter_RemoveWithEmptyString_ThrowException()
    {
        // Arrange
        GameEngine game = new GameEngine();
        AddWeakFighter( game );

        // Act & Assert
        Assert.Throws<ArgumentException>( () => game.RemoveFighter( string.Empty ) );
    }

    [Test]
    public void StartFight_StartFightWithOneFighter_ThrowException()
    {
        // Arrange
        Mock<IFighter> fighterMock = CreateFighterMock( "fighter", 333, 50 );
        GameEngine game = new GameEngine();
        game.AddFighter( fighterMock.Object );

        // Act & Assert
        Assert.Throws<Exception>( () => game.StartFight() );
        fighterMock.Verify( e => e.Fight( It.IsAny<IFighter>() ), Times.Never );
    }

    [Test]
    public void StartFight_WeakVsStrong_StrongWillWin()
    {
        // Arrange
        Mock<IFighter> weakFighter = CreateFighterMock( "Dfsd", 100, 10 );
        GameEngine engine = new GameEngine();
        engine.AddFighter( _strongFighterMock.Object );
        engine.AddFighter( weakFighter.Object );

        // Act
        IFighter? winner = engine.StartFight();

        // Assert
        Assert.That( winner.Name, Is.EqualTo( _strongFighterMock.Object.Name ) );
    }

    [Test]
    public void StartFight_OneStrongThreeWeak_StrongFighterWins()
    {
        // Arrange
        GameEngine game = new GameEngine();
        game.AddFighter( _strongFighterMock.Object );

        Mock<IFighter> _weakFighterMock1 = CreateFighterMock( "weak", 100, 10 );
        Mock<IFighter> _weakFighterMock2 = CreateFighterMock( "weak", 100, 10 );
        Mock<IFighter> _weakFighterMock3 = CreateFighterMock( "weak", 100, 10 );

        game.AddFighter( _weakFighterMock1.Object );
        game.AddFighter( _weakFighterMock2.Object );
        game.AddFighter( _weakFighterMock3.Object );

        // Act
        IFighter? winner = game.StartFight();

        // Assert
        Assert.That( winner.Name, Is.EqualTo( _strongFighterMock.Object.Name ) );
    }

    [Test]
    public void StartFight_TwoWeakFighters_WillDraw()
    {
        // Arrange
        GameEngine game = new GameEngine();
        game.AddFighter( _zeroDamageFighterMock.Object );
        game.AddFighter( _zeroDamageFighterMock.Object );

        // Act
        IFighter? winner = game.StartFight();

        // Assert
        Assert.That( winner, Is.Null );
    }
}