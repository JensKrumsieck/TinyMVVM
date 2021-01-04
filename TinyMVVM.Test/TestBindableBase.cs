using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyMVVM.Test
{
    [TestClass]
    public class TestBindableBase
    {
        [TestMethod]
        public void TestSetter()
        {
            var instance = new Bindable {Property = "Hello World"};
            Assert.AreEqual("Hello World", instance.Property);
        }

        [TestMethod]
        public void TestWithAction()
        {
            var instance = new Bindable {WithAction = "Hello World"};
            Assert.AreEqual("Hello World", instance.WithAction);
            Assert.AreEqual("True", instance.Property);
        }
    }

    internal class Bindable : BindableBase
    {
        private string _property;
        private string _withAction;

        public string Property
        {
            get => _property;
            set => Set<string>(ref _property, value);
        }

        public string WithAction
        {
            get => _withAction;
            set => Set<string>(ref _withAction, value, WithActionChanged);
        }

        public void WithActionChanged() => Property = "True";
    }
}
