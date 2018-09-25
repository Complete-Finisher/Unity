using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;

public class WriteExcel : MonoBehaviour {




	// Use this for initialization
	void Start () {

        //这个文件用于测试,函数是从Eidtor/ExcelAccess.cs文件中挪过来的
        writeExcel("newTable.xlsx", "sheet1");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 写入 Excel ; 需要添加 OfficeOpenXml.dll;
    /// </summary>
    /// <param name="excelName">excel文件名</param>
    /// <param name="sheetName">sheet名称</param>
    public static void writeExcel(string excelName, string sheetName)
    {
        //通过面板设置excel路径
        //string outputDir = UnityEditor.EditorUtility.SaveFilePanel("Save Excel", "", "New Resource", "xlsx");

        //自定义excel的路径
        string path = Application.dataPath + "/" + excelName;
       
        FileInfo newFile = new FileInfo(path);
        if (newFile.Exists)
        {
            //创建一个新的excel文件
            newFile.Delete();
            newFile = new FileInfo(path);
        }

        //通过ExcelPackage打开文件
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            //在excel空文件添加新sheet
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);
            //添加列名
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Product";
            worksheet.Cells[1, 3].Value = "Quantity";
            worksheet.Cells[1, 4].Value = "Price";
            worksheet.Cells[1, 5].Value = "Value";

            //添加一行数据
            worksheet.Cells["A2"].Value = 12001;
            worksheet.Cells["B2"].Value = "Nails";
            worksheet.Cells["C2"].Value = 37;
            worksheet.Cells["D2"].Value = 3.99;
            //添加一行数据
            worksheet.Cells["A3"].Value = 12002;
            worksheet.Cells["B3"].Value = "Hammer";
            worksheet.Cells["C3"].Value = 5;
            worksheet.Cells["D3"].Value = 12.10;
            //添加一行数据
            worksheet.Cells["A4"].Value = 12003;
            worksheet.Cells["B4"].Value = "Saw";
            worksheet.Cells["C4"].Value = 12;
            worksheet.Cells["D4"].Value = 15.37;

            //保存excel
            package.Save();
        }
    }
}
