using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Globalization;

namespace realbau_app.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Import excela 
        public async Task<DataTable> Import(IFormFile addressFile)
        {

            using (var reader = new StreamReader("C:\\Users\\lfili\\Downloads\\TM.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
            }

            //using (var addressMemoryStream = new MemoryStream())
            //{
            //    await addressFile.CopyToAsync(addressMemoryStream);
            //    using (var reader = new StreamReader(addressMemoryStream))
            //    {
            //        List<string> listA = new List<string>();
            //        List<string> listB = new List<string>();
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            var values = line.Split(';');

            //            listA.Add(values[0]);
            //            listB.Add(values[1]);
            //        }
            //        //var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            //        //{
            //        //    HasHeaderRecord = false,
            //        //};

            //        //using (var csv = new CsvReader(reader, configuration))
            //        //{
            //        //    var records = csv.GetRecords<dynamic>();
            //        //}
            //    }
            //}
            
            
            return null;

            //DataTable dtTable = new DataTable();
            //List<string> rowList = new List<string>();
            //ISheet sheet;
            //using (var stream = new MemoryStream())
            //{
            //    await addressFile.CopyToAsync(stream);
            //    stream.Position = 0;
            //    XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
            //    sheet = xssWorkbook.GetSheetAt(0);
            //    IRow headerRow = sheet.GetRow(0);
            //    int cellCount = headerRow.LastCellNum;
            //    for (int j = 0; j < cellCount; j++)
            //    {
            //        ICell cell = headerRow.GetCell(j);
            //        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
            //        {
            //            dtTable.Columns.Add(cell.ToString());
            //        }
            //    }
            //    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            //    {
            //        IRow row = sheet.GetRow(i);
            //        if (row == null) continue;
            //        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
            //        for (int j = row.FirstCellNum; j < cellCount; j++)
            //        {
            //            if (row.GetCell(j) != null)
            //            {
            //                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
            //                {
            //                    rowList.Add(row.GetCell(j).ToString());
            //                }
            //            }
            //        }
            //        if (rowList.Count > 0)
            //            dtTable.Rows.Add(rowList.ToArray());
            //        rowList.Clear();
            //    }
            //}

            //return dtTable;

            //return JsonConvert.SerializeObject(dtTable);

            //var list = new List<DGData>();

            //         using (var stream = new MemoryStream())
            //         {
            //             await file1.CopyToAsync(stream);
            //             using (var package = new ExcelPackage(stream))
            //             {
            //                 ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            //                 var rowcount = worksheet.Dimension.Rows;
            //                 for (int i = 0; i < rowcount; i++)
            //                 {
            //                     list.Add(new DGData()
            //                     {
            //                         firstName = worksheet.Cells[i, 2].Value.ToString().Trim(),
            //                         lastName = worksheet.Cells[i, 3].Value.ToString().Trim(),
            //                         country = worksheet.Cells[i, 5].Value.ToString().Trim(),
            //                         gender = worksheet.Cells[i, 4].Value.ToString().Trim(),
            //                         date = worksheet.Cells[i, 7].Value.ToString().Trim()

            //                     });
            //                 }
            //                 return list;
            //             }
            //         }
        }


    }
}
