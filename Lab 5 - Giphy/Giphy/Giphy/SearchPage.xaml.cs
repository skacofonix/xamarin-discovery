using System;
using System.Threading;
using System.Threading.Tasks;
using Giphy.Api;
using SmartConnect.Common;
using Xamarin.Forms;

namespace Giphy
{
    public partial class SearchPage
    {
        private readonly GiphyClient _gliphyClient;

        public SearchPage(GiphyClient gliphyClient)
        {
            _gliphyClient = gliphyClient;

            InitializeComponent();
            BindingContext = this;
        }

        public ObservableRangeCollection<GifObject> Results { get; } = new ObservableRangeCollection<GifObject>();

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (value == _isRefreshing) return;
                _isRefreshing = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Status));
            }
        }

        public DataStatus Status
        {
            get
            {
                if (IsRefreshing) return DataStatus.Pending;
                return Results.Count > 0 ? DataStatus.Populated : DataStatus.Empty;
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }

        private Command _searchCommand;

        public Command SearchCommand => _searchCommand ?? (_searchCommand = new Command(() =>
        {
            if (IsRefreshing) return;
            IsRefreshing = true;

            Task.Run(async () =>
            {
                try
                {
                    await Search(Text);
                }
                finally
                {
                    IsRefreshing = false;
                }
            });
        }, () => !IsRefreshing));

        private CancellationTokenSource cts;

        private async Task Search(string text)
        {
            cts?.Cancel(true);
            cts = new CancellationTokenSource();

            try
            {
                var result = await _gliphyClient.Translate(text, cts.Token);
                Results.Clear();
                Results.Add(result);
            }
            catch (OperationCanceledException)
            { }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}