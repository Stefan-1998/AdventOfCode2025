using System.IO;
using System.Reflection;
using FluentAssertions;

namespace AdventOfCode.Test.Common
{
    public class CopyOfTxt
    {
        [Fact]
        public void AllTextFilesAreCopiedToOutput()
        {
            var txtFilesInSrc = Directory.GetFiles(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "*.txt"
            );
            var txtFilesInBin = Directory.GetFiles(".", "*.txt");

            txtFilesInSrc.Except(txtFilesInBin).Should().BeEmpty();
        }
    }
}
