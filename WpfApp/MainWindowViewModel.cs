using System.Collections.Immutable;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _info;

        [ObservableProperty]
        private IReadOnlyCollection<Visit> _visits;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor( nameof( EditVisitCommand ) )]
        private Visit? _selectedVisit;

        public bool CanEditVisit => SelectedVisit is not null;

        [RelayCommand( CanExecute = nameof( CanEditVisit ) )]
        private void EditVisit( Visit visit )
        {
            Info = $"EditVisit => {visit?.Name}";
        }

        public MainWindowViewModel()
        {
            _visits = Enumerable.Range( 1, 10 )
                .Select( i => new Visit { Name = $"Visit {i}" } )
                .ToImmutableList();
        }
    }

    public class Visit
    {
        public string Name { get; set; } = string.Empty;
    }
}
