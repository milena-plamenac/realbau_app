using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using realbau_app.api.Models;
using realbau_app.Models.Import;
using System.Data;
using System.Globalization;
using System.Text;

namespace realbau_app.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult NewAddresses(List<NewAddress> newAddresses)
        //{
        //    return View(newAddresses);
        //}

        // Import excela 
        public IActionResult NewAddresses(IFormFile addressFile)
        {
            List<NewAddress> newAddresses = new List<NewAddress>();

            using (var reader = new StreamReader(addressFile.OpenReadStream(), Encoding.GetEncoding("Windows-1252")))
            {
                List<string> badRecord = new List<string>();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    Mode = CsvMode.NoEscape,
                    BadDataFound = context => badRecord.Add(context.RawRecord)
                };

                List<dynamic> data = new List<dynamic>();


                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();

                    var header = csv.Context.Reader.HeaderRecord.ToList();

                    while (csv.Parser.Read())
                    {

                        //data.Add(csv.Parser.Record);
                        var rec = csv.Parser.Record;

                        if (rec[22] != "ACCEPTED")
                            continue;

                        IEnumerable<AddressDB> addressDBs = null;
                        var exists = 0;

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("https://localhost:7003/api/Address/" + rec[6] + "/" + rec[7] + "/" + rec[8] + "/" + rec[9] + "/" + rec[11]);
                            //HTTP GET


                            var responseTask = client.GetAsync("");
                            responseTask.Wait();

                            var result = responseTask.Result;
                            var readResult = result.Content.ReadFromJsonAsync<int>();
                            readResult.Wait();

                            exists = readResult.Result;
                            //if (result.IsSuccessStatusCode)
                            //{
                            //    var readTask = result.Content.ReadFromJsonAsync<IList<HausbegehungDefaultTermDB>>();
                            //    readTask.Wait();

                            //    terms = readTask.Result;
                            //}
                            //else //web api sent error response 
                            //{
                            //    log response status here..terms = Enumerable.Empty<HausbegehungDefaultTermDB>();

                            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            //}
                        }

                        if (exists == 0)
                            newAddresses.Add(new NewAddress()
                            {
                                Bestellnummer = rec[0],
                                SP_Name = rec[1],
                                Name = rec[2],
                                Telefon = rec[3],
                                Handy = rec[4],
                                Email = rec[5],
                                Ort = rec[6],
                                Zipcode = rec[7],
                                Straße = rec[8], //Encoding.GetEncoding(850).GetString(Encoding.Default.GetBytes(rec[8])),
                                Nummer = rec[9],
                                NrZusatz = rec[10],
                                WeitereSusatz = rec[11],
                                AnschlussStatus = rec[12],
                                AccessLocation = rec[13],
                                IP_ODF = rec[14],
                                IP_Port = rec[15],
                                TV_ODF = rec[16],
                                Projectcode = rec[26],
                                Kennwort = rec[28],
                                Subtype = rec[35]
                            });

                        //if(newAddresses.Count() >0)
                        //return View("NewAddresses", newAddresses);
                    }
                }

                var p = "test";

                return View("NewAddresses", newAddresses);

                //using (var reader = new StreamReader("C:\\Users\\lfili\\Downloads\\TM.csv"))
                //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                //{
                //    var records = csv.GetRecords<dynamic>();
                //}

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


                //return null;

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

        public IActionResult RncUpdate()
        {
            ViewBag.message = "Get";
            return View();
        }

        [HttpPost]
        public IActionResult RncUpdate(IFormFile rncUpdateFile)
        {
            ViewBag.message = "Post";

            List<NewAddress> newAddresses = new List<NewAddress>();

            using (var reader = new StreamReader(rncUpdateFile.OpenReadStream(), Encoding.GetEncoding("Windows-1252")))
            {
                List<string> badRecord = new List<string>();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    Mode = CsvMode.NoEscape,
                    BadDataFound = context => badRecord.Add(context.RawRecord)
                };

                List<dynamic> data = new List<dynamic>();


                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();

                    var header = csv.Context.Reader.HeaderRecord.ToList();

                    while (csv.Parser.Read())
                    {

                        //data.Add(csv.Parser.Record);
                        var rec = csv.Parser.Record;

                        //if (rec[22] != "ACCEPTED")
                        //    continue;

                        IEnumerable<AddressDB> addressDBs = null;
                        var exists = 0;

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("https://localhost:7003/api/Address/" + rec[5] + "/" + rec[6] + "/" + rec[7] + "/" + rec[8] + "/" + rec[10] + "/" + rec[13]);
                            //HTTP GET


                            var responseTask = client.GetAsync("");
                            responseTask.Wait();

                            var result = responseTask.Result;
                            var readResult = result.Content.ReadFromJsonAsync<int>();
                            readResult.Wait();

                            exists = readResult.Result;

                        }

                        //if (exists == 0)
                        //    newAddresses.Add(new NewAddress()
                        //    {
                        //        Bestellnummer = rec[0],
                        //        SP_Name = rec[1],
                        //        Name = rec[2],
                        //        Telefon = rec[3],
                        //        Handy = rec[4],
                        //        Email = rec[5],
                        //        Ort = rec[6],
                        //        Zipcode = rec[7],
                        //        Straße = rec[8], //Encoding.GetEncoding(850).GetString(Encoding.Default.GetBytes(rec[8])),
                        //        Nummer = rec[9],
                        //        NrZusatz = rec[10],
                        //        WeitereSusatz = rec[11],
                        //        AnschlussStatus = rec[12],
                        //        AccessLocation = rec[13],
                        //        IP_ODF = rec[14],
                        //        IP_Port = rec[15],
                        //        TV_ODF = rec[16],
                        //        Projectcode = rec[26],
                        //        Kennwort = rec[28],
                        //        Subtype = rec[35]
                        //    });

                 
                    }
                }

                var p = "test";

                ViewBag.message = "Success";
                return View();


            }

            
        }

    }



}
