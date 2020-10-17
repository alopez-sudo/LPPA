using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuscribeYa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		List<Categoria> categorias;

		public MainPage()
		{
			InitializeComponent();
			CargarCategorias();
		}

		private void CargarCategorias()
		{
			categorias = new List<Categoria>();
			categorias.Add(new Categoria() { Nombre = "Política", IsCheck = false });
			categorias.Add(new Categoria() { Nombre = "Negocios", IsCheck = false });
			categorias.Add(new Categoria() { Nombre = "Deportes", IsCheck = false });
			categorias.Add(new Categoria() { Nombre = "Espectáculos", IsCheck = false });
			categorias.Add(new Categoria() { Nombre = "Tecnología", IsCheck = false });
			LstCategorias.ItemsSource = categorias;
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Resultado(categorias));
		}
	}
}
