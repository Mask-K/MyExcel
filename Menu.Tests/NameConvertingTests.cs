using System;
using System.Collections.Generic;
using System.Text;
using Menu;
using Xunit;


namespace Menu.Tests
{
    public class NameConvertingTests
    {
        Table t = new Table();

        [Fact]
        public void MakeNameTest()
        {
            Assert.Equal(t.SetCellName(1, 1), "B1");
            Assert.Equal(t.SetCellName(26, 2), "AA2");
            Assert.Equal(t.SetCellName(51, 200), "BA200");
        }
    }
}
