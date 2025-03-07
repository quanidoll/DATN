using System;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace VicemMVCIdentity.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ReadExcelToDataTable(Stream fileStream)
        {
            DataTable dataTable = new DataTable();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Dùng EPPlus miễn phí

            using (var package = new ExcelPackage(fileStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Đọc sheet đầu tiên

                if (worksheet == null)
                    throw new Exception("Không tìm thấy sheet nào trong file Excel.");

                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                // Thêm cột vào DataTable (dòng tiêu đề)
                for (int col = 1; col <= colCount; col++)
                {
                    dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                }

                // Đọc dữ liệu từ dòng thứ 2 trở đi
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        dataRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
