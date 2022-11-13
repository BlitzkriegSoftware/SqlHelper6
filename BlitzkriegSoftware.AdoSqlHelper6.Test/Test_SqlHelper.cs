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
            AttachDb();
        }

        [ClassCleanup]
        public static void UnSetupTests()
        {
            DetachDb();
        }

        #endregion

        #region "Privates"

        public const string Database_Name = "Zoo.mdf";

        private static string ZooMakeConnectionString()
        {
            var cs = string.Format(@"Server=.\SQLExpress;Database=Zoo;Trusted_Connection = Yes; ");
            return cs;
        }
        private static string MasterMakeConnectionString()
        {
            var cs = string.Format(@"Server=.\SQLExpress;Database=Master;Trusted_Connection=Yes; ");
            return cs;
        }

        public static string FindFiles(string directory, string filename)
        {
            foreach (string f in Directory.GetFiles(directory, filename))
            {
                var shortPath = Path.GetFileName(f);
                if (shortPath.Equals(filename))
                {
                    var path = Path.ChangeExtension(f, "");
                    return path[0..^1];
                }
            }
            return string.Empty;
        }

        public static string DirSearch(string directory, string filename)
        {
            var path = FindFiles(directory, filename);
            if (!string.IsNullOrWhiteSpace(path)) return path;

            foreach (string d in Directory.GetDirectories(directory))
            {
                path = FindFiles(directory, filename);
                if (!string.IsNullOrWhiteSpace(path)) return path;

                DirSearch(d, filename);
            }
            return string.Empty;
        }

        private static void AttachDb()
        {
            var cs = MasterMakeConnectionString();
            var dbPath = DirSearch(Directory.GetCurrentDirectory(), Database_Name);
            var log = $"{dbPath}_log.ldf";
            if (File.Exists(log)) File.Delete(log);
            var cSql = $"CREATE DATABASE [Zoo] ON ( FILENAME = '{dbPath}.mdf') FOR ATTACH;";
            try
            {
                SqlHelper.ExecuteSqlWithParametersNoReturn(cs, cSql, null);
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("Database 'Zoo' already exists."))
                {
                    throw;
                }
            }
        }

        private static void DetachDb()
        {
            var cs = MasterMakeConnectionString();
            var cSql = $"EXEC sp_detach_db 'Zoo', 'true';";
            SqlHelper.ExecuteSqlWithParametersNoReturn(cs, cSql, null);
        }

        #endregion

        #region "SP Tests"

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteStoredProcedureWithDataTable_1()
        {
            SqlParameter p = SqlHelper.ParameterBuilder("@atLeastThisMany", System.Data.SqlDbType.Int, 10);

            var paras = new List<SqlParameter>()
            {
                p
            };

            paras = SqlHelper.CleanParameters(paras);

            var dt = SqlHelper.ExecuteStoredProcedureWithDataTable(ZooMakeConnectionString(), "pAnimalEnclosures", paras);

            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteStoredProcedureWithNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            SqlHelper.ExecuteStoredProcedureWithNoReturn(ZooMakeConnectionString(), "pAnimalCount", paras);
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteStoredProcedureWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var ct = SqlHelper.ExecuteStoredProcedureWithParametersToScaler<int>(ZooMakeConnectionString(), "pAnimalCount", paras);
            Assert.IsTrue((ct > 0));
        }

        #endregion

        #region "SQL Tests"

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteSqlWithParametersToScaler_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select count(1) from [Animal]";
            var data = SqlHelper.ExecuteSqlWithParametersToScaler<int>(ZooMakeConnectionString(), sql, paras);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteSqlWithParametersToDataTable_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select * from [Animal]";
            var dt = SqlHelper.ExecuteSqlWithParametersToDataTable(ZooMakeConnectionString(), sql, paras);
            Assert.IsTrue(SqlHelper.HasRows(dt));
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_ExecuteSqlWithParametersNoReturn_1()
        {
            var paras = new List<SqlParameter>();
            var sql = "select count(1) from [Animal]";
            SqlHelper.ExecuteSqlWithParametersNoReturn(ZooMakeConnectionString(), sql, paras);
        }

        #endregion

        #region "Misc."

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_FixPara_1()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(inText, string.Empty, '"');
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void T_FixPara_2()
        {
            var inText = "Foo, Bar, Moo,";
            var expected = "\"Foo\",\"Bar\",\"Moo\"";
            var outText = SqlHelper.FixSqlInText(string.Empty, inText, '"');
            Assert.AreEqual(expected, outText);
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
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
        [TestCategory("Unit-Test")]
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
}