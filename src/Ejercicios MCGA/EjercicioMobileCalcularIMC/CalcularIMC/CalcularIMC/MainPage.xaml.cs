using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CalcularIMC
{
	public partial class MainPage : ContentPage
	{
		private List<Sexo> sexos;

		public List<Sexo> Sexos
		{
			get
			{
				return sexos;
			}
			set
			{
				sexos = value;
			}
		}

		private Sexo sexo;

		public Sexo Sexo
		{
			get { return sexo; }
			set
			{
				sexo = value;
			}
		}

		public MainPage()
		{
			InitializeComponent();
			CargarLstSexo();
		}

		private void CargarLstSexo()
		{
			sexos = new List<Sexo>();
			sexos.Add(new Sexo() { Nombre = "Femenino" });
			sexos.Add(new Sexo() { Nombre = "Masculino" });
			LstSexo.ItemsSource = Sexos;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			TxtIMC.Text = GetResultado();
		}

		private double CalcularIMC()
		{
			double imc;
			double peso = double.Parse(TxtPeso.Text);
			double altura = double.Parse(TxtAltura.Text);

			imc = peso / Math.Pow(altura, 2.0);

			if(Sexo.Nombre.ToUpper() == "FEMENINO")
				imc = imc * 0.90;

			imc = imc * GetPorcentajeModificadorEstructuraCorporal();

			return imc;
		}

		private double GetPorcentajeModificadorEstructuraCorporal()
		{
			double porcentaje = 0;

			if(radGrande.IsChecked)
				porcentaje = 1.1;
			else if(radGrande.IsChecked)
				porcentaje = 1.05;
			else if(radGrande.IsChecked)
				porcentaje = 1.01;

			return porcentaje;
		}

		private string GetResultado()
		{
			string resultado = "";
			double imc = CalcularIMC();

			if(imc < 18)
				resultado = "Peso Bajo";
			if(imc >= 18 && imc <= 24.9)
				resultado = "Normal";
			if(imc >= 25 && imc <= 26.9)
				resultado = "Sobrepeso";
			if(imc >= 27 && imc <= 29.9)
				resultado = "Obeso";
			if(imc >= 30 && imc <= 39.9)
				resultado = "Obeso I";
			if(imc >= 40)
				resultado = "Obeso II";

			return resultado;
		}

		private void LstSexo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(LstSexo.SelectedIndex == -1)
				return;
			Sexo = (Sexo)LstSexo.SelectedItem;
		}
	}
}
