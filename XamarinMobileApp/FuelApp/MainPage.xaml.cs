using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace FuelApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Btn_tankkaamaan_Clicked(object sender, EventArgs e)
        {
            try {
                string reknro = await DisplayPromptAsync("1.", "Anna rekkari muodossa ABC123");
                decimal litraa = decimal.Parse(await DisplayPromptAsync("2.", "Anna tankatut litrat muodossa xx.yy"));
                decimal euroa = decimal.Parse(await DisplayPromptAsync("3.", "Anna euromäärä muodossa xx.yy"));
                int mittarilukema = int.Parse(await DisplayPromptAsync("4.", "Anna mittarilukema 1 km tarkkuudella"));

                TankkausData tankkaus = new TankkausData()
                {
                    Pvm = DateTime.Now,
                    Litraa = litraa,
                    Euroa = euroa,
                    Reknro = reknro,
                    Mittarilukema = mittarilukema
                };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://timesheetrest.azurewebsites.net/");


                // Muutetaan em. data objekti Jsoniksi
                string input = JsonConvert.SerializeObject(tankkaus);
                StringContent content = new StringContent(input, Encoding.UTF8, "application/json");


                // Lähetetään serialisoitu objekti back-endiin Post pyyntönä
                HttpResponseMessage message = await client.PostAsync("/api/tankkaukset", content);


                // Otetaan vastaan palvelimen vastaus
                string reply = await message.Content.ReadAsStringAsync();


                //Asetetaan vastaus serialisoituna success muuttujaan
                bool success = JsonConvert.DeserializeObject<bool>(reply);


                if (success)  // Näytetään ehdollisesti alert viesti
                {

                    await DisplayAlert("Valmis!", "Tankkaus talletettu", "Sulje"); // (otsikko, teksti, kuittausnapin teksti)
                }
                else
                {
                    await DisplayAlert("Virhe", "Virhe palvelimella", "Sulje");
                }

            }
            catch (Exception ex) // Otetaan poikkeus ex muuttujaan ja sijoitetaan errorMessageen
            {

                string errorMessage = ex.GetType().Name + ": " + ex.Message; // Poikkeuksen customoitu selvittäminen ja...


            }
        }
    }
}
