namespace p_oo_parking.Tests
{
    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void PlateValidation_ValidPlate_ReturnsTrue()
        {
            string validPlate = "AB-1234";
            
            bool result = Helpers.PlateValidation(validPlate);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PlateValidation_UnvalidPlate_ReturnsFalse()
        {
            string unvalidPlate = "AB-12";

            bool result = Helpers.PlateValidation(unvalidPlate);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlateValidation_EmptyString_ReturnsFalse()
        {
            string emptyPlate = "";

            bool result = Helpers.PlateValidation(emptyPlate);

            Assert.IsFalse(result);
        }
    }
}
