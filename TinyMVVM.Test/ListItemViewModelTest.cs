using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyMVVM.Test
{
    [TestClass]
    public class ListItemViewModelTest
    {
        [TestMethod]
        public void TestConstruct()
        {
            var list = new TheList();
            var item = new TheItem(list);
            Assert.AreEqual(list, item.Parent);
        }
    }

    internal class TheList : ListingViewModel<TheItem>
    {

    }

    internal class TheItem : ListItemViewModel<TheList, TheItem>
    {
        public TheItem(TheList parent) : base(parent)
        {

        }
    }
}
