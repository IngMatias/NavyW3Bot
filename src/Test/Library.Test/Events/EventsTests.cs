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
        private TableToString _tableToString;

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

            this._player1 = new Player(1,"tomas",null);
            this._player2 = new Player(2,"tomas 2",null);
            this._players = new List<AbstractPlayer> { _player1, _player2 };
            this._tableToString = new TableToString();
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
            string table1 = this._player1.
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table1);
        }

        [Test]
        public void GodzillaIsNullIfShipContainsKongTest()
        {
            // Arrange.
            _battleShip.AddItem(2, new Kong(), _player1, new KongValidator());
            _player1.AddVessel(1, 1, _battleShip, true);
            // Act.
            string table1 =this._tableToString.ToString(_player1);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreEqual(this._tableToString.ToString(_player1), table1);
        }

        [Test]
        public void NullListTest()
        {
            this._godzilla.DoEvent(new List<AbstractTable> { });
        }

        [Test]
        public void GodzillaKillIfIsArmorToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _battleShip.AddItem(1, _armor, _player1, new ArmorValidator());
            // Act.
            string table1 = this._tableToString.ToString(_player1);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table1);
        }

        [Test]
        public void GodzillaKillIfIsSateliteLockToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _battleShip.AddItem(1, _sateliteLock, _player1, new SateliteLockValidator());
            // Act.
            string table1 = this._tableToString.ToString(_player1);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table1);
        }

        [Test]
        public void GodzillaKillIfIsAntiAircraftToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);

            _battleShip.AddItem(1, _anticraftMissile, _player1, new AntiaircraftMissileValidator());
            // Act.
            string table1 =this._tableToString.ToString(_player1);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table1);
        }
        [Test]
        public void GodzillaKillIfIsHackersToo()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _puntoon, true);

            _puntoon.AddItem(0, _hackers, _player1, new HackersValidator());
            // Act.
            string table1 = this._tableToString.ToString(_player1);
            this._godzilla.DoEvent(new List<AbstractPlayer> { this._player1 }.AsReadOnly());
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table1);
        }

        [Test]
        public void AttackingAllTablesInSamePlaceGodzilla()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _table2.AddVessel(1, 1, _battleShip, true);
            _table2.AddVessel(3, 3, _frigate, true);
            _table2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _godzilla.DoEvent(_tables);

            // Arrange.
            Assert.AreEqual(this._tableToString.ToString(_player1),this._tableToString.ToString(_table2));
        }

        [Test]
        public void GodzillaKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _godzilla.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.False(_player1.IsAVessel(3, 3));
        }

        [Test]
        public void GodzillaKillBoatToIfAPartOfItsAreadyDead()
        {
            // Arrange.
            _player1.AddVessel(3, 5, _submarine, true);
            _player1.AttackAt(3,5,new LoadAttack());

            // Act.
            _godzilla.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Console.WriteLine(this._tableToString.ToString(_player1));
            Assert.False(_player1.IsAVessel(3, 7));
        }

        [Test]
        public void GodzillaDoNotEliminateInformationOfPreviousVesselsInTheTable()
        {
            
            // Arrange.
            _player1.AddVessel(3, 3, _puntoon, true);
            _player1.AttackAt(3,3,new LoadAttack());
            IField tableState = _player1.At(3,3);

            // Act.
            _godzilla.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Console.WriteLine(this._tableToString.ToString(_player1));
            Assert.AreEqual(_player1.At(3,3), _player1.At(3,3));
        }

        // MeteorShower.
        [Test]
        public void IsMeteourShowerAttacking()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table = this._tableToString.ToString(_player1);
            // Act.
            _meteorShower.DoEvent(new List<AbstractTable> { _player1 });
            // Assert.
            Assert.AreNotEqual(this._tableToString.ToString(_player1), table);
        }

        [Test]
        public void ArmorNotProtectMeteourAttack()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _frigate, true);
            _frigate.AddItem(0, _armor, _player1, new ArmorValidator());
            // Act.
            _meteorShower.DoEvent(new List<AbstractTable> { _player1 });
            // Assert.
            Assert.IsFalse(_player1.At(3, 3) is ILiveHiddenVessel);
        }

        [Test]
        public void IncommingEmptyListInMeteourAttck()
        {
            _meteorShower.DoEvent(new List<AbstractTable>());
        }

        [Test]
        public void AttackingAllTablesInSamePlaceMeteourShower()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _table2.AddVessel(1, 1, _battleShip, true);
            _table2.AddVessel(3, 3, _frigate, true);
            _table2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _meteorShower.DoEvent(_tables);

            // Arrange.
            Assert.AreEqual(this._tableToString.ToString(_player1), this._tableToString.ToString(_table2));
        }

        [Test]
        public void MeteorShowerKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _meteorShower.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.False(_player1.IsAVessel(3, 3));
        }

        // Volcano.
        [Test]
        public void VolcanoAttackTest()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table = this._tableToString.ToString(_player1);

            // Act.
            _volcano.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.AreNotEqual(table, this._tableToString.ToString(_player1));
        }

        [Test]
        public void IncommingEmptyListInVolvano()
        {
            _volcano.DoEvent(new List<AbstractTable>());
        }

        [Test]
        public void AttackingAllTablesInSamePlaceVolcano()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _table2.AddVessel(1, 1, _battleShip, true);
            _table2.AddVessel(3, 3, _frigate, true);
            _table2.AddVessel(7, 7, _battleShip, true);

            // Act.
            _volcano.DoEvent(_tables);

            // Arrange.
            Assert.AreEqual(this._tableToString.ToString(_player1),this._tableToString.ToString(_player1));
        }

        [Test]
        public void VolcanoKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _volcano.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.False(_player1.IsAVessel(3, 3));
        }

        // Hurricane.
        [Test]
        public void IsHurricaneAttacking()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(6, 6, _battleShip, true);
            string table = this._tableToString.ToString(_player1);

            // Act.
            _hurricane.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.AreNotEqual(table, this._tableToString.ToString(_player1));
        }

        [Test]
        public void IncommingEmptyListInHurricane()
        {
            _hurricane.DoEvent(new List<AbstractTable> { });
        }

        [Test]
        public void AttackingAllTablesInSamePlaceHurricane()
        {
            // Arrange.
            _player1.AddVessel(1, 1, _battleShip, true);
            _player1.AddVessel(3, 3, _frigate, true);
            _player1.AddVessel(7, 7, _battleShip, true);

            _table2.AddVessel(1, 1, _battleShip, true);
            _table2.AddVessel(3, 3, _frigate, true);
            _table2.AddVessel(7, 7, _battleShip, true);

            // Act.
            Console.WriteLine(this._tableToString.ToString(_player1));
            Console.WriteLine(this._tableToString.ToString(_table2));
            _hurricane.DoEvent(_tables);
            Console.WriteLine(this._tableToString.ToString(_player1));
            Console.WriteLine(this._tableToString.ToString(_table2));

            // Arrange.
            Assert.AreEqual(this._tableToString.ToString(_player1), this._tableToString.ToString(_table2));
        }

        [Test]
        public void HurricaneKillSubmarineToo()
        {
            // Arrange.
            _player1.AddVessel(3, 3, _submarine, true);

            // Act.
            _hurricane.DoEvent(new List<AbstractTable> { _player1 });

            // Arrange.
            Assert.False(_player1.IsAVessel(3, 3));
        }
    }
}