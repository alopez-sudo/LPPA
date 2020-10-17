using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuscribeYa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Resultado : ContentPage
	{
		List<Categoria> categorias;

		public Resultado(List<Categoria> categorias)
		{
			InitializeComponent();
			this.categorias = categorias;
			CargarCategorias();
		}

		private void CargarCategorias()
		{
			categorias = categorias.Where(x => x.IsCheck).ToList();
			LstCategorias.ItemsSource = categorias;
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}
