using System.Threading.Tasks;
using Caliburn.Micro;
using ExampleSinglePageApp.Messages;

namespace ExampleSinglePageApp.ViewModels
{
    public class SecondPageViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public SecondPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public async Task GoToFirstPage()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ChangePageMessage(typeof(FirstPageViewModel)));
        }
    }
}
