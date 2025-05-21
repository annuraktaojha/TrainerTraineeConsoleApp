using BookHub.Core.Entities;
using BookHub.Core.Repository;
using BookHub.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Tests
{
    [TestClass]
    public class BookServiceTest
    {
        private Mock<IBookRepository> _mockBookRepository;
        private BookService _bookService;
        [TestInitialize]
        public void Setup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockBookRepository.Object);
        }
        [TestMethod]
        public void AddBook_ValidBook_ReturnsTrue()
        {
            // Arrange 
            var book = new Book { Title = "Valid Book", Price = 10 };
            // Act 
            var result = _bookService.AddBook(book);
            // Assert 
            Assert.IsTrue(result);
            _mockBookRepository.Verify(repo =>
           repo.Add(It.IsAny<Book>()), Times.Once);
        }
        [TestMethod]
        public void AddBook_InvalidTitle_ReturnsFalse()
        {
            // Arrange 
            var book = new Book { Title = "", Price = 10 };
            // Act 
            var result = _bookService.AddBook(book);
            // Assert 
            Assert.IsFalse(result);
            _mockBookRepository.Verify(repo =>
            repo.Add(It.IsAny<Book>()), Times.Never);
        }

        [TestMethod]
        public void UpdateBook_ValidBook_UpdatesBookInRepository()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Updated Title", Price = 15 };

            // Act
            _bookService.UpdateBook(book);

            // Assert
            _mockBookRepository.Verify(repo => repo.Update(book), Times.Once);
        }

        [TestMethod]
        public void UpdateBook_InvalidPrice_ThrowsArgumentException()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Test Book", Price = -5 }; // Invalid Price

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _bookService.UpdateBook(book));
        }

        [TestMethod]
        public void DeleteBook_ExistingId_DeletesBookFromRepository()
        {
            // Arrange
            int bookId = 1;

            // Act
            _bookService.Delete(bookId);

            // Assert
            _mockBookRepository.Verify(repo => repo.Delete(bookId), Times.Once);
        }

        [TestMethod]
        public void GetBookByID_ExistingId_ReturnsBook()
        {
            // Arrange
            int bookId = 1;
            var expectedBook = new Book { BookId = bookId, Title = "Test Book" };
            _mockBookRepository.Setup(repo => repo.GetBookByID(bookId)).Returns(expectedBook);

            // Act
            var actualBook = _bookService.GetBookByID(bookId);

            // Assert
            Assert.AreEqual(expectedBook, actualBook);
        }

        [TestMethod]
        public void GetBookByID_NonExistingId_ReturnsNull()
        {
            // Arrange
            int bookId = 1;
            _mockBookRepository.Setup(repo => repo.GetBookByID(bookId)).Returns((Book)null); // Returns null

            // Act
            var book = _bookService.GetBookByID(bookId);

            // Assert
            Assert.IsNull(book);
        }

        [TestMethod]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book> {
            new Book { BookId = 1, Title = "Book 1" },
            new Book { BookId = 2, Title = "Book 2" }
        };
            _mockBookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var allBooks = _bookService.GetAll();

            // Assert
            Assert.AreEqual(books.Count, allBooks.Count);
            Assert.IsTrue(books.SequenceEqual(allBooks)); // Check for equality of lists (order matters)
        }
        // More tests... 
    }
    // More tests... 
}
