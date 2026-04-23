using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Kernel.Pdf.Canvas.Draw;

namespace MedCompatibility.Services;

public class PdfReportService : IPdfReportService
{
    private PdfFont GetSystemFont()
    {
        try
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // Название ресурса формируется из DefaultNamespace + путь к файлу
            using var stream = assembly.GetManifestResourceStream("MedCompatibility.Resources.Fonts.OpenSans-Regular.ttf");
            if (stream != null)
            {
                using var ms = new MemoryStream();
                stream.CopyTo(ms);
                byte[] fontBytes = ms.ToArray();
                return PdfFontFactory.CreateFont(fontBytes, iText.IO.Font.PdfEncodings.IDENTITY_H, iText.Kernel.Font.PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Не удалось загрузить встроенный шрифт: {ex.Message}");
        }

        // Если встроенный шрифт не найден, пытаемся найти системные (менее надежно на Android)
        try
        {
            PdfFontFactory.RegisterSystemDirectories();
            var fonts = PdfFontFactory.GetRegisteredFonts();
            var targetFont = fonts.FirstOrDefault(f => f.Contains("roboto") || f.Contains("arial") || f.Contains("segoe"));
            if (targetFont != null)
                return PdfFontFactory.CreateRegisteredFont(targetFont, iText.IO.Font.PdfEncodings.IDENTITY_H);
            else if (fonts.Count > 0)
                return PdfFontFactory.CreateRegisteredFont(fonts.First(), iText.IO.Font.PdfEncodings.IDENTITY_H);
        }
        catch { }

        // Fallback (Кириллица здесь работать не будет, но спасет от краша IDENTITY_H)
        return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA, iText.IO.Font.PdfEncodings.CP1252);
    }

    private iText.Kernel.Colors.Color GetRiskColor(int riskLevelId)
    {
        return riskLevelId switch
        {
            3 => new DeviceRgb(211, 47, 47), // Высокий - Red
            2 => new DeviceRgb(245, 124, 0), // Средний - Orange
            1 => new DeviceRgb(251, 192, 45), // Низкий - Yellow
            _ => ColorConstants.BLACK
        };
    }

    private string GetRiskLevelName(int riskLevelId)
    {
        return riskLevelId switch
        {
            3 => "Высокий",
            2 => "Средний",
            1 => "Низкий",
            _ => "Неизвестно"
        };
    }

    private void DrawHeader(Document document, string doctorName, PdfFont font)
    {
        var safeDoctorName = doctorName ?? "Не указан";
        var table = new Table(new float[] { 1, 1 }).UseAllAvailableWidth();
        
        var titleCell = new iText.Layout.Element.Cell().Add(new Paragraph("VeriPharm")
            .SetFont(font)
            .SetFontSize(24)
            .SetBold()
            .SetFontColor(new DeviceRgb(25, 118, 210)))
            .Add(new Paragraph("Официальный медицинский отчет")
            .SetFont(font)
            .SetFontSize(14)
            .SetFontColor(ColorConstants.GRAY))
            .SetBorder(iText.Layout.Borders.Border.NO_BORDER);
        
        var dateCell = new iText.Layout.Element.Cell()
            .Add(new Paragraph($"Дата формирования: {DateTime.Now:dd.MM.yyyy}\nФИО врача: {safeDoctorName}")
            .SetFont(font)
            .SetFontSize(10))
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
            .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.BOTTOM)
            .SetBorder(iText.Layout.Borders.Border.NO_BORDER);

        table.AddCell(titleCell);
        table.AddCell(dateCell);
        document.Add(table);
        
