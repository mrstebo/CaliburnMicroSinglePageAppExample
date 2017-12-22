using System.Threading.Tasks;
using Caliburn.Micro;
using ExampleSinglePageApp.Messages;

namespace ExampleSinglePageApp.ViewModels
{
    public class FirstPageViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public FirstPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public async Task GoToSecondPage()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new ChangePageMessage(typeof(SecondPageViewModel)));
        }
    }
}
