using ImmedisTask.Data.Interfaces;
using ImmedisTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ImmedisTask.Tests
{
    [TestClass]
    public class EmployeeServiceTests : ParentTest
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeServiceTests()
        {
            _employeeService = new EmployeeService(ImmedisDbContext);
        }

        [TestMethod]
        public async Task GetByIdAsync_WhenIdIsNull_ShouldReturnNull()
        {
            var employee = await _employeeService.GetByIdAsync(null);
            Assert.IsNull(employee);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        public async Task GetByIdAsync_WhenIdIsInvalid_ShouldReturnNull(int value)
        {
            var employee = await _employeeService.GetByIdAsync(value);
            Assert.IsNull(employee);
        }

        [TestMethod]
        public async Task SaveChangesAsync_WhenEmplyeeIsNull_ShouldReturnFalse()
        {
            var result = await _employeeService.SaveChangesAsync(null);
            Assert.IsFalse(result);
        }
    }
}