        document.Add(new LineSeparator(new SolidLine()));
        document.Add(new Paragraph("\n"));
    }

    private void DrawFooter(Document document, PdfFont font)
    {
        Paragraph footer = new Paragraph("Сформировано в системе VeriPharm. Данный отчет носит информационный характер и не заменяет клиническое решение врача.")
            .SetFont(font)
            .SetFontSize(8)
            .SetItalic()
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFontColor(ColorConstants.GRAY)
            .SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() - 20, document.GetPdfDocument().GetDefaultPageSize().GetWidth() - document.GetLeftMargin() - document.GetRightMargin());

        document.Add(footer);
    }

    public Task<byte[]> GenerateCrossAnalysisReportAsync(string doctorName, List<medicine> checkedDrugs, List<interaction> interactions)
    {
        checkedDrugs ??= new List<medicine>();
        interactions ??= new List<interaction>();

        var baseFont = GetSystemFont();

        using var ms = new MemoryStream();
        using (var writer = new PdfWriter(ms))
        using (var pdf = new PdfDocument(writer))
        using (var document = new Document(pdf))
        {
            document.SetFont(baseFont);
            
            DrawHeader(document, doctorName, baseFont);

            document.Add(new Paragraph("Отчет о перекрестном анализе препаратов")
                .SetFont(baseFont).SetBold().SetFontSize(18).SetMarginBottom(10));

            var drugsHeaderCell = new iText.Layout.Element.Cell().Add(new Paragraph("Проверяемые препараты:")
                .SetFont(baseFont).SetBold())
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                .SetPadding(5);
                
            var drugsTable = new Table(1).UseAllAvailableWidth().SetMarginBottom(15);
            drugsTable.AddCell(drugsHeaderCell);
            var list = new iText.Layout.Element.List().SetSymbolIndent(12).SetListSymbol("• ");
            foreach (var drug in checkedDrugs)
            {
                var tradeName = drug?.TradeName ?? "Неизвестный препарат";
                var inn = drug?.INN ?? "Без МНН";
                list.Add(new ListItem($"{tradeName} ({inn})"));
            }
            drugsTable.AddCell(new iText.Layout.Element.Cell().Add(list).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetPadding(5));
            document.Add(drugsTable);

            var analysisHeaderCell = new iText.Layout.Element.Cell().Add(new Paragraph("Результаты анализа")
                .SetFont(baseFont).SetBold().SetFontSize(14))
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                .SetPadding(5);
            var analysisTableWrapper = new Table(1).UseAllAvailableWidth().SetMarginBottom(10);
            analysisTableWrapper.AddCell(analysisHeaderCell);
            document.Add(analysisTableWrapper);

            if (interactions.Any())
            {
                var table = new Table(new float[] { 1, 1, 3 }).UseAllAvailableWidth();
                
                table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Препараты").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));
                table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Уровень риска").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));
                table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Механизм и рекомендации").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));

                foreach (var interaction in interactions)
                {
                    if (interaction == null) continue;

                    var sub1Name = interaction.SubstanceId1Navigation?.Name ?? "Неизвестное вещество";
                    var sub2Name = interaction.SubstanceId2Navigation?.Name ?? "Неизвестное вещество";
                    string prepText = $"{sub1Name}\n+\n{sub2Name}";

                    var prepCell = new iText.Layout.Element.Cell().Add(new Paragraph(prepText))
                        .SetPadding(5);

                    var riskCell = new iText.Layout.Element.Cell().Add(new Paragraph(GetRiskLevelName(interaction.RiskLevelId))
                        .SetFontColor(GetRiskColor(interaction.RiskLevelId))
                        .SetBold())
                        .SetPadding(5);
                        
                    var descCell = new iText.Layout.Element.Cell()
                        .Add(new Paragraph($"Описание: {interaction.Description ?? "Описание отсутствует"}\n").SetBold())
                        .Add(new Paragraph($"Рекомендация: {interaction.Recommendation ?? "Нет данных"}"))
                        .SetPadding(5);

                    table.AddCell(prepCell);
                    table.AddCell(riskCell);
                    table.AddCell(descCell);
                }
                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("Клинически значимых взаимодействий не обнаружено.")
                    .SetFont(baseFont).SetBold().SetFontColor(new DeviceRgb(56, 142, 60)));
            }

            DrawFooter(document, baseFont);
        }

        return Task.FromResult(ms.ToArray());
    }

    public Task<byte[]> GeneratePatientInteractionReportAsync(string doctorName, user patient, List<interaction> interactions, List<medicine> pastConflictingDrugs)
    {
        interactions ??= new List<interaction>();
        pastConflictingDrugs ??= new List<medicine>();

        var baseFont = GetSystemFont();

        using var ms = new MemoryStream();
        using (var writer = new PdfWriter(ms))
        using (var pdf = new PdfDocument(writer))
        using (var document = new Document(pdf))
        {
            document.SetFont(baseFont);
            
            DrawHeader(document, doctorName, baseFont);

            document.Add(new Paragraph("Отчет о совместимости препарата с пациентом")
                .SetFont(baseFont).SetBold().SetFontSize(18).SetMarginBottom(10));
                
            var patientHeaderCell = new iText.Layout.Element.Cell().Add(new Paragraph("Информация о пациенте")
                .SetFont(baseFont).SetBold())
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                .SetPadding(5);
                
            var patientTable = new Table(1).UseAllAvailableWidth().SetMarginBottom(15);
            patientTable.AddCell(patientHeaderCell);
            
            var safePatientName = patient?.FullName ?? "Неизвестный пациент";
            var patientInfo = new Paragraph($"ФИО: {safePatientName}");
            if (patient?.Allergies != null && patient.Allergies.Any())
            {
                patientInfo.Add("\n").Add(new Text("Зафиксированные непереносимости (аллергии):").SetBold().SetFontColor(new DeviceRgb(211, 47, 47)));
                foreach (var allergy in patient.Allergies)
                {
                    var allergyName = allergy?.Name ?? "Неизвестная аллергия";
                    patientInfo.Add($"\n• {allergyName}");
                }
            }
            else
            {
                 patientInfo.Add("\nЗафиксированные непереносимости: Нет");
            }
            patientTable.AddCell(new iText.Layout.Element.Cell().Add(patientInfo).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetPadding(5));
            document.Add(patientTable);

            var analysisHeaderCell = new iText.Layout.Element.Cell().Add(new Paragraph("Результаты анализа")
                .SetFont(baseFont).SetBold().SetFontSize(14))
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER)
                .SetPadding(5);
            var analysisTableWrapper = new Table(1).UseAllAvailableWidth().SetMarginBottom(10);
            analysisTableWrapper.AddCell(analysisHeaderCell);
            document.Add(analysisTableWrapper);

            if (interactions.Any() || pastConflictingDrugs.Any())
            {
                if (interactions.Any())
                {
                    var table = new Table(new float[] { 1, 1, 3 }).UseAllAvailableWidth().SetMarginBottom(15);
                    
                    table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Препараты").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));
                    table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Уровень риска").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));
                    table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph("Механизм и рекомендации").SetFont(baseFont).SetBold().SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY));

                    foreach (var interaction in interactions)
                    {
                        if (interaction == null) continue;

                        var sub1Name = interaction.SubstanceId1Navigation?.Name ?? "Неизвестное вещество";
                        var sub2Name = interaction.SubstanceId2Navigation?.Name ?? "Неизвестное вещество";
                        string prepText = $"{sub1Name}\n+\n{sub2Name}";

                        var prepCell = new iText.Layout.Element.Cell().Add(new Paragraph(prepText))
                            .SetPadding(5);

                        var riskCell = new iText.Layout.Element.Cell().Add(new Paragraph(GetRiskLevelName(interaction.RiskLevelId))
                            .SetFontColor(GetRiskColor(interaction.RiskLevelId))
                            .SetBold())
                            .SetPadding(5);
                            
                        var descCell = new iText.Layout.Element.Cell()
                            .Add(new Paragraph($"Описание: {interaction.Description ?? "Описание отсутствует"}\n").SetBold())
                            .Add(new Paragraph($"Рекомендация: {interaction.Recommendation ?? "Нет данных"}"))
                            .SetPadding(5);

                        table.AddCell(prepCell);
                        table.AddCell(riskCell);
                        table.AddCell(descCell);
                    }
                    document.Add(table);
                }

                if (pastConflictingDrugs.Any())
                {
                    document.Add(new Paragraph("Внимание! Конфликты вызваны следующими ранее назначенными (но еще действующими) препаратами:")
                        .SetFont(baseFont).SetBold().SetFontColor(new DeviceRgb(211, 47, 47)).SetMarginTop(5));
                        
                    var pastDrugsList = new iText.Layout.Element.List().SetSymbolIndent(12).SetListSymbol("• ");
                    foreach (var drug in pastConflictingDrugs)
                    {
                        if (drug == null) continue;
                        var tradeName = drug.TradeName ?? "Неизвестный препарат";
                        var inn = drug.INN ?? "Без МНН";
                        
                        var li = new ListItem();
                        li.Add(new Paragraph($"{tradeName} ({inn})").SetFontColor(new DeviceRgb(211, 47, 47)));
                        pastDrugsList.Add(li);
                    }
                    document.Add(pastDrugsList);
                }
            }
            else
            {
                document.Add(new Paragraph("Конфликтов с текущей терапией и аллергиями не обнаружено.")
                    .SetFont(baseFont).SetBold().SetFontColor(new DeviceRgb(56, 142, 60)));
            }

            DrawFooter(document, baseFont);
        }

        return Task.FromResult(ms.ToArray());
    }
}
