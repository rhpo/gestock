using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace GEStock.Utils
{
    public static class ExcelExporter
    {
        public static void ExportDataGridView(DataGridView dgv, string title)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"{title}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add(title);

                            // Headers
                            int colIndex = 1;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible && !(dgv.Columns[i] is DataGridViewImageColumn))
                                {
                                    worksheet.Cell(1, colIndex).Value = dgv.Columns[i].HeaderText;
                                    worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                                    worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.FromHtml("#4285F4");
                                    worksheet.Cell(1, colIndex).Style.Font.FontColor = XLColor.White;
                                    colIndex++;
                                }
                            }

                            // Data
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                colIndex = 1;
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    if (dgv.Columns[j].Visible && !(dgv.Columns[j] is DataGridViewImageColumn))
                                    {
                                        var val = dgv.Rows[i].Cells[j].Value;
                                        worksheet.Cell(i + 2, colIndex).Value = val?.ToString() ?? "";
                                        colIndex++;
                                    }
                                }
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Exportation réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'exportation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
