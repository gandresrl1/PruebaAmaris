using DAL.Employee;
using Moq;
using Services.Employee;
using Xunit.Sdk;

namespace Test
{
    [TestClass]
    public class SrvEmployeeTest
    {
        private readonly Mock<IDalEmployee> _dalEmployee;

        public SrvEmployeeTest()
        {
            _dalEmployee = new Mock<IDalEmployee>();
        }

        [TestMethod]
        public void CalculateAnualSalary_Type()
        {
            var srv = new SrvEmployee(_dalEmployee.Object);
            var result = srv.CalculateAnualSalary(100);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        public void CalculateAnualSalary_NotNull()
        {
            var srv = new SrvEmployee(_dalEmployee.Object);
            var result = srv.CalculateAnualSalary(100);
            Assert.IsNotNull(result);
        }

        [TestMethod]        
        public void CalculateAnualSalary_EqualValue()
        {
            int finalResult = 1200;
            var srv = new SrvEmployee(_dalEmployee.Object);
            var result = srv.CalculateAnualSalary(100);
            Assert.AreEqual(finalResult, result);
        }
    }
}