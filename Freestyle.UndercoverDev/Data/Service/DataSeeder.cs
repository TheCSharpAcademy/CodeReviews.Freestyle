using Data.Models;
using Data.Repository;
using OfficeOpenXml;
using Utilities;

namespace Data.Service;
public class DataSeeder : IDataSeeder
{
    const string filePath = "";
    private readonly IMatchDataRepository _matchDataRepository;

    public DataSeeder(IMatchDataRepository matchDataRepository)
    {
        _matchDataRepository = matchDataRepository;
    }

    public async Task ExtractMatchDatasetToDatabase()
    {
        var extractedData = new List<MatchData>();

        try
        {
            // Read data from the downloaded Excel file and extract relevant information
            using var package = new ExcelPackage(new FileInfo(filePath));

            if (package.Workbook.Worksheets.Count > 0)
            {
                var worksheet = package.Workbook.Worksheets[0];

                if (worksheet.Dimension == null || worksheet.Cells.Any(cell => cell.Value == null))
                {
                    Logger.Log("[bold][yellow]Excel file has no data.[/][/]");
                }

                var rowCount = worksheet.Dimension?.Rows ?? 0;

                for (var row = 2; row <= rowCount; row++)
                {
                    // Some flat fields may be null and that's okay
                    var matchData = new MatchData
                    {
                        Date = worksheet.Cells[row, 5].Value?.ToString(),
                        HomeTeam = worksheet.Cells[row, 2].Value?.ToString(),
                        AwayTeam = worksheet.Cells[row, 3].Value?.ToString(),
                        HomeWin = float.TryParse(worksheet.Cells[row, 6].Value?.ToString(), out float homeWin) ? homeWin : 0,
                        Draw = float.TryParse(worksheet.Cells[row, 7].Value?.ToString(), out float draw) ? draw : 0,
                        AwayWin = float.TryParse(worksheet.Cells[row, 8].Value?.ToString(), out float awayWin) ? awayWin : 0,
                        OverOneGoal = float.TryParse(worksheet.Cells[row, 14].Value?.ToString(), out float overOneGoal) ? overOneGoal : 0,
                        OverTwoGoals = float.TryParse(worksheet.Cells[row, 18].Value?.ToString(), out float overTwoGoals) ? overTwoGoals : 0,
                        OverThreeGoals = float.TryParse(worksheet.Cells[row, 22].Value?.ToString(), out float overThreeGoals) ? overThreeGoals : 0,
                        OverFourGoals = float.TryParse(worksheet.Cells[row, 24].Value?.ToString(), out float overFourGoals) ? overFourGoals : 0,
                        UnderOneGoal = float.TryParse(worksheet.Cells[row, 30].Value?.ToString(), out float underOneGoal) ? underOneGoal : 0,
                        UnderTwoGoals = float.TryParse(worksheet.Cells[row, 34].Value?.ToString(), out float underTwoGoals) ? underTwoGoals : 0,
                        UnderThreeGoals = float.TryParse(worksheet.Cells[row, 38].Value?.ToString(), out float underThreeGoals) ? underThreeGoals : 0,
                        UnderFourGoals = float.TryParse(worksheet.Cells[row, 40].Value?.ToString(), out float underFourGoals) ? underFourGoals : 0
                    };

                    extractedData.Add(matchData);
                }
            }
            else
            {
                Logger.Log("[bold][yellow]Excel file has no worksheets.[/][/]");
            }

            // Add extracted data to the database
            await _matchDataRepository.AddMatchData(extractedData);
        }
        catch (Exception e)
        {
            Logger.Log($"[bold][red]Error processing Excel file: {e.Message}[/][/]");
        }
    }
}