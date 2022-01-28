namespace TinyMVVM.Test;

[TestClass]
public class TestBaseViewModel
{
    [TestMethod]
    public void TestSubscription()
    {
        var vm = new BaseTester();
        vm.AddSource();
        Assert.AreEqual(vm.SourceCollection.Count, vm.Doubles.Count);
        vm.RemoveSource();
        Assert.AreEqual(vm.SourceCollection.Count, vm.Doubles.Count);
        Assert.AreEqual(0.1, vm.Doubles[0]);
        Assert.AreEqual(0.3, vm.Doubles[1]);
        vm.SourceCollection.ClearAndNotify();
        Assert.AreEqual(vm.SourceCollection.Count, vm.Doubles.Count);
    }
}

internal class BaseTester : BaseViewModel
{
    public readonly ObservableCollection<string> SourceCollection = new ObservableCollection<string>();

    public readonly IList<double> Doubles = new List<double>();

    public BaseTester()
    {
        Subscribe(SourceCollection, Doubles, s => Convert.ToDouble(s, CultureInfo.InvariantCulture));
    }

    public static double ToDouble(string s) => Convert.ToDouble(s, CultureInfo.InvariantCulture);

    public void AddSource()
    {
        SourceCollection.Add("0.1");
        SourceCollection.Add("0.2");
        SourceCollection.Add("0.3");
    }

    public void RemoveSource()
    {
        SourceCollection.Remove("0.2");
    }
}
