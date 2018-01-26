using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FooFoo {
    public class DataTableToCsvMapper {
        public System.IO.MemoryStream Map(DataTable dataTable) {
            MemoryStream returnStream = new MemoryStream();

            StreamWriter sw = new StreamWriter(returnStream);
            WriteColumnNames(dataTable, sw);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();

            return returnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw) {
            foreach (DataRow dr in dt.Rows) {
                WriteRow(dt, dr, sw);
                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, DataRow dr, StreamWriter sw) {
            for (int i = 0; i < dt.Columns.Count; i++) {
                WriteCell(dr[i], sw);

                WriteSeparatorIfRequired(dt, i, sw);
            }
        }

        private static void WriteSeparatorIfRequired(DataTable dt, int i, StreamWriter sw) {
            if (i < dt.Columns.Count - 1) {
                sw.Write(",");
            }
        }

        private static void WriteCell(object dataCell, StreamWriter sw) {
            if (!Convert.IsDBNull(dataCell)) {
                string str = String.Format("\"{0:c}\"", dataCell.ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else {
                sw.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw) {
            for (int i = 0; i < dt.Columns.Count; i++) {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1) {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }
    }
}