using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BattleshipGrid;

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
        private Coordinate _pointOfAttack;

        #region Additional test attributes

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInitialize()
        {
            _fleetMock = new Mock<Fleet>();
            _pointOfAttack = new Coordinate(1, 1);

            _subjectUnderTest = new BattleshipGrid.BattleshipGrid(_fleetMock.Object);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestCleanup() 
        {
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
