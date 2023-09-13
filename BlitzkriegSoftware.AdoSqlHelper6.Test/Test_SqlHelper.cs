namespace BlitzkriegSoftware.AdoSqlHelper6.Test
{
    #region "Usings"
    using BlitzkriegSoftware.AdoSqlHelper6.Test.Libs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    #endregion

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TesSqlHelper
    {

        #region "Info"

        /// <summary>
        /// Docker Connection String to Northwind
        /// </summary>
        public const string Database_ConnectionString = "Server=127.0.0.1,1433;Database=Northwind;User Id=sa;Password=blitz!2023stw-;";

        #endregion

        #region "Boilerplate"

        private static TestContext _testContext;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [ClassCleanup]
        public static void UnSetupTests()
        {
        }

        #endregion

        #region "SP Tests"

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteStoredProcedureWithDataTable_1()
        {
            SqlParameter p = SqlHelper.ParameterBuilder("@CustomerID", System.Data.SqlDbType.NChar, 5, "ALFKI");

            var paras = new List<SqlParameter>()
            {
                p
            };

            paras = SqlHelper.CleanParameters(paras);

            var dt = SqlHelper.ExecuteStoredProcedureWithDataTable(Database_ConnectionString , "[dbo].[CustOrderHist]", paras);
            _testContext.DumpDataTable(dt, "Cust Orders", 3);
            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteStoredProcedureWithNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            var count = SqlHelper.ExecuteStoredProcedureWithNoReturn(Database_ConnectionString, "[dbo].[Ten Most Expensive Products]", paras);
            _testContext.WriteLine($"Scaler: {count}");
            Assert.AreEqual(-1,count );
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteStoredProcedureWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var ct = SqlHelper.ExecuteStoredProcedureWithParametersToScaler<long>(Database_ConnectionString, "[dbo].[bkCountProducts]", paras);
            _testContext.WriteLine($"Scaler: {ct}");
            Assert.IsTrue((ct > 0));
        }

        #endregion

        #region "SQL Tests"

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteSqlWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select count(1) from [dbo].[Products]";
            var data = SqlHelper.ExecuteSqlWithParametersToScaler<int>(Database_ConnectionString, sql, paras);
            _testContext.WriteLine($"Scaler: {data}");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteSqlWithParametersToDataTable_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select top(3) * from [dbo].[Products]";
            var dt = SqlHelper.ExecuteSqlWithParametersToDataTable(Database_ConnectionString, sql, paras);
            _testContext.DumpDataTable(dt, "Products", 0);
            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void ExecuteSqlWithParametersNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            string sql = "select count(1) from [dbo].[Products]";
            var count = SqlHelper.ExecuteSqlWithParametersNoReturn(Database_ConnectionString, sql, paras);
            Assert.AreEqual(-1, count);
        }

        #endregion

        #region "Misc."

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void FixPara_1()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(inText, string.Empty, '"');
            _testContext.WriteLine($"Exp: {expected}, out: {outText}");
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void FixPara_2()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(string.Empty, inText, '"');
            _testContext.WriteLine($"Exp: {expected}, out: {outText}");
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void CleanParameters_1()
        {
            var expected = "Pete''s";

            SqlParameter p = SqlHelper.ParameterBuilder("@textPara", System.Data.SqlDbType.NVarChar, "Pete's");

            var paras = new List<SqlParameter>()
            {
                p
            };

            paras = SqlHelper.CleanParameters(paras);
            var p2 = paras[0];

            Assert.AreEqual(p2.Value, expected);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void HasTables_1()
        {
            var dt = new DataTable();
            var ds = new DataSet();
            ds.Tables.Add(dt);
            Assert.IsTrue(SqlHelper.HasTables(ds));
        }

        #endregion

    }
}