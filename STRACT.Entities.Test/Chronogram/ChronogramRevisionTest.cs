using STRACT.Entities.Chronogram;
using STRACT.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Chronogram
{
    public class ChronogramRevisionTest
    {
        [Fact]
        public void ChronogramRevisionAverageCompletionTest_ReturnsAverage()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            List<ChronogramLine> chronogramLines = new List<ChronogramLine>
            {
                new ChronogramLine{ChronogramLineId = 1, PercentOfConclusion = 1},
                new ChronogramLine{ChronogramLineId = 1, PercentOfConclusion = 0.5},
                new ChronogramLine{ChronogramLineId = 1, PercentOfConclusion = 0},
            };
            chronogramRevision.ChronogramLines = chronogramLines;

            Assert.True(chronogramRevision.AverageCompletion == 0.5);
        }

        [Fact]
        public void ChronogramRevisionAverageCompletionTest_HasEmptyCollection()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            Assert.True(chronogramRevision.AverageCompletion == 0);
        }

        [Fact]
        public void ChronogramRevisionAverageCompletionTest_HasOneElement()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            List<ChronogramLine> chronogramLines = new List<ChronogramLine>
            {
                new ChronogramLine{ChronogramLineId = 1, PercentOfConclusion = 0.5},
            };
            chronogramRevision.ChronogramLines = chronogramLines;

            Assert.True(chronogramRevision.AverageCompletion == 0.5);
        }

        [Fact]
        public void ChronogramRevisionTotalDays_HasEndDateBiggerThanStartDate()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            ChronogramLine chronogramLine1 = new ChronogramLine { ChronogramLineId = 1, PlannedStart = DateTime.Parse("10/10/2021"), DurationInDays = 5, ChronogramRevision = chronogramRevision};
            ChronogramLine chronogramLine2 = new ChronogramLine { ChronogramLineId = 1, PlannedStart = DateTime.Parse("15/10/2021"), DurationInDays = 10, ChronogramRevision = chronogramRevision };
            ChronogramLine chronogramLine3 = new ChronogramLine { ChronogramLineId = 1, PlannedStart = DateTime.Parse("20/10/2021"), DurationInDays = 20, ChronogramRevision = chronogramRevision };
            List<ChronogramLine> chronogramLines = new List<ChronogramLine>
            {
                chronogramLine1,
                chronogramLine2,
                chronogramLine3,
            };
            chronogramRevision.User = new Users.UserInTeam();
            chronogramRevision.User.PersonalHolidays = new List<UserHoliday>();
            chronogramRevision.ChronogramLines = chronogramLines;

            Assert.Equal(28,chronogramRevision.TotalDaysOfChronogramRevision);
        }

        [Fact]
        public void ChronogramRevisionTotalDays_HasEndDateEqualToStartDate()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            ChronogramLine chronogramLine1 = new ChronogramLine { ChronogramLineId = 1, PlannedStart = DateTime.Parse("10/10/2021"), DurationInDays = 0, ChronogramRevision = chronogramRevision };
            List<ChronogramLine> chronogramLines = new List<ChronogramLine>
            {
                chronogramLine1,
            };
            chronogramRevision.User = new Users.UserInTeam();
            chronogramRevision.User.PersonalHolidays = new List<UserHoliday>();
            chronogramRevision.ChronogramLines = chronogramLines;

            Assert.Equal(0, chronogramRevision.TotalDaysOfChronogramRevision);
        }

        [Fact]
        public void ChronogramRevisionTotalDays_HasEndDateLowerThanStartDate()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();
            ChronogramLine chronogramLine1 = new ChronogramLine { ChronogramLineId = 1, PlannedStart = DateTime.Parse("10/10/2021"), DurationInDays = -10, ChronogramRevision = chronogramRevision };
            List<ChronogramLine> chronogramLines = new List<ChronogramLine>
            {
                chronogramLine1,
            };
            chronogramRevision.User = new Users.UserInTeam();
            chronogramRevision.User.PersonalHolidays = new List<UserHoliday>();
            chronogramRevision.ChronogramLines = chronogramLines;

            Assert.Equal(10, chronogramRevision.TotalDaysOfChronogramRevision);
        }

        [Fact]
        public void ChronogramRevisionTotalDays_HasEmptyList()
        {
            ChronogramRevision chronogramRevision = new ChronogramRevision();

            Assert.True(chronogramRevision.TotalDaysOfChronogramRevision == 0);
        }
    }
}
