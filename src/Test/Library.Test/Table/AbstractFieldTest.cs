using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class AbstractFieldTest
    {
        private Table _tab;
        private TableToString _tts;
        private MissileAttack _missile;
        private LoadAttack _load;
        private MeteorAttack _meteorShower;
        private Battleship _battleship;
        private Frigate _frigate;
        [SetUp]
        public void Setup()
        {
            // Table.
            this._tab = new Table();
            this._tts = new TableToString();
            // Attackers.
            this._missile = new MissileAttack();
            this._load = new LoadAttack();
            this._meteorShower = new MeteorAttack();
            // Vessels.
            this._battleship = new Battleship();
            this._frigate = new Frigate();
        }
        [Test]
        public void EmptyWater()
        {
            Assert.IsTrue(this._tab.IsEmpty());
        }
        [Test]
        public void HiddenVessel()
        {
            this._tab.AddVessel(1,1,this._battleship,true);
            ITableToString toString = new TableToString();
            string[] table = toString.ToString(this._tab).Split("\n");
            Assert.AreEqual('4', table[1][1]);
        }
        [Test]
        public void GetLeftUpHorizontal()
        {
            this._tab.AddVessel(1,1,this._battleship,false);
            Assert.AreEqual((1,1),this._tab.GetLeftUp(3,1));
        }
        [Test]
        public void GetLeftUpVertical()
        {
            this._tab.AddVessel(1,1,this._battleship,true);
            Assert.AreEqual((1,1),this._tab.GetLeftUp(1,3));
        }        
        [Test]
        public void UpdatesTheRightWay()
        {
            this._tab.AttackAt(1,1,_missile);
            Assert.True(this._tab.At( 1, 1) is AttackedWater);
        }
        [Test]
        public void IsEmptyTest()
        { 
            // Assert.
            Assert.True(this._tab.IsEmpty());
        }
        [Test]
        public void IsNotEmptyTest()
        { 
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Assert.
            Assert.False(this._tab.IsEmpty());
        }
        [Test]
        public void IsEmptyAfterMissileAttackTest()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Act.
            this._tab.AttackAt(1,1,_missile);
            this._tab.AttackAt(1,2,_missile);
            // Assert
            Assert.True(this._tab.IsEmpty());
        }
        [Test]
        public void IsEmptyAfterLoadAttackTest()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Act.
            this._tab.AttackAt(1,1,_load);
            this._tab.AttackAt(1,2,_load);
            // Assert
            Assert.True(this._tab.IsEmpty());
        }
        [Test]
        public void IsEmptyAfterMeteorShowerAttackTest()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Act.
            this._tab.AttackAt(1,1,_meteorShower);
            this._tab.AttackAt(1,2,_meteorShower);
            // Assert
            Assert.True(this._tab.IsEmpty());
        }
        [Test]
        public void IsAVesselEvenAfterAttack()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Act.
            this._tab.AttackAt(1,1,_load);
            // Assert.
            Assert.True(this._tab.IsAVessel(1,2));
        }
        [Test]
        public void IsAVesselEvenAfterAnAvoidedAttack()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            this._frigate.AddItem(1,new Armor(),_tab, new ArmorValidator());
            // Act.
            try
            {
                this._tab.AttackAt(1,1,_missile);
                this._tab.AttackAt(1,2,_missile);
            }
            catch
            {
                // Assert.
                Assert.True(this._tab.IsAVessel(1,2));
            }
        }
        [Test]
        public void HorizontalVesselCoordinates()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,true);
            // Assert.
            Assert.AreEqual(this._tab.VesselCoordinates(1,1), new List<(int,int)>{(1,1),(1,2)});
        }
        [Test]
        public void VerticalVesselCoordinates()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_frigate,false);
            // Assert.
            Assert.AreEqual(this._tab.VesselCoordinates(1,1), new List<(int,int)>{(1,1),(2,1)});
        }
        [Test]
        public void VerticalGetLeftUp()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_battleship,false);
            // Assert.
            Assert.AreEqual(this._tab.GetLeftUp(6,1), (1,1));
        }
        [Test]
        public void HorizontalGetLeftUp()
        {
            // Arrange.
            this._tab.AddVessel(1,1,_battleship,true);
            // Assert.
            Assert.AreEqual(this._tab.GetLeftUp(1,6), (1,1));
        }
        [Test]
        public void AddVesselInIncorrectPosition()
        {
            // Assert.
            Assert.False(this._tab.AddVessel(1000000,1,this._frigate,true));
        }
        [Test]
        public void AddVesselWhereIsAlreadyAVessel()
        {
            // Arrange.
            this._tab.AddVessel(1,1,this._battleship,true);
            // Assert.
            Assert.False(this._tab.AddVessel(2,1,this._frigate,false));
        }
        [Test]
        public void RemoveVesselWithRandomPosition()
        {
            // Arrange.
            string table = this._tts.ToString(this._tab);
            // Act.
            this._tab.RemoveVessel(1,2, new DeadVessel());
            // Assert.
            Assert.AreEqual(table,this._tts.ToString(this._tab));
        }
        [Test]
        public void RemoveVesselAndActualiceTable()
        {
            // Arrange.
            this._tab.AddVessel(1,1,this._frigate,true);
            // Act.
            this._tab.RemoveVessel(1,2, new DeadVessel());
            // Assert.
            Assert.True(this._tab.At(1,1) is DeadVessel);
        }
    }
}