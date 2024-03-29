﻿using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Abstraction.Services;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;
using Bushman.AutoCAD.Bundle.Implementation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bushman.AutoCAD.Bundle.Implementations.Default.Test {
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class ValidationFactoryTests {
        public ValidationFactoryTests() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1() {

            IFactoryProvider factoryProvider = new FactoryProvider();
            IBundleFactory factory = factoryProvider.CreateBundleFactory();

            IApplicationPackage package = factory.CreateInstance<IApplicationPackage>();

            IValidationFactory validationFactory = factoryProvider.CreateValidationFactory();
            IRulesProvider rulesProvider = validationFactory.CreateRulesProvider();
            IPackageValidator packageValidator = validationFactory.CreatePackageValidator();

            IRule[] validationRules = rulesProvider.GetRules();
            IPackageValidationResult pkgValidationResult = packageValidator.Validate(validationRules, package);
        }
    }
}
