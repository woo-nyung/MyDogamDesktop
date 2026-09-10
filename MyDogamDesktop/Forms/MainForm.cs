using MyDogamDesktop.Services;
using MyDogamDesktop.Models;

namespace MyDogamDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCollections();
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

        private List<Collection> _collections = new List<Collection>();
        private async void LoadCollections()
        {
            var service = new CollectionService();
            _collections = await service.GetAllCollectionsAsync();

            lstCollections.Items.Clear();
            foreach (var c in _collections)
            {
                lstCollections.Items.Add($"{c.Name} ({c.TotalItems}개)");
            }
        }

        private async void lstCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCollections.SelectedIndex == -1) return;

            var selected = _collections[lstCollections.SelectedIndex];
            var service = new CollectionService();
            var items = await service.GetItemsByCollectionIdAsync(selected.Id);

            lstItems.Items.Clear();
            foreach(var item in items)
            {
                lstItems.Items.Add($"{item.ItemId} - {item.Name} (수량: {item.Count})");
            }
        }
    }
}
