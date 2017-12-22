using System;
using Caliburn.Micro;
using ExampleSinglePageApp.Messages;
using ExampleSinglePageApp.ViewModels;
using FakeItEasy;
using NUnit.Framework;

namespace ExampleSinglePageApp.Tests.ViewModels
{
    [TestFixture]
    [Parallelizable]
    public class ShellViewModelTests
    {
        [SetUp]
        public void SetUp()
        {
            _eventAggregator = A.Fake<IEventAggregator>();
            _serviceLocator = A.Fake<IServiceLocator>();
            _viewModel = new ShellViewModel(_eventAggregator, _serviceLocator);
        }

        private IEventAggregator _eventAggregator;
        private IServiceLocator _serviceLocator;
        private ShellViewModel _viewModel;

        [Test]
        public void Should_subscribe_to_events()
        {
            A.CallTo(() => _eventAggregator.Subscribe(_viewModel)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Handle_with_ChangePageMessage_should_get_view_model_from_service_locator()
        {
            var type = typeof(ShellViewModel);

            _viewModel.Handle(new ChangePageMessage(type));

            A.CallTo(() => _serviceLocator.Resolve(type)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Handle_with_ChangePageMessage_should_change_active_item()
        {
            var vm = A.Fake<ShellViewModel>();

            A.CallTo(() => _serviceLocator.Resolve(A<Type>._)).Returns(vm);

            _viewModel.Handle(new ChangePageMessage(typeof(ShellViewModel)));

            Assert.AreEqual(vm, _viewModel.ActiveItem);
        }
    }
}
