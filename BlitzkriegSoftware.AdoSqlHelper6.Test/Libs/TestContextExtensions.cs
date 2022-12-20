using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace BlitzkriegSoftware.AdoSqlHelper6.Test.Libs
{
    /// <summary>
    /// Test Context Extensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TestContextExtensions
    {
        /// <summary>
        /// Dump Data Table
        /// </summary>
        /// <param name="testContext">(sic)</param>
        /// <param name="dt">DataTable</param>
        /// <param name="title">(sic)</param>
        /// <param name="maxRows">Zero (0) for all, otherwise max rows to print</param>
        public static void DumpDataTable(this TestContext testContext, DataTable dt, string title, int maxRows = 1)
        {
            int ct = 0;
            testContext.WriteLine($"\n{title}");
            if((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    testContext.Write(dc.ColumnName + '\t');
                }
                testContext.WriteLine("");

                foreach (DataRow dr in dt.Rows )
                {
                    ct++;
                    foreach(DataColumn dc in dt.Columns)
                    {
                        testContext.Write(dr[dc].ToString() + '\t');
                    }
                    testContext.WriteLine("");
                    if((maxRows > 0) && (ct >= maxRows))
                    {
                        break;
                    }
                }
            } else
            {
                testContext.WriteLine("\t No Rows");
            }
        }

    }
}
