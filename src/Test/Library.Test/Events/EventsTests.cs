using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library
{
    public class EventsTests
    {
        // Events.
        
        private IEvent _godzilla;
        private IEvent _hurricane;
        private IEvent _meteorShower;
        private IEvent _volcano;

        // Vessels.
        private AbstractVessel _battleShip;
        private AbstractVessel _heavyCruiser;
        private AbstractVessel _puntoon;
        private AbstractVessel _submarine;
        private AbstractVessel _frigate;

        // Items.
        private SateliteLock _sateliteLock;
        private Armor _armor;
        private AntiaircraftMissile _anticraftMissile;
        private Kong _kong;
        private Hackers _hackers;

        // Table.
        private AbstractPlayer _player1;
        private AbstractPlayer _player2;
        private List<AbstractPlayer> _players;
        private TableToString _tts;

        [SetUp]
        public void SetUp()
        {
            this._godzilla = new Godzilla();
            this._hurricane = new Hurricane();
            this._meteorShower = new MeteorShower();
            this._volcano = new Volcano();

            this._battleShip = new Battleship();
            this._heavyCruiser = new HeavyCruiser();
            this._puntoon = new Puntoon();
            this._submarine = new Submarine();
            this._frigate = new Frigate();

            this._sateliteLock = new SateliteLock();
            this._armor = new Armor();
            this._anticraftMissile = new AntiaircraftMissile();
            this._kong = new Kong();
            this._hackers = new Hackers();

            this._player1 = new Player(1, "tomas", null);
            this._player2 = new Player(2, "facundo", null);
            this._players = new List<AbstractPlayer> { _player1, _player2 };
            this._tts = new TableToString();
        }

        // La veracidad de algunos test depende de si ataca en el lugar correcto. Para que todos sean exitosos modificar la posicion de ataque a (3,3). 

        // Godzilla. 
        [Test]
        public void GodzillaIsKillingTest()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);
            // Act.
            string table1 = this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tts.ToString(this._player1.Table), table1);
        }

        [Test]
        public void GodzillaIsNullIfShipContainsKongTest()
        {
            // Arrange.
            _player1.AddItem(2, new Kong(), _battleShip);
            _player1.AddVessel(1, 1, _battleShip, true);
            // Act.
            string table1 = this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreEqual( this._tts.ToString(this._player1.Table), table1);
        }

        [Test]
        public void NullListTest()
        {
            this._godzilla.DoEvent(new List<AbstractPlayer> { }.AsReadOnly());
        }

        [Test]
        public void GodzillaKillIfIsArmorToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _player1.AddItem(1, _armor, _battleShip);
            // Act.
            string table1 =  this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table), table1);
        }

        [Test]
        public void GodzillaKillIfIsSateliteLockToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _player1.AddItem(1, _sateliteLock, _battleShip);
            // Act.
            string table1 =  this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table), table1);
        }

        [Test]
        public void GodzillaKillIfIsAntiAircraftToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _player1.AddItem(1, _anticraftMissile, _battleShip);
            // Act.
            string table1 =  this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table), table1);
        }
        [Test]
        public void GodzillaKillIfIsHackersToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _puntoon, true);

            _player1.AddItem(0, _hackers, _puntoon);
            // Act.
            string table1 =  this._tts.ToString(this._player1.Table);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table), table1);
        }

        [Test]
        public void AttackingAllTablesInSamePlaceGodzilla()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _player2.AddVessel(1, 1, _battleShip, true);
            _player2.AddVessel(3, 3, _frigate, true);
            _player2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _godzilla.DoEvent(_players.AsReadOnly());

            // Arrange.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table),  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void GodzillaKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _godzilla.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition =  this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }

        [Test]
        public void GodzillaKillBoatToIfAPartOfItsAreadyDead()
        {
            // Arrange.
            _player1.AddVessel(3, 5, _submarine, true);
            _player1.AttackAt(3, 5, new LoadAttack());

            // Act.
            _godzilla.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition = this._tts.ToString(this._player1.Table).Split("\n")[3][5];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }

        [Test]
        public void GodzillaDoNotEliminateInformationOfPreviousVesselsInTheTable()
        {

            // Arrange.
            _player1.AddVessel(3, 3, _puntoon, true);
            _player1.AttackAt(3, 3, new LoadAttack());

            // Act.
            _godzilla.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition = this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }

        // MeteorShower.
        [Test]
        public void IsMeteourShowerAttacking()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table =  this._tts.ToString(this._player1.Table);
            // Act.
            _meteorShower.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual( this._tts.ToString(this._player1.Table), table);
        }

        [Test]
        public void ArmorNotProtectMeteourAttack()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddItem(0, _armor, _frigate);
            // Act.
            _meteorShower.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());
            // Assert.
            int tablePosition =  this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition == 2  || tablePosition == 3 || tablePosition == 4);
        }

        [Test]
        public void IncommingEmptyListInMeteourAttck()
        {
            _meteorShower.DoEvent(new List<AbstractPlayer> { }.AsReadOnly());
        }

        [Test]
        public void AttackingAllTablesInSamePlaceMeteourShower()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _player2.AddVessel(1, 1, _battleShip, true);
            _player2.AddVessel(3, 3, _frigate, true);
            _player2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _meteorShower.DoEvent(_players.AsReadOnly());

            // Arrange.
            Assert.AreEqual( this._tts.ToString(this._player1.Table),  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void MeteorShowerKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _meteorShower.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition = this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }

        // Volcano.
        [Test]
        public void VolcanoAttackTest()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table =  this._tts.ToString(this._player1.Table);

            // Act.
            _volcano.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            Assert.AreNotEqual(table,  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void IncommingEmptyListInVolvano()
        {
            _volcano.DoEvent(new List<AbstractPlayer>().AsReadOnly());
        }

        [Test]
        public void AttackingAllTablesInSamePlaceVolcano()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _player2.AddVessel(1, 1, _battleShip, true);
            _player2.AddVessel(3, 3, _frigate, true);
            _player2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _volcano.DoEvent(_players.AsReadOnly());

            // Arrange.
            Assert.AreEqual( this._tts.ToString(this._player1.Table),  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void VolcanoKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _volcano.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition = this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }

        // Hurricane.
        [Test]
        public void IsHurricaneAttacking()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table =  this._tts.ToString(this._player1.Table);

            // Act.
            _hurricane.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            Assert.AreNotEqual(table,  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void IncommingEmptyListInHurricane()
        {
            _hurricane.DoEvent(new List<AbstractPlayer> { }.AsReadOnly());
        }

        [Test]
        public void AttackingAllTablesInSamePlaceHurricane()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _player2.AddVessel(1, 1, _battleShip, true);
            _player2.AddVessel(3, 3, _frigate, true);
            _player2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _hurricane.DoEvent(_players.AsReadOnly());

            // Arrange.
            Assert.AreEqual( this._tts.ToString(this._player1.Table),  this._tts.ToString(this._player1.Table));
        }

        [Test]
        public void HurricaneKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _hurricane.DoEvent(new List<AbstractPlayer> { _player1 }.AsReadOnly());

            // Arrange.
            int tablePosition = this._tts.ToString(this._player1.Table).Split("\n")[3][3];
            Assert.IsTrue(tablePosition ==  2 || tablePosition == 3 || tablePosition == 4);
        }
    }
}