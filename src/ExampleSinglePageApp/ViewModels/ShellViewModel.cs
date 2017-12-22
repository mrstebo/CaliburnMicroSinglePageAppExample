using Caliburn.Micro;
using ExampleSinglePageApp.Messages;

namespace ExampleSinglePageApp.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive, IHandle<ChangePageMessage>
    {
        private readonly IServiceLocator _serviceLocator;

        public ShellViewModel(IEventAggregator eventAggregator, IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;

            eventAggregator.Subscribe(this);
        }

        protected override void OnActivate()
        {
            Handle(new ChangePageMessage(typeof(FirstPageViewModel)));

            base.OnActivate();
        }

        public void Handle(ChangePageMessage message)
        {
            var vm = _serviceLocator.Resolve(message.ViewModelType);

            ActivateItem(vm);
        }
    }
}
