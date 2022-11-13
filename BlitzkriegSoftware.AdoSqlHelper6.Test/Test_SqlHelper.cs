namespace BlitzkriegSoftware.AdoSqlHelper6.Test
{
    #region "Usings"
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    #endregion

    [TestClass]
    public class Test_SqlHelper
    {
        #region "Boilerplate"

        private static TestContext? _testContext;

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

        #region "Info"

        /// <summary>
        /// Docker Connection String to Northwind
        /// </summary>
        public const string Database_ConnectionString = "Server=127.0.0.1,1433;Database=Northwind;User Id=sa;Password=blitz!2022stw-;";

        #endregion

        #region "SP Tests"

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteStoredProcedureWithDataTable_1()
        {
            SqlParameter p = SqlHelper.ParameterBuilder("@CustomerID", System.Data.SqlDbType.NChar, 5, "ALFKI");

            var paras = new List<SqlParameter>()
            {
                p
            };

            paras = SqlHelper.CleanParameters(paras);

            var dt = SqlHelper.ExecuteStoredProcedureWithDataTable(Database_ConnectionString , "[dbo].[CustOrderHist]", paras);

            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteStoredProcedureWithNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            SqlHelper.ExecuteStoredProcedureWithNoReturn(Database_ConnectionString, "[dbo].[Ten Most Expensive Products]", paras);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteStoredProcedureWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var ct = SqlHelper.ExecuteStoredProcedureWithParametersToScaler<long>(Database_ConnectionString, "[dbo].[bkCountProducts]", paras);
            Assert.IsTrue((ct > 0));
        }

        #endregion

        #region "SQL Tests"

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteSqlWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select count(1) from [dbo].[Products]";
            var data = SqlHelper.ExecuteSqlWithParametersToScaler<int>(Database_ConnectionString, sql, paras);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteSqlWithParametersToDataTable_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select * from [dbo].[Products]";
            var dt = SqlHelper.ExecuteSqlWithParametersToDataTable(Database_ConnectionString, sql, paras);
            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_ExecuteSqlWithParametersNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select count(1) from [dbo].[Products]";
            SqlHelper.ExecuteSqlWithParametersNoReturn(Database_ConnectionString, sql, paras);
        }

        #endregion

        #region "Misc."

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_FixPara_1()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(inText, string.Empty, '"');
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_FixPara_2()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(string.Empty, inText, '"');
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_CleanParameters_1()
        {
            SqlParameter p = SqlHelper.ParameterBuilder("@textPara", System.Data.SqlDbType.NVarChar, "Pete's");

            var paras = new List<SqlParameter>()
            {
                p
            };

            paras = SqlHelper.CleanParameters(paras);

            var p2 = paras[0];

            Assert.AreEqual(p2.Value, "Pete''s");
        }

        [TestMethod]
        [TestCategory("Integration-Test")]
        public void T_HasTables_1()
        {
            var dt = new DataTable();
            var ds = new DataSet();
            ds.Tables.Add(dt);
            Assert.IsTrue(SqlHelper.HasTables(ds));
        }

        #endregion
    }
}
