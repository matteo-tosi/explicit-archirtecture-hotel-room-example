using DotNetExtensions.DomainAbstraction.Enumeration;

namespace DotNetExtensions.Test.DomainAbstraction.Enumeration
{
    [TestClass]
    public sealed class AbstractEnumerationTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(TestEnum.A.Value == 0, message: "Check valore A");
            Assert.IsTrue(TestEnum.B.Value == 1, message: "Check valore B");
            Assert.IsTrue(TestEnum.C.Value == 2, message: "Check valore C");
            Assert.IsTrue(TestEnum.D.Value == 3, message: "Check valore D");

            Assert.IsTrue(TestEnum.A.Name.Equals("A", StringComparison.Ordinal), message: "Check nome A");
            Assert.IsTrue(TestEnum.B.Name.Equals("B", StringComparison.Ordinal), message: "Check nome B");
            Assert.IsTrue(TestEnum.C.Name.Equals("C", StringComparison.Ordinal), message: "Check nome C");
            Assert.IsTrue(TestEnum.D.Name.Equals("C", StringComparison.Ordinal), message: "Check nome D");

            // Ugualianza per valore
            var a1 = TestEnum.A;
            var a2 = TestEnum.A;
            Assert.IsTrue(a1 == a2, message: "Check ugualianza per valore A=A");

            // Ugualianza per valore (non per descrizione)
            var c = TestEnum.C;
            var d = TestEnum.D;
            Assert.IsTrue(c != d, message: "Check ugualianza non per nome C!=D");

            // Vincolo di valori non duplicati
            _ = Assert.ThrowsException<TypeInitializationException>(
                () => TestEnumDoubleValue.A == TestEnumDoubleValue.B,
                message: "Check vincolo univocità valore");
        }

        private sealed record class TestEnum : AbstractEnumeration<TestEnum, short>
        {
            public readonly static TestEnum A = new(value: 0, "A");
            public readonly static TestEnum B = new(value: 1, "B");
            public readonly static TestEnum C = new(value: 2, "C");
            public readonly static TestEnum D = new(value: 3, "C");

            public TestEnum(short value, string name) : base(value, name) { }
        }

        private sealed record class TestEnumDoubleValue : AbstractEnumeration<TestEnumDoubleValue, short>
        {
            public readonly static TestEnumDoubleValue A = new(value: 0, "A");
            public readonly static TestEnumDoubleValue B = new(value: 0, "B");

            public TestEnumDoubleValue(short value, string name) : base(value, name) { }
        }
    }
}
