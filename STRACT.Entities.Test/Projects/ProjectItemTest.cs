using STRACT.Entities.Chronogram;
using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Projects
{
    public class ProjectItemTest
    {
        [Fact]
        public void GetActionCompletionPercentage_TestException()
        {
            ProjectItem projectItem = new ProjectItem { Chronograms = new List<ChronogramRevision>() };

            Assert.Throws<Exception>(() => projectItem.GetActionCompletionPercentage());
        }
    }
}
