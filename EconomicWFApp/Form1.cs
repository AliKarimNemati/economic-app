using EconomicWFApp.data;
using EconomicWFApp.model;
using EconomicWFApp.model.Domain;
using EconomicWFApp.model.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EconomicWFApp
{
    public partial class EconomicApp : Form
    {
        private Guid? _fileId = null;
        public EconomicApp()
        {
            InitializeComponent();
        }

        // get all cost type
        private async Task<List<CostType>> GetCostType()
        {
            try
            {
                costTypeInput.Text = "loading...";
                List<CostType> costTypeResponse = new List<CostType>();
                HttpClient client = new HttpClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:44338/api/CostType");

                httpResponseMessage.EnsureSuccessStatusCode();

                costTypeResponse.AddRange(await httpResponseMessage.Content.ReadAsAsync<IEnumerable<CostType>>());

                costTypeInput.Text = "";

                return costTypeResponse;
            }
            catch (Exception ex)
            {
                costTypeInput.Text = ex.Message;
                return null;
            }
        }

        // get all costs
        private async Task<List<CostDto>> GetCost()
        {
            try
            {
                lblLoadCost.Visible = true;
                List<CostDto> costResponse = new List<CostDto>();
                HttpClient client = new HttpClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:44338/api/Cost");

                httpResponseMessage.EnsureSuccessStatusCode();

                costResponse.AddRange(await httpResponseMessage.Content.ReadAsAsync<IEnumerable<CostDto>>());

                lblLoadCost.Visible = false;
                return costResponse;
            }
            catch (Exception ex)
            {
                lblErrorCost.Visible = true;
                lblErrorCost.Text = ex.Message;
                return null;
            }
        }

        // get all incomes
        private async Task<List<IncomeDto>> GetIncome()
        {
            try
            {
                lblLoadIncome.Visible = true;
                List<IncomeDto> incomeResponse = new List<IncomeDto>();
                HttpClient client = new HttpClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:44338/api/Income");

                httpResponseMessage.EnsureSuccessStatusCode();

                incomeResponse.AddRange(await httpResponseMessage.Content.ReadAsAsync<IEnumerable<IncomeDto>>());

                lblLoadIncome.Visible = false;
                return incomeResponse;
            }
            catch (Exception ex)
            {
                lblErrorIncome.Visible = true;
                lblErrorIncome.Text = ex.Message;
                return null;
            }
        }

        //actions that run when app load
        private async void EconomicApp_Load(object sender, EventArgs e)
        {
            lblErrorIncome.Visible = false;
            lblErrorCost.Visible = false;

            lblLoadIncome.Visible = true;
            lblLoadCost.Visible = true;

            costDG.DataSource = (await GetCost()).Select(c => new { c.Name, c.Amount, Type = c.Type.Name, File = c.CostFile == null ? "No File" : c.CostFile.FilePath }).ToList();

            incomeDG.DataSource = await GetIncome();

            var costTypes = await GetCostType();
            foreach (var costType in costTypes)
            {
                costTypeInput.Items.Add(costType.Name);
            }


        }

        //refresh income list 
        private async void RefIncomeBtn_Click(object sender, EventArgs e)
        {
            incomeDG.DataSource = await GetIncome();
        }

        //regresh cost list
        private async void RefCostBtn_Click(object sender, EventArgs e)
        {
            costDG.DataSource = (await GetCost()).Select(c => new { c.Name, c.Amount, Type = c.Type.Name, File = c.CostFile == null ? "No File" : c.CostFile.FilePath }).ToList();
        }

        //add a income item to the list
        private async void AddIncomeBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if ((int)incomeAmountInput.Value <= 0 || incomeNameInput.Text == "")
                {
                    vilidationErrorIncome.Text = "name and price are required";
                }
                else
                {
                    vilidationErrorIncome.Text = "";
                    var income = new Income
                    {
                        Amount = (int)incomeAmountInput.Value,
                        Name = incomeNameInput.Text
                    };

                    HttpClient client = new HttpClient();

                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri("https://localhost:44338/api/Income"),
                        Content = new StringContent(JsonConvert.SerializeObject(income), Encoding.UTF8, "application/json")
                    };

                    var response = await client.SendAsync(httpRequestMessage);
                    response.EnsureSuccessStatusCode();

                    incomeDG.DataSource = await GetIncome();

                    incomeNameInput.Text = "";
                    incomeAmountInput.Value = 0;
                }
            }
            catch (Exception ex)
            {
                lblErrorIncome.Visible = true;
                lblErrorIncome.Text = ex.Message;
            }
        }

        //add a cost item to the list
        private async void AddCostBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var costTypes = await GetCostType();
                var costType = costTypeInput.SelectedItem != null ? costTypes.FirstOrDefault(x => x.Name == costTypeInput.SelectedItem.ToString()) : null;

                if ((int)costAmountInput.Value <= 0 || costNameInput.Text == "" || costType == null)
                {
                    vilidationErrorCost.Text = "name, price and type are required";
                }
                else
                {
                    vilidationErrorCost.Text = "";
                    var cost = new Cost
                    {
                        Amount = (int)costAmountInput.Value,
                        Name = costNameInput.Text,
                        TypeId = costType.Id,
                        CostFileId = _fileId == new Guid("00000000-0000-0000-0000-000000000000") ? null : _fileId
                    };

                    HttpClient client = new HttpClient();

                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri("https://localhost:44338/api/Cost"),
                        Content = new StringContent(JsonConvert.SerializeObject(cost), Encoding.UTF8, "application/json")
                    };

                    var response = await client.SendAsync(httpRequestMessage);
                    response.EnsureSuccessStatusCode();

                    var costs = await GetCost();


                    costDG.DataSource = (await GetCost()).Select(c => new { c.Name, c.Amount, Type = c.Type.Name, File = c.CostFile == null ? "No File" : c.CostFile.FilePath }).ToList();

                    costNameInput.Text = "";
                    costAmountInput.Value = 0;
                }

            }
            catch (Exception ex)
            {
                lblErrorCost.Visible = true;
                lblErrorCost.Text = ex.Message;
            }
        }

        //upload cost file
        private async void AddFileBtn_Click(object sender, EventArgs e)
        {
            if (openCostFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openCostFileDialog.Multiselect = false;
                    openCostFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png";

                    HttpClient client = new HttpClient();
                    var costFile = new CostFile();

                    var form = new MultipartFormDataContent();

                    var fileStream = File.OpenRead(openCostFileDialog.FileName);

                    var streamContent = new StreamContent(fileStream);

                    var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());

                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                    form.Add(fileContent, "File", Path.GetFileName(openCostFileDialog.FileName));
                    form.Add(new StringContent(Path.GetFileName(openCostFileDialog.FileName)), "FileName");

                    var response = await client.PostAsync("https://localhost:44338/api/CostFile/Uplaod", form);

                    response.EnsureSuccessStatusCode();

                    costFile = await response.Content.ReadAsAsync<CostFile>();
                    AddFileBtn.Text = costFile.FileName;

                    
                    _fileId = costFile.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
