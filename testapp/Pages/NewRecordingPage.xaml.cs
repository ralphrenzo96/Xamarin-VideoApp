using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace testapp
{
    public partial class NewRecordingPage : ContentPage
    {
        private ObservableCollection<Stream> streams = new ObservableCollection<Stream>();
        private MediaFile file;

		public NewRecordingPage()
		{
			InitializeComponent();

            /// Providing slots for streams
            streams.Add(new Stream() { id = 1 });
            streams.Add(new Stream() { id = 2 });
			streams.Add(new Stream() { id = 3 });
			streams.Add(new Stream() { id = 4 });
			streams.Add(new Stream() { id = 5 });
			streams.Add(new Stream() { id = 6 });

            streamFlowList.FlowItemsSource = streams;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

        private async void OnStream_FlowItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Stream stream = e.Item as Stream;
            int index = streams.IndexOf(stream);

            if(stream.isEmpty)
            {
                var choice = await DisplayActionSheet("Choose", "Cancel", null, "New Recording", "Import");

                switch(choice)
                {
                    case "New Recording":
                        DisplayAlert(string.Empty, "On development", "Go back");
						break;
                    case "Import":
                        streams[index].path = await PickVideo();
						file.Dispose();
						break;
                }
            }
        }

        private async Task<string> PickVideo()
        {
			if (!CrossMedia.Current.IsPickVideoSupported)
			{
				DisplayAlert(string.Empty, "Permission is not granted.", "Go back");
                return string.Empty;
			}
			file = await CrossMedia.Current.PickVideoAsync();

			if (file == null)
                return string.Empty;

            return file.Path;
		}
    }
}
