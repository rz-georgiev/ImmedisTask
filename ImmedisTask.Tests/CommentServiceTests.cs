using ImmedisTask.Data.Interfaces;
using ImmedisTask.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ImmedisTask.Tests
{
    [TestClass]
    public class CommentServiceTests : ParentTest
    {
        private readonly ICommentService _commentService;
        public CommentServiceTests()
        {
            _commentService = new CommentService(ImmedisDbContext);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        public void GetByEmployeeId_WhenIdIsInvalid_ShouldReturnEmptyCollection(int value)
        {
            var comments =  _commentService.GetByEmployeeId(value).ToList();
            Assert.IsTrue(!comments.Any());
        }

        [TestMethod]
        public async Task GetByIdAsync_WhenIdIsNull_ShouldReturnNull()
        {
            var employee = await _commentService.GetByIdAsync(null);
            Assert.IsNull(employee);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        public async Task GetByIdAsync_WhenIdIsInvalid_ShouldReturnNull(int value)
        {
            var employee = await _commentService.GetByIdAsync(value);
            Assert.IsNull(employee);
        }

        [TestMethod]
        public async Task SaveChangesAsync_WhenCommentIsNull_ShouldReturnFalse()
        {
            var result = await _commentService.SaveChangesAsync(null);
            Assert.IsFalse(result);
        }
    }
}
