using System;
using System.Collections.Generic;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction transaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction(123, TransactionStatus.Successfull, "Gosho", "Pesho", 1);
            chainblock = new Chainblock.Models.Chainblock();
        }

        [Test]
        [Category("Add")]
        public void MethodAddShouldIncreaseTheCount()
        {
            //Arrange - Act
            chainblock.Add(transaction);
            int expectedResult = 1;
            int actualResult = chainblock.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("Add")]
        public void MethodAddShouldThrowExceptionIfSameIdTransactionIsGiven()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<ArgumentException>(()
                => chainblock.Add(transaction));
        }

        [Test]
        [Category("Contains/Transaction/")]
        public void MethodContainsByTransactionShouldReturnTrueIfChainblockContainsGivenTransaction()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            //Assert
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        [Category("Contains/Transaction/")]
        public void MethodContainsByTransactionShouldReturnTrueIfChainblockDoesNotContainGivenTransaction()
        {
            //Arrange - Act - Assert
            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        [Category("Contains/ID/")]
        public void MethodContainsByIDShouldReturnTrueIfChainblockContainsTransactionWithGivenID()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            //Assert
            Assert.IsTrue(chainblock.Contains(123));
        }

        [Test]
        [Category("Contains/ID/")]
        public void MethodContainsByIDShouldReturnFalseIfChainblockDoesNotContainTransactionWithGivenID()
        {
            //Arrange - Act - Assert
            Assert.IsFalse(chainblock.Contains(12345));
        }

        [Test]
        [Category("ChangeTransactionStatus")]
        public void MethodChangeTransactionStatusShouldChangeTheStatusOfTheTransactionWithGivenID()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(123, TransactionStatus.Failed);
            var expectedResult = TransactionStatus.Failed;
            var actualResult = transaction.Status;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("ChangeTransactionStatus")]
        public void MethodChangeTransactionStatusShouldThrowExceptionIfTransactionWithGivenIDDoesNotExist()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<ArgumentException>(()
                => chainblock.ChangeTransactionStatus(12345, TransactionStatus.Failed));
        }

        [Test]
        [Category("RemoveTransactionById")]
        public void MethodRemoveTransactionByIdShouldRemoveTheTransactionWithGivenID()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            chainblock.RemoveTransactionById(123);
            var expectedResult = 0;
            var actualResult = chainblock.Count; ;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("RemoveTransactionById")]
        public void MethodRemoveTransactionByIdShouldThrowExceptionIfTransactionWithGivenIDDoesNotExist()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.RemoveTransactionById(12345));
        }

        [Test]
        [Category("GetById")]
        public void MethodGetByIdShouldReturnTheTransactionWithGivenID()
        {
            //Arrange - Act
            chainblock.Add(transaction);

            var expectedResult = transaction;
            var actualResult = chainblock.GetById(123);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetById")]
        public void MethodGetByIdShouldThrowExceptionIfTransactionWithGivenIDDoesNotExist()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetById(12345));
        }

        [Test]
        [Category("GetByTransactionStatus")]
        public void MethodGetByTransactionStatusShouldReturnTheTransactionsWithGivenStatus()
        {
            //Arrange
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            var expectedResult = new ITransaction[] { transaction2, transaction };
            var actualResult = chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetByTransactionStatus")]
        public void MethodGetByTransactionStatusShouldThrowExceptionIfThereAreNoTransactionsWithGivenStatus()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        [Category("GetAllSendersWithTransactionStatus")]
        public void MethodGetAllSendersWithTransactionStatusShouldReturnAllSendersWithGivenStatus()
        {
            //Arrange
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            var expectedResult = new string[] { "Gosho", "Gosho" };
            var actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetAllSendersWithTransactionStatus")]
        public void MethodGetAllSendersWithTransactionStatusShouldThrowExceptionIfNoTransactionsExist()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        [Category("GetAllReceiversWithTransactionStatus")]
        public void MethodGetAllReceiversWithTransactionStatusShouldReturnAllReceiversWithGivenStatus()
        {
            //Arrange
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            var expectedResult = new string[] { "Pesho", "Pesho" };
            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetAllReceiversWithTransactionStatus")]
        public void MethodGetAllReceiversWithTransactionStatusShouldThrowExceptionIfNoTransactionsExist()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        [Category("GetAllOrderedByAmountDescendingThenById")]
        public void MethodGetAllOrderedByAmountDescendingThenByIdShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction2, transaction3, transaction };
            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById();

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetBySenderOrderedByAmountDescending")]
        public void MethodGetBySenderOrderedByAmountDescendingShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction2, transaction };
            var actualResult = chainblock.GetBySenderOrderedByAmountDescending("Gosho");

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetBySenderOrderedByAmountDescending")]
        public void MethodGetBySenderOrderedByAmountDescendingShouldThrowExceptionIfTherAreNoSuchSenders()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetBySenderOrderedByAmountDescending("Toshko"));
        }

        [Test]
        [Category("GetByReceiverOrderedByAmountThenById")]
        public void MethodGetByReceiverOrderedByAmountThenByIdShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction3, transaction2, transaction };
            var actualResult = chainblock.GetByReceiverOrderedByAmountThenById("Pesho");

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetByReceiverOrderedByAmountThenById")]
        public void MethodGetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfTherAreNoSuchReceivers()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByReceiverOrderedByAmountThenById("Toshko"));
        }

        [Test]
        [Category("GetByTransactionStatusAndMaximumAmount")]
        public void MethodGetByTransactionStatusAndMaximumAmountShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Failed, "Toshko", "Pesho", 100); ;

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction };
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 50);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetByTransactionStatusAndMaximumAmount")]
        public void MethodGetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionIfNoSuchTransactionsAreFound()
        {
            //Arrange- Act
            chainblock.Add(transaction);

            List<ITransaction> expectedResult = new List<ITransaction>();
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 50);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetBySenderAndMinimumAmountDescending")]
        public void MethodGGetBySenderAndMinimumAmountDescendingShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 150);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction3, transaction2 };
            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending("Gosho", 1);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetBySenderAndMinimumAmountDescending")]
        public void MethodGetBySenderAndMinimumAmountDescendingShouldThrowExceptionIfTherAreNoSuchSenders()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetBySenderAndMinimumAmountDescending("Toshko", 50));
        }

        [Test]
        [Category("GetByReceiverAndAmountRange")]
        public void MethodGetByReceiverAndAmountRangeShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Pesho", 100);

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction };
            var actualResult = chainblock.GetByReceiverAndAmountRange("Pesho", 1, 100);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetByReceiverAndAmountRange")]
        public void MethodGetByReceiverAndAmountRangeShouldThrowExceptionIfTherAreNoSuchReceivers()
        {
            //Arrange - Act 
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByReceiverAndAmountRange("Toshko", 50, 100));
        }

        [Test]
        [Category("GetAllInAmountRange")]
        public void MethodGetAllInAmountRangeShouldReturnAllTransactionsOrderedProperly()
        {
            //Arrange
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Failed, "Toshko", "Pesho", 100); ;

            //Act
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expectedResult = new ITransaction[] { transaction, transaction2, transaction3 };
            var actualResult = chainblock.GetAllInAmountRange(1, 100);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Category("GetAllInAmountRange")]
        public void MethodGetAllInAmountRangeShouldReturnEmptyCollectionIfNoSuchTransactionsAreFound()
        {
            //Arrange- Act
            chainblock.Add(transaction);

            List<ITransaction> expectedResult = new List<ITransaction>();
            var actualResult = chainblock.GetAllInAmountRange(150, 250);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}