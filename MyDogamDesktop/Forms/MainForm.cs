using MyDogamDesktop.Services;
using MyDogamDesktop.Models;
using System.Text.Json;

namespace MyDogamDesktop
{
    public partial class MainForm : Form
    {
        private List<Collection> _collections = new List<Collection>();
        private List<CollectionItem> _items = new List<CollectionItem>();
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadCollections();
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
                await LoadCollections();
            }
        }

        private async Task LoadCollections()
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
            _items = await service.GetItemsByCollectionIdAsync(selected.Id);

            lstItems.Items.Clear();
            foreach (var item in _items)
            {
                lstItems.Items.Add($"{item.ItemId} - {item.Name} (수량: {item.Count})");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCollections.SelectedIndex == -1)
            {
                MessageBox.Show("삭제할 컬렉션을 선택하세요.");
                return;
            }

            var selected = _collections[lstCollections.SelectedIndex];
            var confirm = MessageBox.Show($"'{selected.Name}'을(를) 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var service = new CollectionService();
                await service.DeleteCollectionAsync(selected.Id);

                lstItems.Items.Clear();
                await LoadCollections();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex == -1) return;

            var selected = _items[lstItems.SelectedIndex];
            var metadata = JsonSerializer.Deserialize<Dictionary<string, object>>(selected.MetadataJson);

            if (metadata != null && metadata.TryGetValue("img_src", out object? imgSrc)) {
                try
                {
                    pictureBoxItem.ImageLocation = imgSrc.ToString();
                }
                catch
                {
                    pictureBoxItem.Image = null;
                }
            }
            else
            {
                pictureBoxItem.Image = null;
            }


            var infoText = $"ID: {selected.ItemId}\r\n이름: {selected.Name}\r\n수량: {selected.Count}\r\n\r\n";
            if (metadata != null) {
                foreach (var kv in metadata) {
                    infoText += $"{kv.Key}: {kv.Value}\r\n";
                }
            }
            txtItemInfo.Text = infoText;
        }
    }
}
