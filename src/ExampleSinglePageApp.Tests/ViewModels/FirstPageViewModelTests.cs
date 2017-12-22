using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using ExampleSinglePageApp.Messages;
using ExampleSinglePageApp.ViewModels;
using FakeItEasy;
using NUnit.Framework;

namespace ExampleSinglePageApp.Tests.ViewModels
{
    [TestFixture]
    [Parallelizable]
    public class FirstPageViewModelTests
    {
        [SetUp]
        public void SetUp()
        {
            _eventAggregator = A.Fake<IEventAggregator>();
            _viewModel = new FirstPageViewModel(_eventAggregator);
        }

        private IEventAggregator _eventAggregator;
        private FirstPageViewModel _viewModel;

        [Test]
        public async Task GoToSecondPage_should_publish_ChangePageMessage()
        {
            ChangePageMessage invokedMessage = null;

            A.CallTo(() => _eventAggregator.Publish(A<object>._, A<Action<Action>>._))
                .Invokes((object message, Action<Action> marshal) =>
                {
                    invokedMessage = message as ChangePageMessage;
                    marshal(() => { });
                });

            await _viewModel.GoToSecondPage();

            Assert.NotNull(invokedMessage);
            Assert.That(invokedMessage.ViewModelType == typeof(SecondPageViewModel));
        }
    }
}
