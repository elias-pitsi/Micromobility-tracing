using MicromobilityApp.Models;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MicromobilityApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BikeRegistration : ContentPage
	{
        private Client client;
		private OwnerDto owner;
		private ComponentsDto components;
		private BikeDto BikeDtobike;

        public BikeRegistration ()
		{
			InitializeComponent ();
			client= new Client ();
			owner = new OwnerDto();
			components = new ComponentsDto();
			BikeDtobike = new BikeDto();
		}

		public async void HandleBikeRegistration(object sender, EventArgs e)
		{

			var ownerId = owner.OwnerId;
			var CompId = components.CompId;
			var bikeId = BikeDtobike.BikeId;

			List<BikeComponentsDto> componentsCollection = new List<BikeComponentsDto>()
			{
				new BikeComponentsDto { CompId = Guid.NewGuid(), ComponentName = battery.Text, 
				CreatedDate = DateCreated.Date},

				new BikeComponentsDto { CompId = Guid.NewGuid(), ComponentName = motor.Text, 
				CreatedDate = DateCreated.Date},

				new BikeComponentsDto { CompId = Guid.NewGuid(), ComponentName = gear.Text, 
				CreatedDate = DateCreated.Date},
            };

			var bikeResult = new BikeDto
			{
				BikeId = bikeId,
				OwnerId = ownerId,
				Components = componentsCollection,
			};

			var getBikeRegistration = await client.BikeAsync(bikeResult);

			if (getBikeRegistration.BikeResponse1 != "Something when wrong") 
			{
                await Navigation.PushAsync(new MenuPage());
            }
        }
    }
}