//using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agenda
{
    public class Funciones
    {
        public static void VisibilidadColumna(GridView tabla, int column, bool bVisible)
        {
            if (tabla.Rows.Count > 0)
            {
                tabla.HeaderRow.Cells[column].Visible = bVisible;
                foreach (GridViewRow row in tabla.Rows)
                    row.Cells[column].Visible = bVisible;
            }
        }
        

        public static char ObtenerVerificador(string sRut)
        {
            if (String.IsNullOrEmpty(sRut))
                return '-';
            int[] iN = new int[] { 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7 };
            if (sRut.Length >= iN.Length)            
                return '-';
            
            List<int> iList = new List<int>();

            try
            {
                foreach (char item in sRut)
                    iList.Add(int.Parse(item.ToString()));
            }
            catch (Exception)// no es un rut realmente
            {
                return '-';
            }
            
            iList.Reverse();
            int iTotal = 0;
            for (int i = 0; i < iList.Count; i++)
            {
                iList[i] = iList[i] * iN[i];
                iTotal += iList[i];
            }
            int iMod = iTotal % 11;
            int iV = 11 - iMod;
            if (iV == 11)
                return '0';
            if (iV == 10)            
                return 'K';
            return char.Parse(iV.ToString());
        }

        public static string ObtenerEdadString(string sFechaNacimiento)
        {
            if (sFechaNacimiento == "&nbsp;" || String.IsNullOrEmpty(sFechaNacimiento))            
                return "";            
            //método de cristian
            int iMeses = (int)DateDiff(DateInterval.Month, DateTime.Parse(sFechaNacimiento), DateTime.Today);
            int iAnio = iMeses / 12;
            string sEdad = iAnio.ToString() + " años " + (iMeses - (iAnio * 12)).ToString() + " meses";
            return sEdad;
        }

        public static int ObtenerEdad(string sFechaNacimiento)
        {
            DateTime dHoy = DateTime.Today;
            DateTime dNac;
            try
            {
                dNac = DateTime.Parse(sFechaNacimiento);
            }
            catch (Exception)
            {
                dNac = dHoy;
            }
           
            int iEdad = dHoy.Year - dNac.Year;

            if (dNac > dHoy.AddYears(-iEdad))
                iEdad--;
            return iEdad;
        }


        //public static void ExportarTablaClosedXml(Page page, string nombreArchivo, string nombreHoja, GridView gv,bool bOmitirPrimero = false, bool bOmitirUltimo = false)
        //{
        //    XLWorkbook workbook = new XLWorkbook();

        //    CrearHojaExcel(ref workbook, nombreHoja, gv, bOmitirPrimero, bOmitirUltimo);

        //    MemoryStream Stream = GetStream(workbook);

        //    page.Response.Clear();
        //    page.Response.Buffer = true;
        //    page.Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo + ".xlsx");
        //    page.Response.ContentType = "application/vnd.ms-excel";
        //    page.Response.ContentEncoding = System.Text.Encoding.Unicode;
        //    page.Response.BinaryWrite(Stream.ToArray());
        //    page.Response.End();
        //    //workbook.SaveAs(@"c:\RCD\HelloWorld.xlsx");
        //}

        //public static void CrearHojaExcel(ref XLWorkbook workbook, string nombreHoja, GridView gv, bool bOmitirPrimero, bool bOmitirUltimo)
        //{

        //    //EXCEL NO PERMITE HOJAS CON NOMBRES MAYOR A 30 CARACTERES
        //    if (nombreHoja.Length > 25)
        //        nombreHoja = nombreHoja.Substring(0, 25);
        //    IXLWorksheet worksheet;
        //    worksheet = workbook.Worksheets.Add((workbook.Worksheets.Count + 1).ToString() + "-" + nombreHoja);

        //    int iC = bOmitirPrimero ? 1 : 0;
        //    int iRow = 1;
        //    int iColumnCount = gv.Columns.Count;
        //    if (bOmitirUltimo)
        //        iColumnCount--;
        //    for (int c = iC; c < iColumnCount; c++)
        //        worksheet.Cell(iRow, c + 1).Value = gv.Columns[c].HeaderText;

        //    for (int i = 0; i < gv.Rows.Count; i++)
        //    {
        //        worksheet.Cell(i + 1 + iRow, 1).Value = (i + 1);

        //        //SI LA PRIMERA CELDA TIENE UN BOTÓN, SACO EL TEXTO DE ESTA FORMA                
        //        //if (bOmitirPrimero)
        //        //{
        //        //    Button a = (Button)gv.Rows[i].Cells[0].Controls[1];
        //        //    worksheet.Cell(i + 1 + iRow, 2).Value = a.Text;
        //        //}
        //        if (gv.Rows[i].CssClass == "alert alert-warning")
        //        {
        //            worksheet.Row(i + 1 + iRow).Cells(2, iColumnCount + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 243, 205);
        //            worksheet.Row(i + 1 + iRow).Cells(2, iColumnCount + 1).Style.Font.FontColor = XLColor.FromArgb(133, 100, 4);
        //        }
        //        //LAS DEMÁS CELDAS SON PURO TEXTO
        //        for (int c = iC; c < iColumnCount; c++)
        //        {
        //            TableCell cell = gv.Rows[i].Cells[c];
        //            if (cell.Text == "&nbsp;")
        //            {
        //                worksheet.Cell(i + 1 + iRow, c + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(230, 230, 230);
        //                worksheet.Cell(i + 1 + iRow, c + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //            }
        //            else
        //            {
        //                worksheet.Cell(i + 1 + iRow, c + 1).Value = HttpUtility.HtmlDecode(cell.Text);
        //                worksheet.Cell(i + 1 + iRow, c + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //            }

        //            if (cell.CssClass == "alert alert-danger")
        //            {
        //                worksheet.Cell(i + 1 + iRow, c + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(248, 215, 218);
        //                worksheet.Cell(i + 1 + iRow, c + 1).Style.Font.FontColor = XLColor.FromArgb(114, 28, 36);
        //            }
        //        }
        //    }

        //    worksheet.CellsUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //    worksheet.CellsUsed().Style.Border.OutsideBorderColor = XLColor.Black;

        //    worksheet.Column(1).Cells().Style.Fill.BackgroundColor = XLColor.FromArgb(188, 218, 255);
        //    worksheet.ColumnsUsed().AdjustToContents();

        //    IXLRange rangeTable = worksheet.Range(worksheet.FirstCellUsed(), worksheet.LastCellUsed());
        //    IXLTable table = rangeTable.CreateTable();
        //}

        //static MemoryStream GetStream(XLWorkbook workbook)
        //{
        //    MemoryStream fs = new MemoryStream();
        //    workbook.SaveAs(fs);
        //    fs.Position = 0;
        //    return fs;
        //}


        //DateDiff c#
        public enum DateInterval
        {
            Day,
            DayOfYear,
            Hour,
            Minute,
            Month,
            Quarter,
            Second,
            Weekday,
            WeekOfYear,
            Year
        }
        public static long DateDiff(DateInterval intervalType, System.DateTime dateOne, System.DateTime dateTwo)
        {
            switch (intervalType)
            {
                case DateInterval.Day:
                case DateInterval.DayOfYear:
                    System.TimeSpan spanForDays = dateTwo - dateOne;
                    return (long)spanForDays.TotalDays;
                case DateInterval.Hour:
                    System.TimeSpan spanForHours = dateTwo - dateOne;
                    return (long)spanForHours.TotalHours;
                case DateInterval.Minute:
                    System.TimeSpan spanForMinutes = dateTwo - dateOne;
                    return (long)spanForMinutes.TotalMinutes;
                case DateInterval.Month:
                    return ((dateTwo.Year - dateOne.Year) * 12) + (dateTwo.Month - dateOne.Month);
                case DateInterval.Quarter:
                    long dateOneQuarter = (long)System.Math.Ceiling(dateOne.Month / 3.0);
                    long dateTwoQuarter = (long)System.Math.Ceiling(dateTwo.Month / 3.0);
                    return (4 * (dateTwo.Year - dateOne.Year)) + dateTwoQuarter - dateOneQuarter;
                case DateInterval.Second:
                    System.TimeSpan spanForSeconds = dateTwo - dateOne;
                    return (long)spanForSeconds.TotalSeconds;
                case DateInterval.Weekday:
                    System.TimeSpan spanForWeekdays = dateTwo - dateOne;
                    return (long)(spanForWeekdays.TotalDays / 7.0);
                case DateInterval.WeekOfYear:
                    System.DateTime dateOneModified = dateOne;
                    System.DateTime dateTwoModified = dateTwo;
                    while (dateTwoModified.DayOfWeek != System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek)
                    {
                        dateTwoModified = dateTwoModified.AddDays(-1);
                    }
                    while (dateOneModified.DayOfWeek != System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek)
                    {
                        dateOneModified = dateOneModified.AddDays(-1);
                    }
                    System.TimeSpan spanForWeekOfYear = dateTwoModified - dateOneModified;
                    return (long)(spanForWeekOfYear.TotalDays / 7.0);
                case DateInterval.Year:
                    return dateTwo.Year - dateOne.Year;
                default:
                    return 0;
            }
        }

        public static string MD5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            StringBuilder sBuilder = new StringBuilder();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}