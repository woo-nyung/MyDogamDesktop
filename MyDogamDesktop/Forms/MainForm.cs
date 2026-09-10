using MyDogamDesktop.Services;

namespace MyDogamDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string jsonText = File.ReadAllText(dialog.FileName);
                var parser = new JsonParserService();
                var items = parser.ParseCollectionJson(jsonText);

                var service = new CollectionService();
                await service.CreateCollectionFromItemsAsync(
                    Path.GetFileNameWithoutExtension(dialog.FileName),
                    Path.GetFileName(dialog.FileName),
                    items
                );

                MessageBox.Show("업로드 완료!");
                LoadCollections();
            }
        }

        private async void LoadCollections()
        {
            var service = new CollectionService();
            var collections = await service.GetAllCollectionsAsync();

            lstCollections.Items.Clear();
            foreach (var c in collections)
            {
                lstCollections.Items.Add($"{c.Name} ({c.TotalItems}개)");
            }
        }
    }
}
