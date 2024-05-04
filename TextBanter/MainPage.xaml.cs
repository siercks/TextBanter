using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;

namespace TextBanter
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://textbantermaui-default-rtdb.firebaseio.com/");
        public ObservableCollection<TextPost> TextPostsCollection { get; set; } = new ObservableCollection<TextPost>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            var textCollection = firebaseClient
                .Child("TextPost")
                .AsObservable<TextPost>()
                .Subscribe((item) =>
                {
                    //GifPosts.Clear()
                    if (item.Object != null)
                    {
                        TextPostsCollection.Add(new TextPost
                        {
                            Username = item.Object.Username,
                            Text = item.Object.Text,
                            Date = item.Object.Date
                        });
                    }
                });
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            firebaseClient.Child("TextPost").PostAsync(new TextPost
            {
                Username = "User",
                Text = PostEntry.Text,
                Date = DateTime.Now
            });
            PostEntry.Text = string.Empty;
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
