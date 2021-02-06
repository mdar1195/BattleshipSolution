using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BattleshipGrid;
using System.Collections.Generic;

namespace BattleshipGrid_unitTests
{
    /// <summary>
    /// Summary description for AttackUnitTest
    /// </summary>
    [TestClass]
    public class BattleshipGridTests
    {
        private BattleshipGrid.BattleshipGrid _subjectUnderTest;

        private Mock<Fleet> _fleetMock;
        private Mock<Carrier> _carrierMock;
        private Mock<Battleship> _battleshipMock;
        private Mock<Destroyer> _destroyerMock;
        private Mock<Submarine> _submarineMock;
        private Mock<SmallAssaultShip> _assaultSipMock;

        private Mock<List<Coordinate>> _carrierCoordinatesMock;
        private Mock<List<Coordinate>> _battleshipCoordinatesMock;
        private Mock<List<Coordinate>> _destroyerCoordinatesMock;
        private Mock<List<Coordinate>> _submarineCoordinatesMock;
        private Mock<List<Coordinate>> _assaultShipCoordinatesMock;

        private Coordinate _pointOfAttack;

        #region Additional test attributes

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInitialize()
        {
            _carrierCoordinatesMock = new Mock<List<Coordinate>>(5);
            _battleshipCoordinatesMock = new Mock<List<Coordinate>>(4);
            _destroyerCoordinatesMock = new Mock<List<Coordinate>>(3);
            _submarineCoordinatesMock = new Mock<List<Coordinate>>(3);
            _assaultShipCoordinatesMock = new Mock<List<Coordinate>>(1);

            _carrierMock = new Mock<Carrier>(_carrierCoordinatesMock.Object);
            _battleshipMock = new Mock<Battleship>(_battleshipCoordinatesMock.Object);
            _destroyerMock = new Mock<Destroyer>(_destroyerCoordinatesMock.Object);
            _submarineMock = new Mock<Submarine>(_submarineCoordinatesMock.Object);
            _assaultSipMock = new Mock<SmallAssaultShip>(_assaultShipCoordinatesMock.Object);
            _fleetMock = new Mock<Fleet>(_carrierMock.Object, _battleshipMock.Object, _destroyerMock.Object, 
                _submarineMock.Object, _assaultSipMock.Object);

            _pointOfAttack = new Coordinate(1, 1);

            _subjectUnderTest = new BattleshipGrid.BattleshipGrid(_fleetMock.Object);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestCleanup() 
        {
            _carrierCoordinatesMock = null;
            _battleshipCoordinatesMock = null;
            _destroyerCoordinatesMock = null;
            _submarineCoordinatesMock = null;
            _assaultShipCoordinatesMock = null;

            _carrierMock = null;
            _battleshipMock = null;
            _destroyerMock = null;
            _submarineMock = null;
            _assaultSipMock = null;
            _fleetMock = null;
            _subjectUnderTest = null;
        }

        #endregion

        [TestMethod]
        public void Attack_IsHitReturnsTrue_ResultHit()
        {
            _fleetMock.Setup(x => x.IsHit(_pointOfAttack)).Returns(true);

            ResultOfAttack result = _subjectUnderTest.Attack(_pointOfAttack);

            Assert.AreEqual(ResultOfAttack.Hit, result);
        }
        [TestMethod]
        public void Attack_DidSankReturnsTrue_ResultSank()
        {
            _fleetMock.Setup(x => x.DidSank(_pointOfAttack)).Returns(true);

            ResultOfAttack result = _subjectUnderTest.Attack(_pointOfAttack);

            Assert.AreEqual(ResultOfAttack.Sank, result);
        }
        [TestMethod]
        public void Attack_IsGameOverReturnTrue_ResultGameOver()
        {
            _fleetMock.Setup(x => x.IsGameOver()).Returns(true);

            ResultOfAttack result = _subjectUnderTest.Attack(_pointOfAttack);

            Assert.AreEqual(ResultOfAttack.GameOver, result);
        }
        [TestMethod]
        public void Attack_IsMissReturnsTrue_ResultMiss()
        {
            _fleetMock.Setup(x => x.IsHit(_pointOfAttack)).Returns(false);
            _fleetMock.Setup(x => x.DidSank(_pointOfAttack)).Returns(false);
            _fleetMock.Setup(x => x.IsGameOver()).Returns(false);

            ResultOfAttack result = _subjectUnderTest.Attack(_pointOfAttack);

            Assert.AreEqual(ResultOfAttack.Miss, result);
        }
    }
}
