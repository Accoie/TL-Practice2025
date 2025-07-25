using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.GameManager;
using Fighters.Models.Weapons;
using Fighters.Models.Armors;

namespace Fighters.Tests;

[TestFixture]
public class GameManagerTests
{
    [Test]
    public void Play_TwoEqualFighters_FirstFighterWins()
    {
        // Arrange 
        var gameManager = new GameEngine();
        var fighterA = new Knight("FighterA", new Leather(), new Sword(), new Human());
        var fighterB = new Knight("FighterB", new Leather(), new Sword(), new Human());

        // Act
        gameManager.AddFighter( fighterA );
        gameManager.AddFighter( fighterB );
        var winner = gameManager.StartFight();
        // Asssert
        
        Assert.That(winner.Name, Is.EqualTo(fighterA.Name));
    }
}