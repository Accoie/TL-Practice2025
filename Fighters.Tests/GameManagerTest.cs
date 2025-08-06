using Fighters.GameManager;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Tests;

[TestFixture]
public class GameManagerTests
{
    private Knight _strongFighter;
    private IReadOnlyList<Knight> _weakFighters;
    private IReadOnlyList<Knight> _weakFightersWithBestArmor;

    [SetUp]
    public void Setup()
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
    public void Play_OneStrongThreeWeak_FirstFighterWins() // test on several fighters
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
    public void Play_TwoWeakFighters_WillDraw() // test on infinity
    {
        GameEngine game = new GameEngine();
        game.AddFighter( _weakFightersWithBestArmor[ 0 ] );
        game.AddFighter( _weakFightersWithBestArmor[ 1 ] );

        IFighter? winner = game.StartFight();
        Assert.That( winner, Is.Null );
    }

    [Test]
    public void Play_SeveralWeakFighters_WillDraw() // test on infinity with several fighters
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