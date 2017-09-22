using System;
using HalloMVVM.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace HalloMVVM.Tests.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void CanCreateInstance()
        {
            var vm = new MainWindowViewModel();
            Assert.IsNotNull(vm);
        }
        [TestMethod]
        public void WelcomeText_contains_HalloMVVM_after_Initialisation()
        {
            var vm = new MainWindowViewModel();

            Assert.AreEqual("Hallo MVVM.", vm.WelcomeText);
        }
        [TestMethod]
        public void Can_set_text_to_WelcomeText_Property()
        {
            var vm = new MainWindowViewModel();

            vm.WelcomeText = "Mein neuer Text";

            Assert.AreEqual("Mein neuer Text", vm.WelcomeText);
        }
        [TestMethod]
        public void WelcomeText_setter_raise_PropertyChanged_event()
        {
            var vm = new MainWindowViewModel();

            var eventWasRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "WelcomeText")
                    eventWasRaised = true;
            };

            vm.WelcomeText = "Mein neuer Text";

            Assert.IsTrue(eventWasRaised);
        }
        [TestMethod]
        public void ChangeTextCommand_Execute_changes_WelcomeTextProperty()
        {
            var vm = new MainWindowViewModel();
            vm.WelcomeText = string.Empty;

            vm.ChangeTextCommand.Execute(null);

            //System.Threading.Thread.Sleep(10000);       // Hässlich?

            Assert.AreEqual("Mein neuer Text aus dem VM", vm.WelcomeText);
        }
        [TestMethod]
        public async Task ChangeText_changes_WelcomeTextProperty()
        {
            var vm = new MainWindowViewModel();
            vm.WelcomeText = string.Empty;

            await vm.ChangeText();

            Assert.AreEqual("Mein neuer Text aus dem VM", vm.WelcomeText);
        }
    }
}
