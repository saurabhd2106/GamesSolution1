using Games.Specs.StepDefinitions.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace Games.Specs.StepDefinitions
{
    [Binding]
    public sealed class PlayerCharacterStepDefinitions
    {
        private PlayerCharacter _player;

        private ScenarioContext _scenarioContext;

        public PlayerCharacterStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I'm a new player")]
        public void SetupNewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _scenarioContext["damage"] = damage;

            _player.Hit(damage);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.AreEqual(_scenarioContext["damage"], (100 - expectedHealth));

            Assert.AreEqual(expectedHealth, _player.Health);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void AddDamageResistance(int resistance)
        {
            _player.DamageResistance = resistance;

        }

        [Given(@"I'm an (.*)")]
        public void AddRace(String race)
        {
            _player.Race = race;

        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            /*
            Dictionary<string, string> dictionaryAsData = Conversion.ToDictionary(table);

            _player.Race = dictionaryAsData["Race"];

            _player.DamageResistance = int.Parse(dictionaryAsData["Resistance"]);
            */

            /*
            var attributes = table.CreateInstance<PlayerAttributes>();

            _player.Race = attributes.Race;

            _player.DamageResistance = attributes.Resistance;

            */

            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;

            _player.DamageResistance = attributes.Resistance;

        }

        [Given(@"My Character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass character)
        {
            _player.CharacterClass = character;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }

        [Given(@"I  last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime date)
        {
            _player.LastSleepTime = date;
        }


        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()
        {
            _player.ReadHealthOnSleep();
        }

        [Given(@"I have the following magical Items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {

            _player.MagicalItems.AddRange(table.CreateSet<MagicalItem>());
       
            
        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int magicalPower)
        {
            Assert.AreEqual(magicalPower, _player.MagicalPower);
        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons)
        {
           _player.Weapons.AddRange(weapons);
        }

        [Then(@"My weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int expectedWeaponWorth)
        {
            Assert.AreEqual(expectedWeaponWorth, _player.WeaponsValue);
        }


    }
}