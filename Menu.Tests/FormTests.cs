using Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xunit;

namespace Menu.Tests
{
    public class FormTests
    {
        [Fact]
        public void Form1Test()
        {
            Table form = new Table();

            Assert.Equal(form.i, 14);
            Assert.Equal(form.j, 12);
            for(int f = 0; f < 5; ++f)
            {
                form.AddRow();
            }
            Assert.Equal(form.i, 19);
            for(int f = 0; f < 9; ++f)
            {
                form.AddCol();
            }
            Assert.Equal(form.j, 21);
            form.DelCol();
            form.DelRow();
            Assert.Equal(form.j, 20);
            Assert.Equal(form.i, 18);
        }
    }
}
