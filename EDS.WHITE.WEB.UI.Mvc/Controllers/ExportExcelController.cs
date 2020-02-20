using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using EDS.WHITE.Services;
using EDS.WHITE.Entities;
namespace EDS.WHITE.WEB.UI.MVC.Controllers
{
    public class ExportExcelController : Controller
    {
        ParameterService paramSvc = new ParameterService();
        
        // GET: ExportExcel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExcelExport()
        {

            ParameterEntities newParam = new ParameterEntities();

            List<ParameterEntities> FileData = new List<ParameterEntities>();

            FileData = paramSvc.GetListParameter(null,null);

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("CODE", typeof(string));
                Dt.Columns.Add("category", typeof(string));

                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.CODE;
                    row[1] = data.DESCRIPTION;
                    Dt.Rows.Add(row);

                }

                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
                    worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;


                    worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.DefaultColWidth = 20;
                    worksheet.Column(2).AutoFit();

                    Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public ActionResult Download()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "FileManager.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}