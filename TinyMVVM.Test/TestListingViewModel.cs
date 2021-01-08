using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyMVVM.Test
{
    [TestClass]
    public class TestListingViewModel
    {
        [TestMethod]
        public void TestSelectedItem()
        {
            var vm = new ListModel();
            var obj = new TestObj("Hello World");
            vm.Items.Add(obj);
            vm.SelectedIndex = 0;
            Assert.AreEqual(obj, vm.SelectedItem);
        }

        [TestMethod]
        public void TestDeleteCommandWiring()
        {
            var vm = new ListModel();
            vm.Items.Add(new TestObj("Hello World"));
            Assert.AreEqual(1, vm.Items.Count);
            vm.DeleteItemCommand.Execute(vm.Items[0]);
            Assert.AreEqual(0, vm.Items.Count);
        }

        [TestMethod]
        public void TestSelectedIndex()
        {
            var vm = new ListModel();
            vm.Items.Add(new TestObj("Hello World"));
            vm.SelectedIndex = -1;
            var fired = false;
            vm.SelectedIndexChanged += (sender, args) =>
            {
                fired = true;
            };
            Assert.IsFalse(fired);
            vm.SelectedIndex = 0;
            Assert.IsTrue(fired);
        }

    }

    internal class ListModel : ListingViewModel<TestObj>
    {
        [DeleteCommand]
        public void DeleteItem(TestObj item)
        {
            if (SelectedItem == item)
            {
                if (SelectedIndex == 0 && Items.Count > 1) SelectedIndex++;
                else SelectedIndex--;
            }
            Items.Remove(item);
        }
    }

    internal class TestObj
    {
        public string Param { get; set; }

        public TestObj(string p) => Param = p;
    }
}
